using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalAdoptionSite.Controllers
{
    public class PetShopController : Controller
    {
        PetShopManager pm =new PetShopManager(new EfPetShopDal());

        [Authorize]
        public ActionResult Index()
        {
            var productList = pm.GetList();
            return View(productList);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(PetShop p, HttpPostedFileBase ProductImage)
        {
            if (ProductImage != null && ProductImage.ContentLength > 0)
            {
                var fileName = Path.GetFileName(ProductImage.FileName);
                var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                ProductImage.SaveAs(path);
                p.ProductImage = "/Images/" + fileName;
            }
            pm.PetShopAdd(p); 
            return RedirectToAction("Index"); 
        }
        public ActionResult DeleteProduct(int id)
        {
            var product= pm.GetByID(id);
            pm.PetShopDelete(product); 
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var product = pm.GetByID(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult UpdateProduct(PetShop p, HttpPostedFileBase ProductImage)
        {
            if (ProductImage != null && ProductImage.ContentLength > 0)
            {
                var fileName = Path.GetFileName(ProductImage.FileName);
                var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                ProductImage.SaveAs(path);
                p.ProductImage = "/Images/" + fileName;
            }
            pm.PetShopUpdate(p);
            return RedirectToAction("Index");
        }

    }
}