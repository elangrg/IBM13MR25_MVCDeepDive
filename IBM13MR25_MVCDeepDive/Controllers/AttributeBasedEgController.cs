using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IBM13MR25_MVCDeepDive.Controllers
{
    [RoutePrefix("Demo")]
    [Route("{action=Index}")]
    public class AttributeBasedEgController : Controller
    {
        // GET: AttributeBasedConfig
        public ActionResult Index()
        {
            return View();
        }

        [Route("~/Users/about", Name = "demoname")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        // [Route("connect/{id?}")]
        [Route("connect/{id=12345}")]

        public ActionResult Contact(int? id)
        {
            ViewBag.Message = "Your contact page." + id.Value;

            return View();
        }


        [Route("Constr/{id:int}")]
        public string Employee(int id)
        {
            return $"<h1>Employee with id value {id} prm called </h1> ";
        }

        [Route("Constr/{name}/{demo?}")]
        public string Employee(string name, string demo)
        {
            return $"<h1>Employee with name & demo '{name}', '{demo}' prm called </h1> ";
        }

        [Route("Report/{prm:Contains(Month|Year|Day)}")]
        public string ReportByMonthOrYear(string prm)
        {
            return $"<h1>ReportByMonthOrYear called {prm} </h1>  ";
        }
    }
}