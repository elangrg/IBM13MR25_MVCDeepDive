using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace IBM13MR25_MVCDeepDive.Infra
{

    public class NotEqual : IRouteConstraint
    {
        private string _value;

        public NotEqual(string value)
        {
            _value = value;
        }

        public bool Match
            (
                HttpContextBase httpContext,
                Route route,
                string parameterName,
                RouteValueDictionary values,
                RouteDirection routeDirection
            )
        {

           

            var paramValue = values[parameterName].ToString();
            return String.Compare(paramValue, _value, true) != 0;
        }

    }




    public class ContainValuesConstraint : IRouteConstraint
    {
        private readonly string[] validOptions;
        public ContainValuesConstraint(string options)
        {
            validOptions = options.Split('|');
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {

            object value;
            if (values.TryGetValue(parameterName, out value) && value != null)
            {
                return validOptions.Contains(value.ToString(), StringComparer.OrdinalIgnoreCase);
            }
            return false;
        }
    }

}