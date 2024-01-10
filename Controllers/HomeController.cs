using Etkinlik_Takip_Sistemi.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Etkinlik_Takip_Sistemi.Controllers
{
    public class HomeController : Controller
    {
        private ActivityEntities db = new ActivityEntities();

        public ActionResult Hosgeldiniz()
        {
            return View();
        }
        public ActionResult Organizatorler()
        {
            // Organizatör bilgilerini veritabanından alabilir ve modele atayabilirsiniz
            // Örnek olarak, ViewData veya ViewBag kullanarak model oluşturabilirsiniz

            // Örnek model kullanımı:
            // var organizatorListesi = _veritabanindanOrganizatorleriGetir();
            // return View(organizatorListesi);

            List<Organizatorler> organizatorler = db.Organizatorlers
           .Include(o => o.Etkinliklers)  // Etkinliklers ilişkisini dahil et
           .ToList();

            return View(organizatorler);
            
        }

        public ActionResult Incele()
        {
            // Tüm incelemeleri al, Etkinlikler ilişkili tablosunu dahil et
            var incelemeler = db.Incelemelers
                .Include(i => i.Etkinlikler)
                .ToList();
            var etkinlikTurleri = db.Etkinliklers
    .       Include(t => t.EtkinlikTurleris) // İlişkili tabloyu dahil et
    .       ToList();
            // Etkinlik türlerini al
           
            // ViewBag'e EtkinlikTurleri'ni ekle
            ViewBag.EtkinlikTurleri = etkinlikTurleri;

            return View(incelemeler);
        }
        [Authorize]
        public ActionResult YorumPuanEkle(int? etkinlikID)
        {
            if (etkinlikID == null)
            {
                // Eğer etkinlikID null ise, bir hata durumu oluşturabilir veya kullanıcıyı başka bir sayfaya yönlendirebilirsiniz.
                // Örneğin:
                ViewBag.ErrorMessage = "Etkinlik bulunamadı.";
                return View("Error");
            }

            ViewBag.EtkinlikID = etkinlikID;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult YorumPuanEkle( string yorum, int puan)
        {
            int? etkinlikID = ViewBag.EtkinlikID as int?;
            if (etkinlikID == null)
            {
                // Eğer etkinlikID null ise, bir hata durumu oluşturabilir veya kullanıcıyı başka bir sayfaya yönlendirebilirsiniz.
                // Örneğin:
                ViewBag.ErrorMessage = "Etkinlik bulunamadı.";
                return View("Error");
            }

            // Veritabanına yorum ve puan ekleme işlemlerini gerçekleştir
            // Örneğin: db.Incelemelers.Add(new Incelemeler { EtkinlikID = etkinlikID, KullaniciID = User.Identity.GetUserId(), Yorum = yorum, Puan = puan });
            // db.SaveChanges();

            // Yorum ve puan ekledikten sonra sayfayı yönlendir
            return RedirectToAction("Incele");
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Etkinlik()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Etkinlik_List()
        {
            // Tüm etkinlikleri veritabanından al
            List<Etkinlikler> etkinlikler = db.Etkinliklers.ToList();

            // Görünüme etkinlikleri gönder
            return View(etkinlikler);

        }
        
    }
}