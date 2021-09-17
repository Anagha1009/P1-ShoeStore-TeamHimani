using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoesWeb.Models;
using Data.Entites;
using Data;
using System.Data;
using System.Net;

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
        public ActionResult GetProductById(int? id)
        {

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var cat = repo.GetProductById(id);
            if (cat == null)
                return HttpNotFound();
            return View(Mapper.Map(cat));
            //var product = repo.GetProductById(id);
            //return View(Mapper.Map(product));
        }
        [HttpGet]
        public ActionResult DeleteProductById(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var product=repo.GetProductById(id);
            if (product==null)
                return HttpNotFound();
            return View(Mapper.Map(product));
            //repo.DeleteProduct(id);
            //repo.Save();
            //return RedirectToAction("Index", "Product");
        }

        [HttpPost]
        public ActionResult DeleteProductById(int id)
        {
           
            repo.DeleteProduct(id);
            repo.Save();
            return RedirectToAction("Index", "Product");

        }
        [HttpGet]
        public ActionResult UpdateProductById(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var cat = repo.GetProductById(id);
            if (cat == null)
                return HttpNotFound();
            return View(Mapper.Map(cat));
        }
        [HttpPost]
        public ActionResult UpdateProductById(Product product)
        {

            if (ModelState.IsValid)
            {
                repo.UpdateProduct(product.Product_Id);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        //repo.UpdateProduct(id);
        //repo.Save();
        //return RedirectToAction("Index", "Product");

    }
        
    
}