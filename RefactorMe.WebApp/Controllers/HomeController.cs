using Newtonsoft.Json;
using RefactorMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace RefactorMe.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllProducts(Currency? currency)
        {
            ProductDataConsolidator productDataConsolidator = new ProductDataConsolidator();
            var products = productDataConsolidator.GetAll(currency);
            return Json(new { Success = true, products = JsonConvert.SerializeObject(products) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}