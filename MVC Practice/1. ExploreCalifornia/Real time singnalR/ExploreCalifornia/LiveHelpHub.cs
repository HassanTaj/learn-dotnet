using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ExploreCalifornia {
    public class LiveHelpHub : Hub {


        public void CallerOrOther(string msg) {
            Clients.All.showCallerOrOthers(msg);
        }

        //Experiment Code
        public void SendMessage(string senderName, string message) {

            Clients.All.showMessage(senderName, message);

            Clients.Caller.showCallerOrOther(new HtmlString("<p class='msgSent' >sent at " + DateTime.Now.ToString("h:mm:tt") + "</p>").ToHtmlString());
            Clients.Others.showCallerOrOther(new HtmlString("<p class='msgRecieved' >recieved at " + DateTime.Now.ToString("h:mm:tt") + "</p>").ToHtmlString());
                
            //Clients.Caller.showMessage("system", "Sent At : " + DateTime.Now.ToString("h:mm:tt")); // this works fine
            //Clients.Others.showMessage("system", "Recieved At : " + DateTime.Now.ToString("h:mm:tt")); // this works fine
              
            //HtmlString myHtml = new HtmlString("<span style='color:#808080; text-align:right; margin-right:5px;'>sent at " + DateTime.Now.ToString("h:mm:tt") + "</span>");
            //Clients.Caller.showMessage(" ", myHtml.ToHtmlString());
        }




        // all the working Code
        //public void SendMessage(string senderName, string message) {
        //    Clients.All.showMessage(senderName, message);

        //    // to add clients to a group
        //      Groups.Add(Context.ConnectionId, "Employees");
        //   // then if you want to send a message to only members of employee group
        //      Clients.Group("Employees").showMessage(senderName, "This is a message for the Employees Group.");
        //  //  then if you want to send message to only the client who invoked this method
        //   // we can either do
        //        Clients.Client(Context.ConnectionId);

        //  //  or a shortcut

        //    Clients.Caller.showMessage("system", "Sent At : " + DateTime.Now.ToString("h:mm:tt")); // this works fine
        //  //  if you want to send message to everyone else  but not the caller you can use
        //      Clients.Others.showMessage("system", "recieved at: " + DateTime.Now.ToString("h:mm:tt"));
        //}
    }
}