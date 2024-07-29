using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Enums;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalAdoptionSite.Controllers
{
    public class AdminAnimalController : Controller
    {
        AnimalManager am = new AnimalManager(new EfAnimalDal());

        [Authorize]
        public ActionResult Index()
        {
            var animalvalues = am.GetAnimalsList();
            return View(animalvalues);
        }
        public ActionResult Cats()
        {
            var animalvalues = am.GetAnimalsList();
            ViewBag.Cats = animalvalues.Where(x => x.AnimalBreed == AnimalBreed.Kedi).ToList();
            return View(animalvalues);
        }  public ActionResult Dogs()
        {
            var animalvalues = am.GetAnimalsList();
            ViewBag.Dogs = animalvalues.Where(x => x.AnimalBreed == AnimalBreed.Köpek).ToList();
            return View(animalvalues);
        } 
        public ActionResult Birds()
        {
            var animalvalues = am.GetAnimalsList();
            ViewBag.Birds = animalvalues.Where(x => x.AnimalBreed == AnimalBreed.Kuş).ToList();
            return View(animalvalues);
        }
        [HttpGet]
        public ActionResult AddAnimal()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAnimal(Animal p, HttpPostedFileBase AnimalImg)
        {
            //AnimalValidator animalvalidator = new AnimalValidator();
            //ValidationResult result = animalvalidator.Validate(p);
           
                if (AnimalImg != null && AnimalImg.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(AnimalImg.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    AnimalImg.SaveAs(path);
                    p.AnimalImg = "/Images/" + fileName;
                }
                am.AnimalAdd(p);
                 return RedirectToAction("Index");
            
        }
        public ActionResult DeleteAnimal(int id)
        {
            var animalvalue = am.GetByID(id);
            am.AnimalDelete(animalvalue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAnimal(int id)
        {
            var animalvalue = am.GetByID(id);
            return View(animalvalue);
        }
        [HttpPost]
        public ActionResult UpdateAnimal(Animal p, HttpPostedFileBase AnimalImg)
        {
            if (AnimalImg != null && AnimalImg.ContentLength > 0)
            {
                var fileName = Path.GetFileName(AnimalImg.FileName);
                var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                AnimalImg.SaveAs(path);

                // Hayvan nesnesine fotoğraf yolunu ekleyin
                p.AnimalImg = "/Images/" + fileName;
            }


            am.AnimalUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult ActivateAnimal(int id)
        {
            am.SetActive(id, true);
            return RedirectToAction("Index");
        }

        public ActionResult DeactivateAnimal(int id)
        {
            am.SetActive(id, false);
            return RedirectToAction("Index");
        }
    }
}