using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.HelperMethods {
    public static class ModelExtension {
        public static IActionResult RedirectToLocal(this PageModel pageModel, string? returnUrl = null) {
            return pageModel.Url.IsLocalUrl(returnUrl) ? pageModel.LocalRedirect(returnUrl) : pageModel.RedirectToPage("../Index");
        }
    }
}
