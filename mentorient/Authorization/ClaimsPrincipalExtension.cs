using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace mentorient.Authorization
{
    public static class ClaimsPrincipalExtension
    {
        public static string GetFirstName(this ClaimsPrincipal principal)
        {
            var firstName = principal.Claims.SingleOrDefault(c => c.Type == MentorientClaimTypes.FirstName)?.Value;
            return firstName;
        }
    }
}