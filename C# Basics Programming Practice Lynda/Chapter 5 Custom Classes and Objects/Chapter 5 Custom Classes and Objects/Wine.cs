using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_5_Custom_Classes_and_Objects
{
   
    class Wine
    {
                                                     // access modigers 
        private string Name;
           // public decimal Price;
           // public string Description;

                                                    //  properties shit 
        private decimal discount;
        private int year;
        private string Apellation;
        private decimal wholesalePrice;
        private const decimal retailMarkup = 1.35m;

            //// test 1
            //public Wine(string wineName, decimal price)
            //{
            //    Name = wineName;
            //    Price = price;
            //    discount = 0.0m;
            //}
        ////////////////////////////////
        // defining properties bitch 
        /////////////////////////////

            // properties that are calculated on the fly 
        public decimal Price
        {
            get
            {
                return wholesalePrice * retailMarkup;
            }
            set
            {
                wholesalePrice = value;
            }
        }

        public string MenuDescription
        {
            // only a getter for this property, which is generated from private fields
            get { return year.ToString() + " " + Name + ", " + Apellation; }
        }

        public Wine(int y, string sName, string sApp, decimal wp)
        {
            Name = sName;
            year = y;
            Apellation = sApp;
            wholesalePrice = wp;
        }

    }
}
