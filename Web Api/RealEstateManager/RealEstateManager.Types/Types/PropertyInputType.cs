using GraphQL.Types;
using RealEstateManager.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateManager.Graph.Types {
    public class PropertyInputType : InputObjectGraphType {
        public PropertyInputType() {
            var p = new Property();
            Field<NonNullGraphType<StringGraphType>>($"{nameof(p.Name)}".ToLower());
            Field<StringGraphType>($"{nameof(p.City)}".ToLower());
            Field<StringGraphType>($"{nameof(p.Family)}".ToLower());
            Field<StringGraphType>($"{nameof(p.Street)}".ToLower());
        }
    }
}
