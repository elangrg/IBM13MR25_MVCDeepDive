using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IBM13MR25_MVCDeepDive.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            // View Result
            return View("demoIndex");
        }


        // Action Results 

        public string SayImpHi() // Content Result
        {
            return "Hi!!!";
        
        }

        public ContentResult SayExpHi() // Exp  Content Result
        {
            return Content( "Hi!!!");

        }

        public void SayNothing() // EmptyResult
        {
        
        }
       [NonAction]
        public string PublicButNotAction() 
        {
            return "PublicButNotAction Called";
        }

    }
}