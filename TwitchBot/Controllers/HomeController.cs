using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using TwitchBot.Models;
using TwitchBot.Models.TwitchLibrary;
using TwitchLib.Client;

namespace TwitchBot.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		// GET: Accounts
		public async Task<ActionResult> Index()
		{
			return View(await db.Accounts.ToListAsync());
		}

		[HttpPost]
		public void StartStop(Account account)
		{
			//string securedInfo = "Started";
			var foundAccount = db.Accounts.FirstOrDefaultAsync(x => x.ChannelName == account.ChannelName);
			//return securedInfo;
		}

		//public ActionResult Index()
		//      {
		//          ConnectionCredentials credentials = new ConnectionCredentials("digitalexa", "5eg2y99btp80sr5wo449is6n44xx24");
		//          TwitchClient client = new TwitchClient();
		//          client.Initialize(credentials, "digitalexa");
		//          client.OnJoinedChannel += Client_OnJoinedChannel;
		//          client.OnLeftChannel += Client_OnLeftChannel;
		//          client.Connect();

		//          return View();
		//      }

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

		public async Task<ActionResult> Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Account account = await db.Accounts.FindAsync(id);
			if (account == null)
			{
				return HttpNotFound();
			}
			return View(account);
		}

		// GET: Accounts/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Accounts/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create([Bind(Include = "Id,ChannelName,TwitchOAuth,IsEnabled")] Account account)
		{
			if (ModelState.IsValid)
			{
				db.Accounts.Add(account);
				await db.SaveChangesAsync();
				return RedirectToAction("Index");
			}

			return View(account);
		}

		// GET: Accounts/Edit/5
		public async Task<ActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Account account = await db.Accounts.FindAsync(id);
			if (account == null)
			{
				return HttpNotFound();
			}
			return View(account);
		}

		// POST: Accounts/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit([Bind(Include = "Id,ChannelName,TwitchOAuth,IsEnabled")] Account account)
		{
			if (ModelState.IsValid)
			{
				db.Entry(account).State = EntityState.Modified;
				await db.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View(account);
		}

		// GET: Accounts/Delete/5
		public async Task<ActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Account account = await db.Accounts.FindAsync(id);
			if (account == null)
			{
				return HttpNotFound();
			}
			return View(account);
		}

		// POST: Accounts/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteConfirmed(int id)
		{
			Account account = await db.Accounts.FindAsync(id);
			db.Accounts.Remove(account);
			await db.SaveChangesAsync();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}