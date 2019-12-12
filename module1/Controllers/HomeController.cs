using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace module1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<String> strings = new List<string>();
            strings.Add("s1");
            strings.Add("s2");
            strings.Add("s3");

            ViewBag.Items = strings.ToArray();

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