using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroBolt.Stock.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Bolts")]
    public class BoltsController : Controller
    {
    }
}