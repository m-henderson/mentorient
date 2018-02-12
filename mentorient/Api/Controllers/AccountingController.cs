using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace mentorient.Api.Controllers
{
   [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
   [Produces("application/json")]
   [Route("api/[controller]")]
   public class AccountingController : Controller
   {
      [HttpGet]
      public string Get()
      {
         return "test";
      }
   }
}
