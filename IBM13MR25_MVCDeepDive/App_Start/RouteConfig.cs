using IBM13MR25_MVCDeepDive.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing;
using System.Web.Routing;

namespace IBM13MR25_MVCDeepDive
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            #region Coustom Route
            var constraintsResolver = new DefaultInlineConstraintResolver();

            constraintsResolver.ConstraintMap.Add("Contains", typeof(Infra.ContainValuesConstraint));

            routes.MapMvcAttributeRoutes(constraintsResolver);
            #endregion

            //routes.MapMvcAttributeRoutes();


            routes.MapRoute(
          "DefaultNoAdmin",
          "{controller}/{action}/{id}",
          new { controller = "Home", action = "Index", id = "" },
          new { controller = new NotEqual("Admin") }
      );


            // HTTP Verb Constraint
            routes.MapRoute(
               "ProductInsert",
               "Product/Insert",
                new { controller = "Product", action = "Insert" },
                new { method = new HttpMethodConstraint("POST") }
           );


            // Regular Expression Constraint
            routes.MapRoute(
         name: "BlogArchive",
         url: "Archive/{entryDate}",
         defaults: new { controller = "Blog", action = "Archive" },
         constraints: new { entryDate = @"\d{2}-\d{2}-\d{4}" }

        );

            // Specific => Fixed Controller & Action (Sort=>Index)
            routes.MapRoute(
                "SortRoute",
                "Sortdemo/abc/xyz/{*values}", // *values=> Catch All Parameters
                new { controller = "sort", action = "Index" }
            );
            //General / Generic(Common for Multiple Controllers &Action)
                routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "ModelBinderEg", action = "index", id = UrlParameter.Optional }
                );
        }
    }
}
