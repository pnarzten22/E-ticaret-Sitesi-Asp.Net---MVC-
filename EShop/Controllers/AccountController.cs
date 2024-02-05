using DataAccessLayer.DataContext;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EShop.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        Context1 db = new Context1();
       
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User data)
        {
            var bilgiler = db.Users.FirstOrDefault(x => x.Email == data.Email && x.Password == data.Password);
            if (bilgiler != null)
            {

                FormsAuthentication.SetAuthCookie(bilgiler.Email, false);

                Session["Mail"] = bilgiler.Email.ToString();
                Session["Ad"] = bilgiler.Name.ToString();
                Session["Soyad"] = bilgiler.Surname.ToString();
                return RedirectToAction("Index", "Home");

            }
            

            ViewBag.Hata = "Kullanıcı Adı Veya Şifreniz Yanlış";
            return View(data);
        }
        [HttpPost]
        public ActionResult Register(User data)
        {
            db.Users.Add(data);
            data.Role = "User";
            
            db.SaveChanges();

            ViewBag.register = "Kayıt işlemi başarılı giriş yapabilirsiniz.";
            return RedirectToAction("Login");

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            
            return RedirectToAction("Index","Home");
        }
    }
}