using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication_1.Models
{
    public class PizzaHelpModel
    {
        public IEnumerable<WebApplication_MVC.Pizza> Pizzas { get; set; }
        public WebApplication_MVC.Order Orders { get; set; }
    }
}