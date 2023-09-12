using LandonApi.Infrastructure;
using LandonApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace LandonApi.Filters {
    //public class LinkRewritingFilter : IAsyncResultFilter {
    //    private readonly IUrlHelperFactory _urlHelperFactory;

    //    public LinkRewritingFilter(IUrlHelperFactory urlHelperFactory) {
    //        _urlHelperFactory = urlHelperFactory;
    //    }

    //    public Task OnResultExecutionAsync(
    //        ResultExecutingContext context, ResultExecutionDelegate next) {
    //        var asObjectResult = context.Result as ObjectResult;
    //        bool shouldSkip = asObjectResult?.StatusCode >= 400
    //            || asObjectResult?.Value == null
    //            || asObjectResult?.Value as Resource == null;

    //        if (shouldSkip) {
    //            return next();
    //        }

    //        var rewriter = new LinkRewriter(_urlHelperFactory.GetUrlHelper(context));
    //        RewriteAllLinks(asObjectResult.Value, rewriter);

    //        return next();
    //    }

    //    private static void RewriteAllLinks(object model, LinkRewriter rewriter) {
    //        if (model == null) return;

    //        var allProperties = model
    //            .GetType().GetTypeInfo()
    //            .GetAllProperties()
    //            .Where(p => p.CanRead)
    //            .ToArray();

    //        var linkProperties = allProperties
    //            .Where(p => p.CanWrite && p.PropertyType == typeof(Link));

    //        foreach (var linkProperty in linkProperties) {
    //            var rewritten = rewriter.Rewrite(linkProperty.GetValue(model) as Link);
    //            if (rewritten == null) continue;

    //            linkProperty.SetValue(model, rewritten);

    //            // Special handling of the hidden Self property:
    //            // unwrap into the root object
    //            if (linkProperty.Name == nameof(Resource.Self)) {
    //                allProperties
    //                    .SingleOrDefault(p => p.Name == nameof(Resource.Href))
    //                    ?.SetValue(model, rewritten.Href);

    //                allProperties
    //                    .SingleOrDefault(p => p.Name == nameof(Resource.Method))
    //                    ?.SetValue(model, rewritten.Method);

    //                allProperties
    //                    .SingleOrDefault(p => p.Name == nameof(Resource.Relations))
    //                    ?.SetValue(model, rewritten.Relations);
    //            }
    //        }

    //        var arrayProperties = allProperties.Where(p => p.PropertyType.IsArray);
    //        RewriteLinksInArrays(arrayProperties, model, rewriter);

    //        var objectProperties = allProperties
    //            .Except(linkProperties)
    //            .Except(arrayProperties);
    //        RewriteLinksInNestedObjects(objectProperties, model, rewriter);
    //    }

    //    private static void RewriteLinksInNestedObjects(
    //        IEnumerable<PropertyInfo> objectProperties,
    //        object model,
    //        LinkRewriter rewriter) {
    //        foreach (var objectProperty in objectProperties) {
    //            if (objectProperty.PropertyType == typeof(string)) {
    //                continue;
    //            }

    //            var typeInfo = objectProperty.PropertyType.GetTypeInfo();
    //            if (typeInfo.IsClass) {
    //                RewriteAllLinks(objectProperty.GetValue(model), rewriter);
    //            }
    //        }
    //    }

    //    private static void RewriteLinksInArrays(
    //        IEnumerable<PropertyInfo> arrayProperties,
    //        object model,
    //        LinkRewriter rewriter) {

    //        foreach (var arrayProperty in arrayProperties) {
    //            var array = arrayProperty.GetValue(model) as Array ?? new Array[0];

    //            foreach (var element in array) {
    //                RewriteAllLinks(element, rewriter);
    //            }
    //        }
    //    }

    //}


    public class LinkRewritingFilter : IAsyncResultFilter {
        private IUrlHelperFactory _urlHelperFactor;
        public LinkRewritingFilter(IUrlHelperFactory urlHelperFactor) {
            _urlHelperFactor = urlHelperFactor;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next) {
            var asObjRes = context.Result as ObjectResult;
            bool shouldSkip = asObjRes?.Value == null || asObjRes?.StatusCode != (int)HttpStatusCode.OK;
            if (shouldSkip) {
                await next();
                return;
            }

            var rewriter = new LinkRewriter(_urlHelperFactor.GetUrlHelper(context));
            ReWriteAllLinks(asObjRes.Value, rewriter);

            await next();
        }

        private static void ReWriteAllLinks(object model, LinkRewriter rewriter) {
            if (model == null) return;

            var allprops = model.GetType().GetTypeInfo()
                .GetAllProperties()
                .Where(p => p.CanRead)
                .ToArray();
            var linkProperties = allprops
                .Where(p => p.CanWrite && p.PropertyType == typeof(Link));

            foreach (var linkProp in linkProperties) {
                var rewrittern = rewriter.Rewrite(linkProp.GetValue(model) as Link);
                if (rewrittern == null) continue;

                linkProp.SetValue(model, rewrittern);

                //special handling of the hidden self property
                if (linkProp.Name == nameof(Resource.Self)) {
                    allprops.SingleOrDefault(p => p.Name == nameof(Resource.Href))?.SetValue(model, rewrittern.Href);
                    allprops.SingleOrDefault(p => p.Name == nameof(Resource.Method))?.SetValue(model, rewrittern.Method);
                    allprops.SingleOrDefault(p => p.Name == nameof(Resource.Relations))?.SetValue(model, rewrittern.Relations);
                }
            }

            var arrayProps = allprops.Where(p => p.PropertyType.IsArray);
            RewriteLinksInArrays(arrayProps, model, rewriter);

            var objectProps = allprops.Except(linkProperties).Except(arrayProps);
            RewriteLinksInNestedObjects(objectProps, model, rewriter);

        }

        private static void RewriteLinksInArrays(IEnumerable<PropertyInfo> arrayProps, object obj, LinkRewriter rewriter) {
            foreach (var arrayProp in arrayProps) {
                var array = arrayProp.GetValue(obj) as Array ?? new Array[0];
                foreach (var el in array) {
                    ReWriteAllLinks(el, rewriter);
                }
            }
        }
        public static void RewriteLinksInNestedObjects(IEnumerable<PropertyInfo> objProps, object obj, LinkRewriter rewriter) {
            foreach (var objProp in objProps) {
                if (objProp.PropertyType == typeof(string)) {
                    continue;
                }

                var typeinfo = objProp.PropertyType.GetTypeInfo();
                if (typeinfo.IsClass) {
                    ReWriteAllLinks(objProp.GetValue(obj), rewriter);
                }
            }
        }
    }
}
