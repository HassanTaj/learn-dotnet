using GraphQL.Types;
using RealEstateManager.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace RealEstateManager.Graph.Types {
    public class PaymentType : ObjectGraphType<Payment> {
        public PaymentType() {
            Field(x => x.Id);
            Field(x => x.Value);
            Field(x => x.DateCreated);
            Field(x => x.DateOverDue);
            Field(x => x.Paid);
        }
    }
}
