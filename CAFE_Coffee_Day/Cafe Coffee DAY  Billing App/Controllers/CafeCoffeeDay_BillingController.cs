using Cafe_Coffee_DAY__Billing_App.Models;
using CCD_BusinessAccessLayer.CCD_BusinessAccessLayer;
using CCD_DataAccessLayer.DAL_Layer;
using CCD_EnitityLayer;
using Microsoft.AspNetCore.Mvc;
using Rotativa;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Rotativa.AspNetCore;
using System;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace Cafe_Coffee_DAY__Billing_App.Controllers
{
    public class CafeCoffeeDay_BillingController : Controller
    {
        private readonly BusinessAccessLayer _BillingBal;
        private readonly IDataAccessLayer _BillingDal;

        public CafeCoffeeDay_BillingController(IDataAccessLayer _Dal, BusinessAccessLayer _Bal)
        {
            _BillingBal = _Bal;
            _BillingDal = _Dal;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "Welcome To CAFE COFFEE DAY";
            ViewBag.Customers = _BillingBal.SearchCustomer();
            ViewBag.Products = _BillingBal.SearchProduct();


            return View();
        }

        public IActionResult AddNewCustomer()
        {
            return View(new Customer());
        }
        public IActionResult AddNewProduct()
        {
            return View(new Product());
        }
        public IActionResult AddNewOrder()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult CreateInvoice(string customer, string Product, string quantity)
        {

            Order order = new Order();
            order.quantity = Convert.ToInt32(quantity);
            order.customerId = Convert.ToInt32(customer);
            order.productID = Convert.ToInt32(Product);

            ViewBag.Order = _BillingBal.AddNewOrder(order);
            ViewBag.Customer = _BillingBal.SearchByCustomerId(order.customerId);
            ViewBag.Product = _BillingBal.SearchByProductId(order.productID);


            

            return View(order);

        }

        [HttpGet]
        public IActionResult PrintInvoice(string cust, string prd, string ordId)
        {
            ViewBag.Order = _BillingBal.SearchByOrderId(Convert.ToInt32(ordId));
            ViewBag.Customer = _BillingBal.SearchByCustomerId(Convert.ToInt32(cust));
            ViewBag.Product = _BillingBal.SearchByProductId(Convert.ToInt32(prd));
            

            return View();
        }

        public ActionResult PrintViewToPdf(string cust, string prd, string ordId)
        {
            ViewBag.Order = _BillingBal.SearchByOrderId(Convert.ToInt32(ordId));
            ViewBag.Customer = _BillingBal.SearchByCustomerId(Convert.ToInt32(cust));
            ViewBag.Product = _BillingBal.SearchByProductId(Convert.ToInt32(prd));

            return  new ViewAsPdf("PrintInvoice", new { customer = cust,product = prd, orderId=ordId});
             
        }

    }
}
