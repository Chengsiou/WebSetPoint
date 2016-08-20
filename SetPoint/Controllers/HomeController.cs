using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SetPoint.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ViewBag.Name = "XXXX";
            var query = Request.Url.Query;
            var shop = Request.QueryString["shop"];
            //var point = pointname[shop];
            //ViewBag.shop = shop;
            if (shop != null)
            {
                ViewBag.shop = shopname[shop];
                ViewBag.point = pointname[shop];
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

        public ActionResult Welcome()
        {
            ViewBag.Message = "Your point score.~!!" + "<br/>";
            foreach (KeyValuePair<string,string> kvp in shopname)
            {
                ViewBag.Message += "<pre>" + kvp.Value + "<pre/>";
                ViewBag.Message += "<pre>" + pointname[kvp.Key] + "<pre/>";
            }
            //Response.Write(ViewBag.Message);
            return View();
        }

        public Dictionary<string, string> shopname = new Dictionary<string, string>
        {
            { "SE","商店名稱: Seven-Eleven" },
            { "FM","商店名稱: FamllyMart" },
            { "OK","商店名稱: OK-Market" },
            { "WS","商店名稱: Watsons" },
            { "CM","商店名稱: CosMed" }
        };

        public Dictionary<string, string> pointname = new Dictionary<string, string>
        {
            { "SE","點數: 12" },
            { "FM","點數: 5" },
            { "OK","點數: 20" },
            { "WS","點數: 11" },
            { "CM","點數: 30" }
        };

    }
}