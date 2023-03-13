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
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            //var bloglar = c.Blogs.ToList();
            by.Deger3 = c.Blogs.OrderByDescending(x => x.Id).Take(3).ToList();
            by.Deger1 = c.Blogs.ToList();

            return View(by);

        }


        public ActionResult BlogDetay(int id)
        {

            //var blogbul = c.Blogs.Where(x => x.Id == id).ToList();
            
            by.Deger1 = c.Blogs.Where(x => x.Id == id).ToList();
            by.Deger2 = c.Yorumlars.Where(x => x.Blogid == id).ToList();
            return View(by);
        }

        public PartialViewResult SonBlog()
        {
            by.Deger3 = c.Blogs.OrderByDescending(x => x.Id).Take(3).ToList();
            return PartialView(by);
        }

        public PartialViewResult SonYorum()
        {
            by.Deger4 = c.Yorumlars.OrderByDescending(x => x.ID).Take(5).ToList();
            return PartialView(by);
        }

        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            c.Yorumlars.Add(y);
            c.SaveChanges();
            return PartialView();
        }

        public PartialViewResult Bloglar(int p = 1)
        {
            var deger5 = c.Blogs.OrderByDescending( x => x.Id).ToList().ToPagedList(p, 3);

            return PartialView(deger5);
        }
    }
}