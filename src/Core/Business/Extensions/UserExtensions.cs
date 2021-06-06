using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;
using Entity.Enum;

namespace Business.Extensions
{
   public static class UserExtensions
    {

        public static string GetUserId(this ClaimsPrincipal principal)
        {      
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirst(ClaimTypes.Name).Value;
        }        
        public static string GetRole(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));
            return principal.FindFirst(ClaimTypes.Role).Value;
        }        
        public static bool IsInNONERole(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));
            var role = principal.GetRole();
            return role == Role.None;
        }

    }
}
