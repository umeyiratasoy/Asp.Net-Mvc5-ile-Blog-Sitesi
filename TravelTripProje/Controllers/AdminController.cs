using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;
using PagedList;
using PagedList.Mvc;


namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        Context c = new Context();
        
        // GET: Admin

        [Authorize]
        public ActionResult Index(int p = 1)
        {
            var degerler = c.Blogs.OrderByDescending(x => x.Id).ToList().ToPagedList(p, 5);
            return View(degerler);
        }

        [Authorize]
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult BlogGetir(int id)
        {
            var bl = c.Blogs.Find(id);
            return View("BlogGetir", bl);
        }

        [Authorize]
        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = c.Blogs.Find(b.Id);
            blg.Aciklama = b.Aciklama;
            blg.Baslik = b.Baslik;
            blg.BlogImage = b.BlogImage;
            blg.Tarih = b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult YorumListesi(int p = 1)
        {
            var yorumlar = c.Yorumlars.OrderByDescending(x => x.ID).ToList().ToPagedList(p, 5);
            return View(yorumlar);
        }

        [Authorize]
        public ActionResult YorumSil(int id)
        {
            var b = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(b);
            c.SaveChanges();
            return RedirectToAction("/YorumListesi/");
        }

        [Authorize]
        public ActionResult YorumGetir(int id)
        {
            var yr = c.Yorumlars.Find(id);
            return View("YorumGetir", yr);
        }

        [Authorize]
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = c.Yorumlars.Find(y.ID);
            yrm.KullaniciAdi = y.KullaniciAdi;
            yrm.Mail = y.Mail;
            yrm.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("/YorumListesi/");
        }




        [Authorize]
        public ActionResult HakkimizdaList()
        {

            var hakkimizda = c.Hakkimizdas.Take(1).ToList();
            return View(hakkimizda);
        }


        [Authorize]
        public ActionResult HakkimizdaGetir(int id)
        {
            var hk = c.Hakkimizdas.Find(id);
            return View("HakkimizdaGetir", hk);
        }

        [Authorize]
        public ActionResult HakkimizdaGuncelle(Hakkimizda h)
        {
            var hkm = c.Hakkimizdas.Find(h.ID);
            hkm.FotoUrl = h.FotoUrl;
            hkm.Aciklama = h.Aciklama;
            c.SaveChanges();
            return RedirectToAction("/HakkimizdaList/");
        }

        [Authorize]
        public ActionResult IletisimList(int p = 1)
        {
            var iletisim = c.İletisims.OrderByDescending(x => x.ID).ToList().ToPagedList(p, 5);
            return View(iletisim);
        }

        [Authorize]
        public ActionResult IletisimSil(int id)
        {
            var i = c.İletisims.Find(id);
            c.İletisims.Remove(i);
            c.SaveChanges();
            return RedirectToAction("/IletisimList/");
        }


    }
}