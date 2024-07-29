using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalAdoptionSite.Controllers
{
    public class UserPanelController : Controller
    {
        // GET: UserPanel
        public ActionResult UserProfile()
        {
            ViewBag.UserName = Session["UserName"];
            return View();
        }
        public ActionResult SendBox()
        {
            // Retrieve the username from the session and pass it to the view
            ViewBag.Username = Session["UserName"];
            return View();
    }

    public ActionResult InBox()
    {
        // Retrieve the username from the session and pass it to the view
        ViewBag.Username = Session["UserName"];
        return View();
    }
}
}