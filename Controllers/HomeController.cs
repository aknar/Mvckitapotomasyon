using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
        
    public class HomeController : Controller
    {

        kutuphaneEntities3 db = new kutuphaneEntities3();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var kitap = db.kitap_tbl.Select(w => w.id).ToList();
            var okur = db.okur_tbl.Select(w => w.id).ToList();
            var toplamemanet = db.emanet_tbl.Select(w => w.id).ToList();
            var verilenemanetsayisi = db.emanet_tbl.Where(w => w.durum =="pasif").ToList();
            var alinanemanetsayisi = db.emanet_tbl.Where(w => w.durum == "aktif").ToList();
            ViewBag.okursayisi = okur.Count;
            ViewBag.kitapsayisi = kitap.Count;
            ViewBag.toplamemanet = toplamemanet.Count;
            ViewBag.verilenemanetsayisi = verilenemanetsayisi.Count;
            ViewBag.alinanemanetsayisi = alinanemanetsayisi.Count;

            ViewBag.verilebilecekemanet = kitap.Count - verilenemanetsayisi.Count;

            return View();
        }

    }
}
