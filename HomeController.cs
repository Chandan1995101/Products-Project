using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductsProject.Models;
using System.Net;

namespace ProductsProject.Controllers
{
    public class HomeController : Controller
    {
        ProductConnection db = new ProductConnection();
        public ViewResult Index()
        {
            return View(db.ProductsTable.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Bad Request - Product Id Missing");
            }
            Product product = db.ProductsTable.Find(id);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product Not Found");
            }
            return View(product);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Id Missing");
            }
            Product product = db.ProductsTable.Find(id);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Not Found");
            }
            return View(product);
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost(int? id)
        {
            Product product = db.ProductsTable.Find(id);
            UpdateModel(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }       

        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToRouteResult Create(string Name, decimal Price)
        {
            Product product = new Product();
            product.Name = Name;
            product.price = Price;

            db.ProductsTable.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Id Missing");
            }
            Product product = db.ProductsTable.Find(id);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Not Found");
            }
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(int? id)
        {
            Product product = db.ProductsTable.Find(id);
            db.ProductsTable.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
