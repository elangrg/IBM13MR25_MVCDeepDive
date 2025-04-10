using IBM13MR25_MVCDeepDive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IBM13MR25_MVCDeepDive.Controllers
{
    public class ModelBinderEgController : Controller
    {
        // GET: ModelBinderEg/index
        public ActionResult Index()
        {
            return View(new Models.BookTitle());
        }

        [HttpPost]
        public ActionResult Index(Models.BookTitle Book)
        {
            string st = this.Request.Form.Get("Day");

            if (ModelState.IsValid)
            {

            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        // primitive Type 
        [HttpPost]
        // 
        public ActionResult Create(FormCollection demo, [Bind(Prefix = "chksource")] List<string> xyz, string[] chksource)
        {
            return View();
        }


        public ActionResult AddEmployee()
        {
            return View(new Models.Employee());

        }

        //[HttpPost]
        // 
        //public ActionResult AddEmployee(string emp)
        //{
        //    Models.Employee objone = new Models.Employee();

        //    this.UpdateModel(objone);



        //    return View();

        //}
        [HttpPost]
        // 
        public ActionResult AddEmployee(Models.Employee emp, FormCollection col, string EmpName, [Bind(Exclude = "EmpID,EmpName")] Models.Employee objemp, [Bind(Include = "EmpID,EmpName")] Models.Employee objemp3)
        {


            if (ModelState.IsValid)
            {
                Models.Employee objone = new Models.Employee();

                this.UpdateModel(objone);
            }





            return View();

        }

    }
}