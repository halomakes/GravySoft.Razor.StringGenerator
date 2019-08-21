using GravySoft.Razor.StringGenerator.NetFramework;
using NetFrameworkDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NetFrameworkDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        public async Task<ActionResult> Email()
        {
            var renderer = new RazorViewToStringRenderer();
            var text = await renderer.RenderViewToStringAsync("~/Views/Email.cshtml", new EmailModel
            {
                FirstName = "John",
                LastName = "Doe",
                FavoriteColors = new List<string> { "Red", "Purple", "Orange" }
            });
            return Content(text, "text/html");
        }
    }
}