using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace MyYouthFutures.Helpers
{
    /// <summary>
    ///  Menu current active item helper class.
    /// </summary>
    public static class MenuHelper
    {
        public static string IsSelected(this HtmlHelper html, string controller = null, string action = null)
        {
            
            const string cssClass = "current";
            var currentAction = (string) html.ViewContext.RouteData.Values["action"];
            var currentController = (string) html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            return controller == currentController && action == currentAction ? cssClass : String.Empty;

        }
    }
}
