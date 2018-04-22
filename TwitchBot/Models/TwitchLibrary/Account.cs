using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TwitchBot.Models.TwitchLibrary
{
    public class Account
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Channel name")]
        public string ChannelName { get; set; }

        [DisplayName("Twitch OAuth")]
        public string TwitchOAuth { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool IsEnabled { get; set; }
    }
}