using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System.Linq;
using System.Web.Mvc;

namespace AnimalAdoptionSite.Controllers
{
    public class AnimalController : Controller
    {
        AnimalManager am = new AnimalManager(new EfAnimalDal());
        public ActionResult Index()
        {
            var activeAnimals = am.GetActiveAnimals(); // Sadece aktif hayvanları al
            return View(activeAnimals);
        }

    }
}

