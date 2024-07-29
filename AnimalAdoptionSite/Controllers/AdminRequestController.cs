using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalAdoptionSite.Controllers
{
    public class AdminRequestController : Controller
    {
        // GET: AdminRequest

            RequestManager rm = new RequestManager(new EfRequestDal());

            public ActionResult Index()
            {
                var requestList = rm.GetAll();
                return View(requestList);
            }

            public ActionResult Approve(int id)
            {
                var request = rm.GetByID(id);
                if (request != null)
                {
                    request.IsApproved = true;
                    rm.RequestUpdate(request);
                }

                return RedirectToAction("Index");
            }

            public ActionResult Reject(int id)
            {
                var request = rm.GetByID(id);
                if (request != null)
                {
                    request.IsApproved = false;
                    rm.RequestUpdate(request);
                }

                return RedirectToAction("Index");
            }
        }
    
}