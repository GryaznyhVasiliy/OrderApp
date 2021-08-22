using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        OrderContext db;

        public HomeController(ILogger<HomeController> logger, OrderContext context)
        {
            _logger = logger;
            db = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            db.Orders.Add(order);
            if(order.Weight == 0)
            {
                throw new Exception("Не введён вес");
            }
            if(order.ReciveDate == DateTime.MinValue)
            {
                throw new Exception("Не введена дата");
            }
            db.SaveChanges();
            return View();
        }

        [HttpGet]
        public IActionResult ViewOrders()
        {
            return View(db.Orders.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
