using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.ApiProject.Controllers
{
    /// <summary/>
    [AllowAnonymous]
    public class HomeController : ControllerBase
    {
        /// <summary/>
        public ActionResult Index() => new RedirectResult("~/swagger");
    }
}
