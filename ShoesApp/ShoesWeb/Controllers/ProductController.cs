using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoesWeb.Models;
using Data.Entites;
using Data;
using System.Data;

namespace ShoesWeb.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ProductRepository repo;
        public ProductController()
        {
            repo = new ProductRepository(new ProductModel());
        }
        // GET: Pet
        public ActionResult Index()
        {
            var product = repo.GetProducts();
           
            var data = new List<Product>();
            foreach (var c in product)
            {
                data.Add(Mapper.Map(c));
               
            }
            return View(data);
        }
        public ActionResult GetProductById(int id)
        {
            var product = repo.GetProductById(id);
            return View(Mapper.Map(product));
        }
        [HttpGet]
        public ActionResult DeleteProductById(int id)
        {
            var product=repo.GetProductById(id);
           // return View(Mapper.Map(product));
            repo.DeleteProduct(id);
            repo.Save();
            return RedirectToAction("Index", "Product");
        }

        //[HttpPost]
        //public ActionResult ConfirmDelete(int id)
        //{
            
        //    repo.DeleteProduct(id);
        //    repo.Save();
        //    return RedirectToAction("Index", "Home");

        //}
        public ActionResult UpdateProductById(int id)
        {
            var product = repo.GetProductById(id);
            View(Mapper.Map(product));

            repo.UpdateProduct(id);
            repo.Save();
            return RedirectToAction("Index", "Product");
            
        }
        
    }
}