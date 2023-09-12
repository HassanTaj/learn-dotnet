using RealEstateManager.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateManager.EF.Repositories {
    public interface IPropertyRepository {
        IEnumerable<Property> GetAll();
        Property GetById(int id);
        Property Add(Property obj);
    }
}
