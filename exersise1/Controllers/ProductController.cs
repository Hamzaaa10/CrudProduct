using exersise1.Services;
using exersise1.Models;

using Microsoft.AspNetCore.Mvc;
using exersise1.Migrations;
using System;

namespace exersise1.Controllers
{
    public class ProductController : Controller
    {
       // private readonly AppDbContext context;
        private readonly IWebHostEnvironment environment;

        public ProductController( IWebHostEnvironment environment)
        {
           // this.context = context;
            this.environment=environment;
        }
        AppDbContext context = new AppDbContext();
        public IActionResult Index()
        {
            var products = context.Products.ToList();
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductDtl input)
        {
            if (input.Imgurl == null)
            {
                ModelState.AddModelError("Imgurl", "the image file is required");
                // return View();
            }
            if (ModelState.IsValid == false)
            {
                return View(input);
            }

            string Newfilename = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            Newfilename += Path.GetExtension(input.Imgurl!.FileName);
            string imagefullPath = environment.WebRootPath + "/Products/" + Newfilename;



            using (var stream = System.IO.File.Create(imagefullPath))
            {
                input.Imgurl.CopyTo(stream);
            }
            var pro = new Product
            {
                Name = input.Name,
                prand=input.prand,
                Category=input.Category,
                Description = input.Description,
                Price = input.Price,
                Imgurl=Newfilename,        
                TimeCr=DateTime.Now,

            };
            context.Products.Add(pro);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {           
            var pro =context.Products.FirstOrDefault(p => p.Id == id);
            return View(pro);
        }
        [HttpPost]
        public ActionResult Edit(ProductDtl input ,int id)
        {
            if (input == null) 
            { 
                return View();
            }
            if (ModelState.IsValid==false)
            {
                return View(input);
            }

            var pro = context.Products.FirstOrDefault(p => p.Id == id);
            string Newfilename = pro.Imgurl ;

            if (input.Imgurl!=null)
            {
                 Newfilename = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                Newfilename += Path.GetExtension(input.Imgurl.FileName);
                string imagefullPath = environment.WebRootPath + "/Products/" + Newfilename;



                using (var stream = System.IO.File.Create(imagefullPath))
                {
                    input.Imgurl.CopyTo(stream);
                }
                string oldimage = environment.WebRootPath + "/Products/" + Newfilename;
                System.IO.File.Delete(oldimage);
            }
            pro.Name = input.Name;
            pro.Description = input.Description;
            pro.prand = input.prand;
            pro.Category = input.Category;
            pro.Description = input.Description;
            pro.Price = input.Price;
            pro.TimeCr = DateTime.Now;
            pro.Imgurl=Newfilename;
            context.Update(pro);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            var pro = context.Products.FirstOrDefault(p=>p.Id == id);    
            context.Products.Remove(pro);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
