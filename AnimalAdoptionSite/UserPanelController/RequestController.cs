using System;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace AnimalAdoptionSite.Controllers
{
    public class RequestController : Controller
    {
        RequestManager rm = new RequestManager(new EfRequestDal());
        AnimalManager am = new AnimalManager(new EfAnimalDal());

       
        [HttpGet]
        public ActionResult Create(int animalId)
        {
            var animal = am.GetByID(animalId);
            if (animal == null)
            {
                return HttpNotFound();
            }

            var model = new Request
            {
                AnimalID = animalId,
                AnimalName = animal.AnimalName,
                AnimalImg = animal.AnimalImg
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Request request)
        {
            if (ModelState.IsValid)
            {
                request.RequestDate = DateTime.Now;
                rm.RequestAdd(request);
                TempData["SuccessMessage"] = "Talebiniz alınmıştır";
                return RedirectToAction("Index", "Animal");
            }

            return View(request);
        }
    }
}
