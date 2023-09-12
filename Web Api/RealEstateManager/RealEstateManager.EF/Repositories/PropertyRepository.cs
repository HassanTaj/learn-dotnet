using RealEstateManager.EF.Context;
using RealEstateManager.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateManager.EF.Repositories {
    public class PropertyRepository : IPropertyRepository {
        private RealEstateContext _ctx;
        public PropertyRepository(RealEstateContext ctx) {
            _ctx = ctx;
        }

        public Property Add(Property obj) {
            _ctx.Add(obj);
            _ctx.SaveChanges();
            return obj;
        }

        public IEnumerable<Property> GetAll() {
            return _ctx.Properties;
        }

        public Property GetById(int id) {
            return _ctx.Properties.SingleOrDefault(x => x.Id==id);
        }
    }
}
