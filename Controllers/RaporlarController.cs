using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace MvcApplication1.Controllers
{
    public class RaporlarController : Controller
    {
        kutuphaneEntities3 db = new kutuphaneEntities3();

        //
        // GET: /Raporlar/

        public ActionResult Index(String tc, String isbn)
        {

            ViewBag.tc = tc;
            ViewBag.isbn = isbn;
                return View(db.emanet_tbl);
       
        
        }

        public ActionResult ExportData(String isbn,String tc)
        {
            
            GridView gv = new GridView();
            gv.DataSource = db.emanet_tbl.ToList();
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Raporlar.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return RedirectToAction("Index","Raporlar");
        }

    }
}
