using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitchLib.Client;
using TwitchLib.Client.Models;

namespace TwitchBot.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ConnectionCredentials credentials = new ConnectionCredentials("digitalexa", "5eg2y99btp80sr5wo449is6n44xx24");
            TwitchClient client = new TwitchClient();
            client.Initialize(credentials, "digitalexa");
            client.OnJoinedChannel += Client_OnJoinedChannel;
            client.OnLeftChannel += Client_OnLeftChannel;
            client.Connect();

            return View();
        }

        private void Client_OnLeftChannel(object sender, TwitchLib.Client.Events.OnLeftChannelArgs e)
        {
            TwitchClient client = sender as TwitchClient;
            client?.Disconnect();
        }

        private void Client_OnJoinedChannel(object sender, TwitchLib.Client.Events.OnJoinedChannelArgs e)
        {
            TwitchClient client = sender as TwitchClient;
            client?.SendMessage(e.Channel, "Hello");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}