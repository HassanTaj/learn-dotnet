using LandonApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LandonApi.Infrastructure
{
    public static class FormMetadata
    {
        public static Form FromModel(object model, Link self)
        {
            var formFields = new List<FormField>();

            foreach (var prop in model.GetType().GetTypeInfo().DeclaredProperties)
            {
                var value = prop.CanRead
                    ? prop.GetValue(model)
                    : null;

                var attributes = prop.GetCustomAttributes().ToArray();

                var name = attributes.OfType<DisplayAttribute>()
                    .SingleOrDefault()?.Name
                    ?? prop.Name.ToCamelCase();

                var label = attributes.OfType<DisplayAttribute>()
                    .SingleOrDefault()?.Description;

                var required = attributes.OfType<RequiredAttribute>().Any();
                var secret = attributes.OfType<SecretAttribute>().Any();
                var type = GetFriendlyType(prop, attributes);

                var minLength = attributes.OfType<MinLengthAttribute>()
                    .SingleOrDefault()?.Length;
                var maxLength = attributes.OfType<MaxLengthAttribute>()
                    .SingleOrDefault()?.Length;

                formFields.Add(new FormField
                {
                    Name = name,
                    Required = required,
                    Secret = secret,
                    Type = type,
                    Value = value,
                    Label = label,
                    MinLength = minLength,
                    MaxLength = maxLength
                });
            }

            return new Form()
            {
                Self = self,
                Value = formFields.ToArray()
            };
        }

        public static Form FromResource<T>(Link self)
        {
            var allProperties = typeof(T).GetTypeInfo().DeclaredProperties.ToArray();
            var sortableProperties = allProperties
                .Where(p => p.GetCustomAttributes<SortableAttribute>().Any()).ToArray();
            var searchableProperties = allProperties
                .Where(p => p.GetCustomAttributes<SearchableAttribute>().Any()).ToArray();

            if (!sortableProperties.Any() && !searchableProperties.Any())
            {
                return new Form { Self = self };
            }

            var orderByOptions = new List<FormFieldOption>();
            foreach (var prop in sortableProperties)
            {
                var name = prop.Name.ToCamelCase();

                orderByOptions.Add(
                    new FormFieldOption { Label = $"Sort by {name}", Value = name });
                orderByOptions.Add(
                    new FormFieldOption { Label = $"Sort by {name} descending", Value = $"{name} desc" });
            }

            string searchPattern = null;
            if (searchableProperties.Any())
            {
                var applicableOperators = searchableProperties
                    .SelectMany(x => x
                        .GetCustomAttribute<SearchableAttribute>()
                        .ExpressionProvider.GetOperators())
                    .Distinct();

                var opGroup = $"{string.Join("|", applicableOperators)}";
                var nameGroup = $"{string.Join("|", searchableProperties.Select(x => x.Name.ToCamelCase()))}";

                searchPattern = $"/({nameGroup}) ({opGroup}) (.*)/i";
            }

            var formFields = new List<FormField>();
            if (orderByOptions.Any())
            {
                formFields.Add(new FormField
                {
                    Name = nameof(SortOptions<string, string>.OrderBy).ToCamelCase(),
                    Type = "set",
                    Options = orderByOptions.ToArray()
                });
            }

            if (!string.IsNullOrEmpty(searchPattern))
            {
                formFields.Add(new FormField
                {
                    Name = nameof(SearchOptions<string, string>.Search).ToCamelCase(),
                    Type = "set",
                    Pattern = searchPattern
                });
            }

            return new Form()
            {
                Self = self,
                Value = formFields.ToArray()
            };
        }

        private static string GetFriendlyType(PropertyInfo property, Attribute[] attributes)
        {
            var isEmail = attributes.OfType<EmailAddressAttribute>().Any();
            if (isEmail) return "email";

            var typeName = FormFieldTypeConverter.GetTypeName(property.PropertyType);
            if (!string.IsNullOrEmpty(typeName)) return typeName;

            return property.PropertyType.Name.ToCamelCase();
        }
    }
}
