using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Singleton_Pattren.Test {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void IsPolicyASingleton() {
            Assert.AreSame(Policy.Instance, Policy.Instance);
        }
    }
}
