using AnimeListServer.Protos;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeListServer.Services {
    public class CustomerService: Customer.CustomerBase {
        public override Task<CustomerModel> GetCustomerInfo(CustomerInfoLookup request, ServerCallContext context) {
            CustomerModel res = new CustomerModel();
            res.FirstName = "fucker";

            return Task.FromResult(res);
            //return base.GetCustomerInfo(request, context);
        }
    }
}
