using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class IletisimController : Controller
    {
        Context c = new Context();
        // GET: Iletisim
        public ActionResult Index()
        {
            var degerler = c.İletisims.ToList();
            return View(degerler);
        }


        [HttpGet]
        public ActionResult iletisim()
        {
            return View();
        }

        [HttpPost]
        public ActionResult iletisim(iletisim i)
        {
            c.İletisims.Add(i);
            c.SaveChanges();
            return RedirectToAction("/iletisim");
        }
    }
}