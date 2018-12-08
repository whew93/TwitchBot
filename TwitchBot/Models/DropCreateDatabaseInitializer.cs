using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TwitchBot.Models.TwitchLibrary;

namespace TwitchBot.Models
{
	public class DropCreateDatabaseInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
	{
		protected override void Seed(ApplicationDbContext context)
		{
			context.Accounts.Add(new Account() { ChannelName = "diGitaLexa", TwitchOAuth = "5eg2y99btp80sr5wo449is6n44xx24" });
			context.SaveChanges();
		}
	}
}