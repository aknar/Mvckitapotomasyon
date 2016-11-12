using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class KitaplarController : Controller
    {
       
          //
        // GET: /Kitaplar/
        kutuphaneEntities3 db = new kutuphaneEntities3();
    
        kitap_tbl kitap = new kitap_tbl();
        public ActionResult Index(int id=0 )
        {
            if (id!=0)
            {
                  var list1 = db.kitap_tbl.Where(w => w.id == id).ToList();
                 
                  ViewBag.ad = list1[0].ad;
                  ViewBag.yazar = list1[0].yazar;
                  ViewBag.sayfasayisi = list1[0].sayfasayisi;
                  ViewBag.yayinevi = list1[0].yayinevi;
                  ViewBag.basim_yili = list1[0].basim_yili;
                  ViewBag.kategori= list1[0].kategori;
                  ViewBag.isbnno= list1[0].isbnno;
                  ViewBag.aciklama = list1[0].aciklama;
                  ViewBag.id = list1[0].id;



            }
          

           

            return View(db.kitap_tbl);
        }
        public ActionResult Kitaplar(String isbn, String kitap_adi, String yazar, String yayin_evi, String basim_yili, String kategori, String aciklama, int sayfa_sayisi, String durum,int? id)
        {


            kitap_tbl mehmet = db.kitap_tbl.Find(id);
            

            if (mehmet!=null)
            {
                kitap_tbl guncelle = db.kitap_tbl.FirstOrDefault(x => x.id == id);
                guncelle.isbnno = isbn;
                guncelle.ad = kitap_adi;
                guncelle.yazar = yazar;
                guncelle.yayinevi = yayin_evi;
                guncelle.basim_yili = basim_yili;
                guncelle.kategori = kategori;
                guncelle.aciklama = aciklama;
                guncelle.sayfasayisi = sayfa_sayisi;
                db.SaveChanges();
            

                
            }
            else
            {

          
                String tarih1 = DateTime.Now.ToString("dd'.'MM'.'yyyy'.'HH'.'mm'.'ss");
                kitap.isbnno = isbn;

                kitap.ad = kitap_adi;
                kitap.yazar = yazar;
                kitap.yayinevi = yayin_evi;
                kitap.basim_yili = basim_yili;
                kitap.kategori = kategori;
                kitap.aciklama = aciklama;
                kitap.sayfasayisi = sayfa_sayisi;
                kitap.durum = "aktif";
                kitap.kayit_tarih = tarih1;
                db.kitap_tbl.Add(kitap);
             
                db.SaveChanges();
                 //Response.Write("<script>alert('kayıt başarılı');</script>");
            }


                return RedirectToAction("Index", "Kitaplar");
            
            
        }
        public ActionResult Delete(int id)
        {
            db.kitap_tbl.Remove(db.kitap_tbl.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index", "Kitaplar");


        }
      





    }
}
