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
            if(Session["tableSimpson"] == null)
            {
                Session["data"] = new Data();
                Session["tableSimpson"] = new List<Simpson>();
                Session["resultSimpson"] = new Double();
            }
            return View();
        }

        public ActionResult integrationForm()
        {
            return View();
        }

        public ActionResult SimpsonResult()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Integration(Parameter _in)
        {          
            ModelFacade facade = new ModelFacade();
            List<Simpson> table = new List<Simpson>();  
            Session["tableSimpson"] = facade.GetSimpsonTable(_in); 
            Session["resultSimpson"] = facade.GetResultSimpson(_in);
            Session["data"] = new Data { fx = _in.fx, a = _in.a, b = _in.b, n = _in.n };   
            
            return Json(new { url = "SimpsonResult"});
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }        
    }
}