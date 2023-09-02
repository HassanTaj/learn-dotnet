using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Pattern {
    /// <summary>
    /// The 'ConcreteElement' class
    /// </summary>
    class Employee : Element{
        private string _name;

        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        private double _income;

        public double Income {
            get { return _income; }
            set { _income = value; }
        }
        private int _vacationDays;

        public int VacationDays {
            get { return _vacationDays; }
            set { _vacationDays = value; }
        }

        // constructor 
        public Employee(string name,double income, int vacationdays) {
            _name = name;
            _income = income;
            _vacationDays = vacationdays;
        }

        public override void Accept(IVisitor visitor) {
            visitor.Visit(this);
        }
    }
}