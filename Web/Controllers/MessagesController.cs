using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLogic;
using Domain.Entities;
using Web.Models;

namespace Web.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {
        private DataManager dataManager;
        public MessagesController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public ActionResult Index()
        {
            List<IncomingMessageViewModel> model = new List<IncomingMessageViewModel>();
            foreach (var message in dataManager.Messagess.GetIncomingMessagesByUserId((int)Membership.GetUser().ProviderUserKey))
            {
                if(model.FirstOrDefault(x=>x.UserFrom.Id==message.UserFromId)==null)
                     model.Add(new IncomingMessageViewModel
                    {
                        Message = message,
                        UserFrom = dataManager.Users.GetUserById(message.UserFromId)
                    });
            }

            return View(model);
        }


        public ActionResult Chat(int userFromId)
        {
             ChatModelView model = new ChatModelView()
            {
                MeUser = dataManager.Users.GetUserById((int)Membership.GetUser().ProviderUserKey),
                UserFrom = dataManager.Users.GetUserById(userFromId),
                Chat = dataManager.Messagess.GetUserChat((int)Membership.GetUser().ProviderUserKey, userFromId).ToList()
            };

            return View(model);
        }

        public ActionResult NewMessage(Message message)
        {
               if(ModelState.IsValid)
                dataManager.Messagess.SaveMessage(message);
                return RedirectToAction("Chat",new {userFromId=message.UserFromId});          
        }

    }
}
