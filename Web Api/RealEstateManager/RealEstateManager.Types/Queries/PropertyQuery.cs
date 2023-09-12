using GraphQL.Types;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RealEstateManager.EF.Repositories;
using RealEstateManager.Graph.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateManager.Graph.Queries {
    public class PropertyQuery : ObjectGraphType {
        public PropertyQuery(IPropertyRepository repo) {
            Field<ListGraphType<PropertyType>>("properties", resolve: ctx => repo.GetAll());
            Field<ListGraphType<PropertyType>>($"{nameof(Property)}".ToLower(),
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: ctx => repo.GetById(ctx.GetArgument<int>("id"))); ;
        }
    }
}
