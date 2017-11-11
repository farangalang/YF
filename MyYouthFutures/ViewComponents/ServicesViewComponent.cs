using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyYouthFutures.ViewComponents
{
    public class ServicesViewComponent : ViewComponent
    {
                public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }

   }
}
