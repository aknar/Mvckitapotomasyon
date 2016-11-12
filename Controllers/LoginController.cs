using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcApplication1.Controllers
{
    public class LoginController : Controller
    {

        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }


        kutuphaneEntities3 db = new kutuphaneEntities3();
        public ActionResult Login(String username, String password)
        {
             
            var list1 = db.admin_tbl.Where(w => w.ad == username && w.soyad == password).ToList();



            if (list1.Count == 1)
            {
                 return RedirectToAction("Index","Home");
            }

            else
            {
                return RedirectToAction("Index", "Login");
            }

        }





    }   

 
}
