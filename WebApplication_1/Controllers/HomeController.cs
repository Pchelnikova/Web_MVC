using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_MVC;

namespace WebApplication_1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Admin()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Order()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult _LogIn()
        {
            return PartialView();
        }

        public ActionResult _CreateAcc()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult Login_Submit(Squirrel squirrel)
        {


            Squirrel squ = new Squirrel() { Login = squirrel.Login, Password = squirrel.Password };
            
            Model1 ctx = new Model1();

            if((ctx.Squirrels.FirstOrDefault(m=>m.Login == squ.Login)) !=null && ctx.Squirrels.FirstOrDefault(m=>m.Password==squ.Password)!=null)
            {
                return View("Order");
            }
            else
            {
                //ViewBag("Not CORRECTLY!");
                return View("_LogIn");
            }
        }

        [HttpGet]
        public ActionResult CreateAcc(Squirrel squirrel)
        {
            Squirrel squ = new Squirrel() { Login = squirrel.Login, Password = squirrel.Password, Tail_Color = squirrel.Tail_Color, isAdmin = false };

            Model1 ctx = new Model1();

            if ((ctx.Squirrels.FirstOrDefault(m => m.Login == squ.Login)) == null)
            {
                ctx.Squirrels.Add(squ);
                ctx.SaveChanges();
                return View("Order");
            }
            else
            {
                //ViewBag("Not CORRECTLY!");
                return View("_CreateAcc");
            }
        }

        
    }
}