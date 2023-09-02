using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Pattren {
    public class Policy {
        // for thread safty 
        //  private static readonly Object _lock = new Object();

        // a better metod for thread safty
        private static readonly Policy _instance = new Policy();
        // 
        //private static Policy _instance;
        public static Policy Instance {
            get {
                // a popular approach
                //lock(_lock)
                // 
                // a better way let the CLR handle it 

                // if the instance is null create a new one
                // else return the current instance
                //if (_instance == null) {
                //    _instance = new Policy();
                //}
                return _instance;
            }
        }

        public Policy() {

        }
        private int Id { get; set; } = 123;
        private string Insured { get; set; } = "Jhon Roy";
        public string GetInsuredName() => Insured;
    }
}
