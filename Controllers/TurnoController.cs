
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurnoProyecto.Models;
using Microsoft.AspNetCore.Authorization;

namespace TurnoProyecto.Controllers;

public class TurnoController : Controller
{   
    private readonly TurnoContext db;
    

    public TurnoController(TurnoContext param)
    {
        db = param;
    }
[Authorize(Roles = "Profesional,Administrador")]
    public IActionResult Mostrar(){

        ViewData["nturno"] = db.NTurnoDb.ToList();
       
            return View("Mostrar",db.TurnoDb.Include( x =>x.UserModelDatos).ToList());
        }
        [Authorize(Roles = "Profesional,Administrador")]
    public IActionResult CCDT(){
            UserModelDatos user = new UserModelDatos();
            ViewBag.Mostrar = db.UserDb.ToList();
            ViewBag.Mostrar = user;
            

            return View("CCDT",db.NTurnoDb.Include( x =>x.turnoModelDatos).Include(y =>y.turnoModelDatos.UserModelDatos).ToList());
        }
        [Authorize(Roles = "Usuario,Administrador")]
     public IActionResult CCDTU(string userid){

            UserModelDatos user = new UserModelDatos();
            ViewBag.datosAux = userid; 
           
            ViewBag.Mostrar = db.UserDb;
            ViewBag.Mostrar = user;
            

            return View("CCDTU",db.NTurnoDb.Include( x =>x.turnoModelDatos).Include(y =>y.turnoModelDatos.UserModelDatos).ToList());
        }
    
    
    [Authorize(Roles = "Profesional,Administrador")]
    public IActionResult Añadir(string userid){
        //recuperar el usuario de la base de datos con id = userid y mandarlo a al vista.
        
       
       
        return View("Añadir", userid);
    }
     [Authorize(Roles = "Usuario,Administrador")]
    public async Task<IActionResult> Asignar(string userid, string turnoid){
       AsignarTurno asig = new AsignarTurno();
       asig.turnoid=int.Parse(turnoid);
       asig.userid=int.Parse(userid);
       db.AsignarDB.Add(asig);
       db.SaveChanges();

        
       
       
        return View("MiTurno",await db.AsignarDB.Include( x => x.UserModelDatos ).Include(x => x.TurnoModelDatos).Include(x => x.TurnoModelDatos.UserModelDatos).ToListAsync());
    }
     [Authorize(Roles = "Usuario,Administrador")]
    public async Task<IActionResult> MiTurno(string userid, string turnoid){
      
        ViewBag.datoAux = userid;
        
       
       
        return View("MiTurno", await db.AsignarDB.Include( x => x.UserModelDatos ).Include(x => x.TurnoModelDatos).Include(x => x.TurnoModelDatos.UserModelDatos).ToListAsync());
    }
    [Authorize(Roles = "Profesional,Administrador")]
      public IActionResult AñadirT(string turnoid){
        //recuperar el usuario de la base de datos con id = userid y mandarlo a al vista.
        
       
       
        return View("AñadirT", turnoid);
    }
/*    public IActionResult Eliminar(string userid){
        UserModelDatos user1 =new UserModelDatos();
        user1.id = int.Parse(userid);
        db.UserDb.Remove(user1);
        db.SaveChanges();
        return RedirectToAction("Index",db.UserDb.ToList());
    }

*/  
[Authorize(Roles = "Profesional,Administrador")]
    [HttpPost]

    public IActionResult Agregar(string profeid, string finicio,string ffin )
    {   
        TurnoModelDatos turno1 = new TurnoModelDatos();
        DateTime datos = Convert.ToDateTime(finicio);
         DateTime datos2 = Convert.ToDateTime(ffin);
        NumeroDeTurnoModelDatos nt = new NumeroDeTurnoModelDatos();
       
        turno1.aturno = datos;
        turno1.fturno = datos2;
        turno1.estado = 1;
        turno1.userid = int.Parse(profeid);
        db.TurnoDb.Add(turno1);
        db.SaveChanges();
    
        
        return RedirectToAction("Mostrar");
 
    }
    [Authorize(Roles = "Profesional,Administrador")]
     public IActionResult AgregarT(string turnoid, string cantidad)
    {   
      NumeroDeTurnoModelDatos cant = new NumeroDeTurnoModelDatos();
       
       cant.Disponible = int.Parse(cantidad);
       cant.turnoid = int.Parse(turnoid);
        cant.Ocupados = 0;
        db.NTurnoDb.Add(cant);
        db.SaveChanges();
        
        return RedirectToAction("CCDT");
 
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
