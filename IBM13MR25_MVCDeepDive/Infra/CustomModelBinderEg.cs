using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IBM13MR25_MVCDeepDive.Infra
{
    public class BookTitleCustomBinder : IModelBinder // alternate defaultmodelbinder override method 
    {
        public object BindModel(ControllerContext controllerContext,
                                ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;

            string title = request.Form.Get("Title");
            string day = request.Form.Get("Day");
            string month = request.Form.Get("Month");
            string year = request.Form.Get("Year");

            return new Models.BookTitle
            {
                Title = title,
                DateOfPurchase = day + "/" + month + "/" + year
            };
        }
    }
}