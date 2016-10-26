using System;
using System.Collections.Generic;
using System.IO;
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
    public class HomeController : Controller
    {
        private DataManager dataManager;
        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public ActionResult Index(int id = 0)
        {
            //Если в адресе Url не был представлен Id пользователя, то явным образом вычисляем этот Id и
            //перенаправляем пользователя на то же действие, однако добавляем в адрес вычисленный Id
            if (id == 0)
                return RedirectToAction("Index", new { id = Membership.GetUser().ProviderUserKey });

            User user = dataManager.Users.GetUserById(id);

            //Исходя из значения Id в адресе Url определяем, на чью страницу мы попали
            UserViewModel model = new UserViewModel
            {
                User = user,
                UserIsMe = id == (int)Membership.GetUser().ProviderUserKey,
                UserIsMyFriend =
                    dataManager.Friends.UsersAreFriends(
                        (int)Membership.GetUser().ProviderUserKey, user.Id),
                FriendRequestIsSent =
                    dataManager.FriendRequests.RequestIsSent(user.Id,
                                                             (int)
                                                             Membership.GetUser().
                                                                 ProviderUserKey),

              Avatar = dataManager.Avatars.GetAvatarByUserId(user.Id)

            };
            return View(model);
        }

        public ActionResult AddAvatar(int userId)
        {
            AvatarUdateModel model = new AvatarUdateModel()
            {
                UserId = userId,
                Avatar = dataManager.Avatars.GetAvatarByUserId(userId)
            };

            return PartialView("AvatarUpdate",model);
        }

        [HttpPost]
        public ActionResult AddAvatar(Avatar avatar, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid && uploadImage != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
                // установка массива байтов
                avatar.ImageData = imageData;
                avatar.ImageMimeType = uploadImage.ContentType;

                dataManager.Avatars.SaveAvatar(avatar);
                
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", new { id = Membership.GetUser().ProviderUserKey });
        }

        public FileContentResult GetAvatar(int userId)
        {
            Avatar avatar = dataManager.Avatars.GetAvatarByUserId(userId);

            if (avatar != null)
            {
                return File(avatar.ImageData, avatar.ImageMimeType);
            }
            else
            {
                return null;
            }
        }


    }
}
