using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IBM13MR25_MVCDeepDive.Controllers
{
    public class RazorIntroController : Controller
    {
        // GET: RazorIntro
        public ActionResult IndexSyntax()
        {
            return View();
        }

        public ActionResult SimpleContentPage()
        {
            return View();
        }
        public ActionResult NestedContentPage()
        {
            return View();
        }

    }
}