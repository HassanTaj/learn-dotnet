using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsingControlersAndViews
{
    public class dataProvider
    {
       public static List<string> getAllNames(){
            List<string> names = new List<string>();
            names.Add("waseem");
            names.Add("hassan");
            names.Add("salman");
            return names;
        }
    }
}