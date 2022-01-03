using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurnoProyecto.Models;

namespace TurnoProyecto.Controllers;

public class ProfController : Controller
{   
    private readonly TurnoContext db;
    

    public ProfController(TurnoContext param)
    {
        db = param;
    }

    public IActionResult Index()
    {
        /*UserModelDatos user1 = new UserModelDatos();
       
        //user1.id = 2;
        user1.email = "holasoy@gmial.com";
        user1.password = "12345";
        //db.UserDbSet.Add(user1); Agregar sin (user1.id) porque es autonumerico.
        //db.UserDbSet.Update(user1); Actualizar o editar.
        //db.UserDbSet.Remove(user1); Eliminar 
        db.UserDbSet.Add(user1);
        db.SaveChanges();
         UserModelDatos usuariomostrar = new UserModelDatos();
       IEnumerable<UserModelDatos> consultaUsuario =       
            from vUsuario in db.UserDbSet 
            where vUsuario.id==3
            select vUsuario;
            foreach (UserModelDatos item in consultaUsuario)
            {         
            usuariomostrar=item;
            }*/
        return View("Index",db.UserDb.ToList());
        
    }
    [Authorize(Roles = "Administrador")]

    public IActionResult Añadir(){
        return View();
    }
    

   
    public IActionResult Privacy()
    {
        return View();
    }
    [Authorize(Roles = "Administrador")]

    [HttpGet]
    public IActionResult Editar(string userid){
        //recuperar el usuario de la base de datos con id = userid y mandarlo a al vista.
        
       
       
        return View("Editar", userid);
    }
       public IActionResult Eliminar(string userid){
        UserModelDatos user1 =new UserModelDatos();
        user1.userid = int.Parse(userid);
        db.UserDb.Remove(user1);
        db.SaveChanges();
        return RedirectToAction("Index",db.UserDb.ToList());
    }
[Authorize(Roles = "Administrador")]

    [HttpPost]
    public IActionResult Editar(string userid, string email, string password,string nombre, string apellido,string dni, string fechadenac,string profesion){
        //recuperar el usuario de la base de datos con id = userid y mandarlo a al vista.
        UserModelDatos user1 = new UserModelDatos();
        
        DateTime datos = Convert.ToDateTime(fechadenac);
        int id = int.Parse(userid);
        user1.userid = id;
        user1.email = email;
        user1.password = password;
        user1.nombre = nombre;
        user1.dni = dni;
        user1.Profesion = profesion;
        user1.role = "Profesional";
        user1.apellido = apellido;
        user1.fechadenacimiento = datos;
        db.UserDb.Update(user1);
        db.SaveChanges();
        return RedirectToAction("Index",db.UserDb.ToList());
    }
    [Authorize(Roles = "Administrador")]

    public IActionResult Agregar(UserModelDatos user1)
    {
 
        
   
        user1.role = "Profesional";
     
        db.UserDb.Add(user1);
        db.SaveChanges();
        
        return RedirectToAction("Index",db.UserDb.ToList());
 
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
