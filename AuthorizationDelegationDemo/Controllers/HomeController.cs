using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using Microsoft.SharePoint.Client;

namespace AuthorizationDelegationDemo.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowWebTitle()
        {
            string siteUrl = ConfigurationManager.AppSettings["SiteUrl"];

            string signedInUserID = ClaimsPrincipal.Current.FindFirst(ClaimTypes.NameIdentifier).Value;

            string accessToken = Startup.AccessTokenCache.GetItem(signedInUserID) as string;

            if (String.IsNullOrEmpty(accessToken) == false)
            {
                using (ClientContext ctx = new ClientContext(siteUrl))
                {
                    ctx.ExecutingWebRequest += (sender, args) =>
                    {
                        args.WebRequestExecutor.RequestHeaders["Authorization"] = "Bearer " + accessToken;
                    };

                    Web web = ctx.Web;
                    ctx.Load(web, w => w.Title, w => w.Url);
                    ctx.ExecuteQueryRetry();

                    ViewBag.WebTitle = web.Title;
                    ViewBag.WebUrl = web.Url;
                }
            }

            return View();
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