using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalAdoptionSite.UserPanelController
{
    public class UserPanelMessageController : Controller
    {
        // GET: UserPanelMessage
        MessageManager mm = new MessageManager(new EfMessageDal());
        Message_Validator messagevalidator = new Message_Validator();
        Context c=new Context();
        
        public ActionResult Inbox()
        {
           string  p = (string)Session["UserEmail"];
            ViewBag.Username = Session["UserName"];
            var messageList = mm.GetListInbox(p);
            return View(messageList);
        }
        public ActionResult Sendbox()
        {
            string p = (string)Session["UserEmail"];
            ViewBag.Username = Session["UserName"];
            var messageList = mm.GetListSendbox(p);
            return View(messageList);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
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
            string sender =(string)Session["UserEmail"];
            ValidationResult result = messagevalidator.Validate(p);
            if (result.IsValid)
            {
                p.SenderMail = sender;
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