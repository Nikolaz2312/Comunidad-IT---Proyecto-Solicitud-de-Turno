using System;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Security.Principal;
namespace TurnoProyecto.Helper
{
    public class SessionHelper
    {
        public static string GetValue(IPrincipal User, string Property)
        {  
           
            var r = ((ClaimsIdentity)User.Identity).FindFirst(Property);
            return r == null ? "": r.Value;
        }
        public static string GetNameIdentifier(IPrincipal User){
            var r = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier);
            return r == null ? "": r.Value;
        }
         public static string GetEmail(IPrincipal User){
            var r = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Email);
            return r == null ? "": r.Value;
        }
          public static string GetRole(IPrincipal User){
            var r = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Role);
            return r == null ? "": r.Value;
        }
    }
}