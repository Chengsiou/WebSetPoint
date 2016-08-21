using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace SetPoint.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var uid = "hh4854@gmail.com";
            var pointDic = await DAO.AccountDAO.GetAccountPoint(uid);
            //ViewBag.Name = "XXXX";
            var query = Request.Url.Query;
            var shop = Request.QueryString["shop"];
            //var point = pointname[shop];
            //ViewBag.shop = shop;
            if (shop != null)
            {
                ViewBag.shop = shopname[shop];
                ViewBag.point = pointDic[shop];
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

        public async Task<ActionResult> Welcome()
        {
            var uid = "hh4854@gmail.com";
            var result = await DAO.AccountDAO.GetAccountPoint(uid);
            //ViewBag.Message = "Your point score.~!!";
            foreach (KeyValuePair<string,string> kvp in result)
            {
                ViewBag.Message += shopname[kvp.Key] + " 點數:";
                ViewBag.Message += result[kvp.Key] + "newline newline";
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