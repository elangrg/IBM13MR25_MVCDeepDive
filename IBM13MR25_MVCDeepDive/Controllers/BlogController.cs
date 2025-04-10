using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IBM13MR25_MVCDeepDive.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public string Archive(DateTime? entryDate)
        {
            if (entryDate == null)
                return "Error";

            return entryDate.ToString();
        }
    }
}