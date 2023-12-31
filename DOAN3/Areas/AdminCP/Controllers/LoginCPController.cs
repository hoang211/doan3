﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOAN3.Models;

namespace DOAN3.Areas.AdminCP.Controllers
{
    public class LoginCPController : Controller
    {
        DOAN3Entities1 db = new DOAN3Entities1();
        // GET: AdminCP/LoginCP
        public ActionResult login()
        {
            ViewBag.Err = "";
            return View();
        }
        [HttpPost]
        public ActionResult login(FormCollection x)
        {

            string err = "";
            string tk = x["user"];
            string mk = x["password"];
            Users ck = db.Users.Where(y => (y.UserName == tk) && y.Role == true && y.Active == true).FirstOrDefault();
            if (ck == null)
            {
                err = "Tên đăng nhập không tồn tại";
            }
            else
            {
                if (ck.PassWord.Equals(mk))
                {
                    Session["UserAdmin"] = ck.UserName;
                    Session["UserId"] = ck.PassWord;
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    err = "Mật khẩu không chính xác";
                }
            }
            ViewBag.Err = err;
            return View();

        }
        public ActionResult Logout()
        {
            Session["UserAdmin"] = "";
            Session["UserId"] = "";

            return RedirectToAction("login", "Login");
        }
    }
}