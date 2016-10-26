﻿using System;
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
    public class AccountController : Controller
    {
        private DataManager dataManager;

        public AccountController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (dataManager.MembershipProvider.ValidateUser(model.UserName, model.Password))
                {

                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Неудачная попытка входа на сайт");
            }
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                MembershipCreateStatus status = dataManager.MembershipProvider.CreateUser(model.UserName, model.Password,
                                                                                                          model.Email, model.FirstName,
                                                                                                          model.LastName,
                                                                                                          model.MiddleName);
                if (status == MembershipCreateStatus.Success)
                    return RedirectToAction("Login");
                ModelState.AddModelError("",GetMembershipCreateStatusResultText(status));
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public string GetMembershipCreateStatusResultText(MembershipCreateStatus status)
        {
            if (status == MembershipCreateStatus.DuplicateEmail)
                return "Пользователь с таким email адресом уже существует";
            if (status == MembershipCreateStatus.DuplicateUserName)
                return "Пользователь с таким именем уже существует";
            //if ...
            return "Неизвестная ошибка";
        }


    }
}
