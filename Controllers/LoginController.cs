using System.Security.Claims;
using System.Data.Common;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using TurnoProyecto.Models;
using TurnoProyecto.Models.ViewModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace TurnoProyecto.Controllers;

    public class LoginController : Controller
    {
        // GET: Acceso
    private readonly TurnoContext db;
    

    public LoginController(TurnoContext param)
    {
        db = param;
    }
    public ActionResult Index()
    {   if(User.Identity.IsAuthenticated){
        return Redirect("/Home");
        }
        else{
            return View();
        }
           
    }
        public ActionResult IndexS()
    {   if(User.Identity.IsAuthenticated){
        return Redirect("/Home");
        }
        else{
            return View();
        }
           
    }

    [BindProperty]
    public UsuariosVM usuarios {get;set;}
        
        public async Task<IActionResult> Login()
        {
            if(!ModelState.IsValid){
                return BadRequest(new JObject(){
                    {"StatusCode", 400},
                    {"Messaje","Error"}
                });
            }
            else
            {
                var result = await db.UserDb.Where(x => x.email == usuarios.email.Trim()).SingleOrDefaultAsync();

                if(   result == null ){
                    return NotFound(new JObject(){
                    {"StatusCode", 404},
                    {"Messaje","usuario no encontrado"}
                });
                }
                else
                {
                    if(usuarios.password== result.password.Trim() ){
                        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme,ClaimTypes.Email,ClaimTypes.Role);
                        identity.AddClaim(new Claim (ClaimTypes.NameIdentifier,result.userid.ToString()));
                        identity.AddClaim(new Claim(ClaimTypes.Name, result.nombre));
                        identity.AddClaim(new Claim(ClaimTypes.Email, result.email));
                        identity.AddClaim(new Claim("profesion", result.Profesion));
                        identity.AddClaim(new Claim(ClaimTypes.Role, result.role));
                        var principal = new ClaimsPrincipal(identity);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { ExpiresUtc = DateTime.Now.AddHours(1), IsPersistent = true});
                        return Ok(result);
                    }
                    else
                    {
                        return StatusCode(403);
                    }
                }
            }
            return View();
        }
         [BindProperty]
    public UsuariosVM usuario {get;set;}
        
        public async Task<IActionResult> LoginS()
        {
            if(!ModelState.IsValid){
                return BadRequest(new JObject(){
                    {"StatusCode", 400},
                    {"Messaje","Error"}
                });
            }
            else
            {
                var result = await db.UserSDb.Where(x => x.email == usuario.email.Trim()).SingleOrDefaultAsync();

                if(   result == null ){
                    return NotFound(new JObject(){
                    {"StatusCode", 404},
                    {"Messaje","usuario no encontrado"}
                });
                }
                else
                {
                    if(usuario.password== result.password.Trim() ){
                        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme,ClaimTypes.Email,ClaimTypes.Role);
                        identity.AddClaim(new Claim (ClaimTypes.NameIdentifier,result.userid.ToString()));
                        identity.AddClaim(new Claim(ClaimTypes.Name, result.nombre));
                        identity.AddClaim(new Claim(ClaimTypes.Email, result.email));
                        identity.AddClaim(new Claim(ClaimTypes.Role, result.role));
                        var principal = new ClaimsPrincipal(identity);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { ExpiresUtc = DateTime.Now.AddHours(1), IsPersistent = true});
                        return Ok(result);
                    }
                    else
                    {
                        return StatusCode(403);
                    }
                }
            }
            return View();
        }
        public async Task<IActionResult> Logout(){
            HttpContext.SignOutAsync();
            return Redirect("/Home");
        }
    }
