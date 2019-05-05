using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Donde.SpokenPast.Web.Controllers
{
    [ApiVersion("1.0")]
    [ODataRoutePrefix("Home")]

    public class HomeController : ODataController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return new JsonResult(new { String = "Whaddup" });
        }
    }
}