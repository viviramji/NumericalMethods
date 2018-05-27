using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using MetodosNumericosFinal.Models;

namespace MetodosNumericosFinal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(Session["tableSimpson"] == null)
            {
                List<Simpson> results = new List<Simpson>();
                Session["tableSimpson"] = results;
            }
            return View();
        }

        public ActionResult IntegracionForm()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Integracion(element _in)
        {
            ModelFacade facade = new ModelFacade();
            List<Simpson> table = (List<Simpson>)Session["tableSimpson"];
            table = facade.getResult(_in);
            Session["tableSimpson"] = table;
            return Json(new { msg = "ok" });
        }


        [HttpGet]
        public async Task<ActionResult> getTableSimpson()
        {
            return PartialView("tableResultPartial", Session["TableSimpson"]);
        }

    }
}