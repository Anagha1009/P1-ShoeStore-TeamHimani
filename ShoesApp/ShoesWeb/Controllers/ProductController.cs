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
            foreach (var p in product)
            {
                data.Add(Mapper.Map(p));

            }
            return View(data);
        }
        public ActionResult GetProductById(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var pro = repo.GetProductById(id);
            if (pro == null)
                return HttpNotFound();
            return View(Mapper.Map(pro));
        }
        [HttpGet]
        public ActionResult DeleteProductById(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var product = repo.GetProductById(id);
            if (product == null)
                return HttpNotFound();
            return View(Mapper.Map(product));
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
            ViewBag.Category = new SelectList(repo.getCategory(), "category_id", "category_name");
            ViewBag.Store = new SelectList(repo.getStore(), "store_id", "store_name");

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var pro = repo.GetProductById(id);
            if (pro == null)
                return HttpNotFound();
            return View(Mapper.Map(pro));
        }

        [HttpPost]
        public ActionResult UpdateProductById(tb_products products)
        {
            repo.UpdateProduct(products.product_id, products);
            return RedirectToAction("Index");
        }    
    }
}