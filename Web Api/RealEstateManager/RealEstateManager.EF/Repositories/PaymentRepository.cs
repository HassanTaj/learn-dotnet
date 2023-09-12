using RealEstateManager.EF.Context;
using RealEstateManager.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RealEstateManager.EF.Repositories {
    public class PaymentRepository : IPaymentRepository {
        private RealEstateContext _ctx;
        public PaymentRepository(RealEstateContext ctx) {
            _ctx = ctx;
        }
        public IEnumerable<Payment> GetAllForProperty(int id) {
            return _ctx.Payments.Where(x => x.PropertyId == id);
        }

        public IEnumerable<Payment> GetAllForProperty(int id, int lastAmount) {
            return _ctx.Payments.Where(x => x.PropertyId == id)
                .OrderBy(X => X.DateCreated)
                .Take(lastAmount);
        }
    }
}
