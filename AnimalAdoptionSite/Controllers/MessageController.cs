using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalAdoptionSite.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        Message_Validator messagevalidator = new Message_Validator();

        [Authorize]
        public ActionResult Inbox()
        {
            string p = (string)Session["UserEmail"];
            var messageList = mm.GetListInbox(p);
            ViewBag.Username = Session["UserName"];
            return View(messageList);
        }
        public ActionResult Sendbox()
        {
            string p = (string)Session["UserEmail"];
            var messageList = mm.GetListSendbox(p);
            ViewBag.Username = Session["UserName"];
            return View(messageList);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult result = messagevalidator.Validate(p);
            if (result.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }
            return View(p);
        }

    }
}