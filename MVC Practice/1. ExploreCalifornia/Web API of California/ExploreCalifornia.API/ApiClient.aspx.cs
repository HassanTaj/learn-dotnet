using ExploreCalifornia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExploreCalifornia.API {
    public partial class ApiClient : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            //var client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:44704");

            //var tour = new Tour() {Name="Added by Server side Code",Discription="Using HTTPClient",
            //    Length =10,IncludesMeals=false,Price= 3,Rating="Easy"};
            //client.PostAsJsonAsync("api/tour", tour);
        }
    }
}