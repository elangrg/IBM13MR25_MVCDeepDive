using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IBM13MR25_MVCDeepDive.Controllers
{
    public class SortController : Controller
    {
        // GET: Sort
        public ActionResult Index(string values)
        {
            var brokenValues = values.Split('/');
            Array.Sort(brokenValues);
            return Content(String.Join(", ", brokenValues));
        }
    }
}