using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using MNproject.Models;
using MNproject.Models.Classes;

namespace MNproject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["tableSimpson"] == null)
            {
                List<Simpson> table = new List<Simpson>();
                Session["tableSimpson"] = table;
            }
            return View();
        }

        public ActionResult integrationForm()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Integration(Parameter _in)
        {
            ViewBag.n = int.Parse(_in.n);
            ViewBag.a = double.Parse(_in.a, CultureInfo.InvariantCulture);
            ViewBag.b = double.Parse(_in.b, CultureInfo.InvariantCulture);
            ViewBag.h = (ViewBag.b - ViewBag.a) / ViewBag.n;
            ModelFacade facade = new ModelFacade();
            List<Simpson> table = (List<Simpson>)Session["tableSimpson"];
            table = facade.getResult(_in);
            Session["tableSimpson"] = table;
            return Json(new { msg = "ok" });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> getTableSimpson()
        {
            return PartialView("tableResultPartial", Session["TableSimpson"]);
        }
    }
}