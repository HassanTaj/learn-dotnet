using GraphQL.Types;
using RealEstateManager.EF.Models;
using RealEstateManager.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RealEstateManager.Graph.Types {
    public class PropertyType : ObjectGraphType<Property> {

        public PropertyType(IPaymentRepository paymentRepository) {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Value);
            Field(x => x.City);
            Field(x => x.Family);
            Field(x => x.Street);
            Field<ListGraphType<PaymentType>>($"{nameof(Payment)}s".ToLower(),
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name="last"}),
                resolve: context => {
                    var lastShit = context.GetArgument<int?>("last");

                    return lastShit != null ? 
                    paymentRepository.GetAllForProperty(context.Source.Id, lastShit.Value) :
                    paymentRepository.GetAllForProperty(context.Source.Id);
                });
        }
    }
}
