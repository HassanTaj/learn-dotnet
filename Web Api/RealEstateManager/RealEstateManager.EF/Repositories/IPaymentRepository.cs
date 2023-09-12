using RealEstateManager.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateManager.EF.Repositories {
    public interface IPaymentRepository {
        IEnumerable<Payment> GetAllForProperty(int id);
        IEnumerable<Payment> GetAllForProperty(int id,int lastAmount);
    }
}
