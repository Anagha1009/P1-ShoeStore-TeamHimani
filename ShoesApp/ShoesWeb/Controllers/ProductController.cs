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
using System.IO;

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
        public ActionResult UpdateProductById(tb_products products, HttpPostedFileBase Product_Image)
        {
            try
            {
                if (Product_Image != null)
                {
                    string fileExtension = Path.GetExtension(Path.GetFileName(Product_Image.FileName));
                    decimal filesize = Math.Round(((decimal)Product_Image.ContentLength / (decimal)1024), 2);

                    if ((fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png") && (filesize < 200))
                    {
                        products.product_image = products.product_id + "_" + Product_Image.FileName;
                        string path = Path.Combine(Server.MapPath("~/Images/ProductImg"), products.product_image);

                        FileInfo imgfile = new FileInfo(path);
                        if (imgfile.Exists)
                        {
                            imgfile.Delete();
                        }

                        Product_Image.SaveAs(path);
                    }
                    else
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Your file should be in .jpg, .png format and file size should be less than 200 kb!");
                    }
                }

                repo.UpdateProduct(products.product_id, products);
            }
            catch (Exception)
            {
                ViewBag.FileStatus = "Error while file uploading."; ;
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            ViewBag.Category = new SelectList(repo.getCategory(), "category_id", "category_name");
            ViewBag.Store = new SelectList(repo.getStore(), "store_id", "store_name");
            ViewBag.Color = new SelectList(repo.getColor(), "color_id", "color");
            ViewBag.Size = new SelectList(repo.getSize(), "size_id", "size");
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product products)
        {
            if (ModelState.IsValid)
            {
                repo.AddProduct(Mapper.Maps(products));
                return RedirectToAction("Index");
            }
            return View(products);
        }

    }
}