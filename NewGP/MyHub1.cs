using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewGP
{
    public class MyHub1 : Hub
    {
        public void Send(string name, string msg)
        {
            Clients.All.addNewMessageToPage(name, msg);
        }
    }
}