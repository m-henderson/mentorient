using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace mentorient.Api.Controllers
{
   [AllowAnonymous]
   [Produces("application/json")]
   [Route("api/[controller]")]
   public class HomeController : Controller
   {
      [HttpGet]
      public string Get()
      {
         return string.Empty;
      }
   }
}
