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
                Session["evaluate"] = 0.0;
                Session["table"] = new List<Table>(); //stored Xi vs F(Xi)
                Session["resultBisection"] = "";
            }
            return View();
        }


        //integracion section
        public ActionResult integrationForm()
        {
            return View();
        }

        public ActionResult SimpsonResult()
        {
            ViewBag.data = (List<Table>)Session["tableBisection"];
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

        public ActionResult BisectionForm()
        {
            return View();
        }

        public JsonResult Bisection(Parameter _in)
        {
            ModelFacade facade = new ModelFacade();
            Session["table"] = facade.GetTable(_in);
            Session["resultBisection"] = facade.GetBisectionResult(_in);
            Session["data"] = new Data { fx = _in.fx, a = _in.a, b = _in.b, n = _in.n, t = _in.t };
            return Json(new { url = "BisectionResult" }); //redirectiona a una vista diferente
        }

        public ActionResult BisectionResult()
        {
            ViewBag.data = (List<Table>)Session["table"];
            return View();
        }

        //graph Secction
        public ActionResult GraphForm()
        {            
            return View();
        }

        public JsonResult Graph(Parameter _in)
        {
            ModelFacade facade = new ModelFacade();
            Session["table"] = facade.GetTable(_in);
            return Json(new { url = "GraphResult" });
        }

        public ActionResult GraphResult()
        {
            ViewBag.data = (List<Table>)Session["Table"];
            return View();
        }

        //evaluate
        public ActionResult EvaluateForm()
        {
            return View();
        }

        public JsonResult Evaluate(Parameter _in)
        {
            ModelFacade facade = new ModelFacade();
            Session["data"] = new Data { fx = _in.fx, a = _in.a};
            Session["evaluate"] = facade.GetEvaluacion(_in);
            return Json(new { url = "EvaluateResult" });
        }

        public ActionResult EvaluateResult()
        {
            return View();
        }

        //stuff
        public ActionResult About()
        {
            ViewBag.Message = "En esta aplicacion trabajaron.";
            return View();
        }        
    }
}