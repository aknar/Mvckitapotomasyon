using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class UyeekleController : Controller
    {
        //
        // GET: /Uyeekle/
        kutuphaneEntities3 db = new kutuphaneEntities3();
        DateTime tarih1 = DateTime.Now;
        okur_tbl okur = new okur_tbl();
         public ActionResult Index(int id=0)
        {



            if (id != 0)
            {
                var list1 = db.okur_tbl.Where(w => w.id == id).ToList();

                ViewBag.tc = list1[0].tc;
                ViewBag.ad = list1[0].ad;
                ViewBag.soyad = list1[0].soyad;
                ViewBag.telefon = list1[0].telefon;
                ViewBag.adres = list1[0].adres;
                ViewBag.email = list1[0].email;
                ViewBag.cinsiyet = list1[0].cinsiyet;
                ViewBag.aciklama = list1[0].aciklama;
                ViewBag.id = list1[0].id;



            }
          
            return View(db.okur_tbl);
        }



         public ActionResult Uyeekle(String tc, String telefon, String ad, String soyad, String adres, String aciklama, String email, String cinsiyet  , String durum, int? id)
        {
            okur_tbl guncelle_id = db.okur_tbl.Find(id);

             if(guncelle_id != null)
             {


                 okur_tbl guncelle = db.okur_tbl.FirstOrDefault (x => x.id == id);
                 guncelle.tc = tc;
                 guncelle.ad = ad;
                 guncelle.soyad = soyad;
                 guncelle.telefon = telefon;
                 guncelle.adres = adres;
                 guncelle.email = email;
                 guncelle.aciklama = aciklama;
                 
                 db.SaveChanges();


             }

             else { 

                 String tarih1 = DateTime.Now.ToString("dd'.'MM'.'yyyy'.'HH'.'mm'.'ss");
                 okur.tc = tc;
                 okur.ad = ad;
                 okur.soyad = soyad;
                 okur.telefon = telefon;
                 okur.adres = adres;
                 okur.email = email;
                 okur.aciklama = aciklama;
                 okur.cinsiyet = Request["cinsiyet"];
                 okur.durum = "aktif";
                 okur.tarih = tarih1;
                 db.okur_tbl.Add(okur);
                 db.SaveChanges();
             }
                 return RedirectToAction("Index", "Uyeekle");
        

           

        }
         public ActionResult Delete(int id)
        {
            db.okur_tbl.Remove(db.okur_tbl.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index", "Uyeekle");


        }
         public ActionResult Güncelle(int id)
         {

             var list1 = db.okur_tbl.Where(w => w.id == id).ToList();

             ViewBag.asd = id;
             return RedirectToAction("Index", "Uyeekle");
         }
 


    }
}
