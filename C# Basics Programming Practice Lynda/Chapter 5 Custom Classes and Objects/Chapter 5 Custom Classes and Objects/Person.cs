using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_5_Custom_Classes_and_Objects
{
    class Person
    {
        // defining a class
        //// lees degined class
        private string name;
        public string nameshit
        {
            get { return name; }
            set { name = value; }
        }

        private int age;

        public int ageshit
        {
            get { return age; }
            set { age = value; }
        }

        private bool isFucked;
        public bool isFuckedF
        {
            get { return isFucked; }
            set { isFucked = value; }
        }
        
        public Person()
        {

        }
        public Person(string enteredName, int enteredAge, bool enteredisFucked)
        {
            this.name = enteredName;
            this.age = enteredAge;
            this.isFucked = enteredisFucked;
        }
    }
}
