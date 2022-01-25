using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;

using DataAccessLayer.EntityFreamework;
using EntityLayer;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCatgoryList()
        {

            var categoryvalues = cm.GetList();   //category values kategori tablodaki değerler gelecek

            return View(categoryvalues);
        }


        [HttpGet]

        public ActionResult AddCategory()
        {
            return View();
        }


        [HttpPost]                       //sayfada butona tıklayınca sayfada post edildiği zamanda çalış get sayfa yüklenince çalışcak
        public ActionResult AddCategory(Category p)
        {
            // cm.CategoryAddBL(p);
            CategoryValidatior categoryValidator = new CategoryValidatior();
            ValidationResult results = categoryValidator.Validate(p);
            if (results.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("GetCatgoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }





    }
}