﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_MVC;

namespace WebApplication_1.Controllers
{
    public class HomeController : Controller
    {
        Model1 ctx = new Model1();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Admin()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult MakeOrder()
        {
            return View(ctx.Pizzas.ToList());
        }

        public ActionResult _LogIn()
        {
            return PartialView();
        }

        public ActionResult LogOut()
        {
            @Response.Cookies["userInfo"]["login"] = null;
            Response.Cookies["userInfo"]["password"] = null;
            return View("Index");
        }

        public ActionResult _CreateAcc()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Login_Submit(Squirrel squirrel)
        {
           
            Squirrel squ = new Squirrel() { Login = squirrel.Login, Password = squirrel.Password };            
            if((ctx.Squirrels.FirstOrDefault(m=>m.Login == squ.Login)) !=null && ctx.Squirrels.FirstOrDefault(m=>m.Password==squ.Password)!=null)
            {
                string password_hash = Md5_Hash(squ.Password);
                @Response.Cookies["userInfo"]["password"] = password_hash;
                @Response.Cookies["userInfo"]["login"] = squirrel.Login;
                
                return View("MakeOrder");
            }
            else
            {
                ViewBag.Message = "Not CORRECTLY!";
                return View("Index");
            }
        }
        public string Md5_Hash(string password)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();

            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);

            data = x.ComputeHash(data);

            return System.Text.Encoding.ASCII.GetString(data);
        }

        [HttpPost]
        public ActionResult CreateAcc(Squirrel squirrel)
        {
            Squirrel squ = new Squirrel() { Login = squirrel.Login, Password = squirrel.Password, Tail_Color = squirrel.Tail_Color, isAdmin = false };
            if ((ctx.Squirrels.FirstOrDefault(m => m.Login == squ.Login)) == null)
            {
                
                ctx.Squirrels.Add(squ);
                ctx.SaveChanges();
                string password_hash =Md5_Hash(squ.Password);
                @Response.Cookies["userInfo"]["password"] = password_hash;
                @Response.Cookies["userInfo"]["login"] = squirrel.Login;
                return View("MakeOrder");
            }
            else
            {
                ViewBag.Message = "This Login is busy. Input more original login, please!";
                return View("Index");
            }
        }

        public ActionResult CreateOrder()
        {
            Order order = new Order() { }
            return View("Index");
        }
    }
}