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
        public ActionResult Index(string username)
        {
            if ((Session["username"] != null) && (Session["role"].ToString() == "admin"))
            {
                var product = repo.GetProducts();
                var data = new List<Product>();

                foreach (var p in product)
                {
                    data.Add(Mapper.Map(p));
                }
                return View(data);
            }
            else
            {
                return RedirectToAction("LoginCustomer", "User");
            }
            
        }

        [HttpGet]
        public ActionResult GetProducts(int? id)
        {
            if ((Session["username"] != null) && (Session["role"].ToString() == "customer"))
            {
                ViewBag.Color = new SelectList(repo.getColor(), "color_id", "color");
                ViewBag.Size = new SelectList(repo.getSize(), "size_id", "size");
                ViewBag.Store = new SelectList(repo.getStore(), "store_id", "store_name");
                var product = repo.GetProducts();

                var data = new List<Product>();
                foreach (var p in product)
                {
                    data.Add(Mapper.Map(p));
                }
                data = data.Where(x => x.Store_Id == id).ToList();

                return View(data);
            }
            else
            {
                return RedirectToAction("LoginCustomer", "User");
            }
            
        }
        public ActionResult GetProductById(int? id)
        {
            if ((Session["username"] != null) && (Session["role"].ToString() == "admin"))
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                var pro = repo.GetProductById(id);
                if (pro == null)
                    return HttpNotFound();
                return View(Mapper.Map(pro));
            }
            else
            {
                return RedirectToAction("LoginCustomer", "User");
            }
            
        }
        [HttpGet]
        public ActionResult DeleteProductById(int? id)
        {
            if ((Session["username"] != null) && (Session["role"].ToString() == "admin"))
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                var product = repo.GetProductById(id);
                if (product == null)
                    return HttpNotFound();
                return View(Mapper.Map(product));
            }
            else
            {
                return RedirectToAction("LoginCustomer", "User");
            }
            
        }

        [HttpPost]
        public ActionResult DeleteProductById(int id)
        {
            if ((Session["username"] != null) && (Session["role"].ToString() == "admin"))
            {
                repo.DeleteProduct(id);
                repo.Save();
                return RedirectToAction("Index", "Product");

            }
            else
            {
                return RedirectToAction("LoginCustomer", "User");
            }
            
        }
        [HttpGet]
        public ActionResult UpdateProductById(int? id)
        {
            if ((Session["username"] != null) && (Session["role"].ToString() == "admin"))
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
            else
            {
                return RedirectToAction("LoginCustomer", "User");
            }
            
        }

        [HttpPost]
        public ActionResult UpdateProductById(tb_products products, HttpPostedFileBase Product_Image)
        {
            if ((Session["username"] != null) && (Session["role"].ToString() == "admin"))
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
                            string path = Path.Combine(Server.MapPath("~/Images/ProductImg/Boots"), products.product_image);

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
            else
            {
                return RedirectToAction("LoginCustomer", "User");
            }
            
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            if ((Session["username"] != null) && (Session["role"].ToString() == "admin"))
            {
                ViewBag.Category = new SelectList(repo.getCategory(), "category_id", "category_name");
                ViewBag.Store = new SelectList(repo.getStore(), "store_id", "store_name");
                ViewBag.Color = new SelectList(repo.getColor(), "color_id", "color");
                ViewBag.Size = new SelectList(repo.getSize(), "size_id", "size");
                return View();
            }
            else
            {
                return RedirectToAction("LoginCustomer", "User");
            }

            
        }
        [HttpPost]
        public ActionResult AddProduct(Product products, HttpPostedFileBase Product_Image)
        {
            if ((Session["username"] != null) && (Session["role"].ToString() == "admin"))
            {
               int prodid = repo.GetMaxProductId();
                int newproid = prodid + 1;

                if (Product_Image != null)
                {
                    string fileExtension = Path.GetExtension(Path.GetFileName(Product_Image.FileName));
                    decimal filesize = Math.Round(((decimal)Product_Image.ContentLength / (decimal)1024), 2);

                    if ((fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png") && (filesize < 200))
                    {
                        products.Product_Image = newproid + "_" + Product_Image.FileName;
                        string path = Path.Combine(Server.MapPath("~/Images/ProductImg/Boots"), products.Product_Image);

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

                repo.AddProduct(Mapper.Maps(products));

                List<int> cl = products.ColorList;

                if (cl != null)
                {
                    foreach (var pcc in cl)
                    {
                        List<tb_productcolor> productColors = new List<tb_productcolor>(){
                                        new tb_productcolor() { color_id = pcc, product_id = prodid}
                                        };

                        ProductModel pm = new ProductModel();
                        pm.tb_productcolor.AddRange(productColors);
                        pm.SaveChanges();
                    }
                }

                List<int> sl = products.SizeList;

                if (sl != null)
                {
                    foreach (var pcc in sl)
                    {
                        List<tb_productsize> productSizess = new List<tb_productsize>(){
                                        new tb_productsize() { size_id = pcc, product_id = prodid}
                                        };

                        ProductModel pm = new ProductModel();
                        pm.tb_productsize.AddRange(productSizess);
                        pm.SaveChanges();
                    }
                }

                return RedirectToAction("Index"); 
            }
            else
            {
                return RedirectToAction("LoginCustomer", "User");
            }
            
        }

        [HttpPost]
        public void CheckColorAvailability(int selectedId, int productId)
        {
            if ((Session["username"] != null) && (Session["role"].ToString() == "customer"))
            {
                RedirectToAction("GetProducts", "Product");
            }
            else
            {
                RedirectToAction("LoginCustomer", "User");
            }
            
        }
    }
}