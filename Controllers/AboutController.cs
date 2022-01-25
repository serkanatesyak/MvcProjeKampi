﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFreamework;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {

        AboutManager abm = new AboutManager(new EfAboutDal());

        // GET: About
        public ActionResult Index()
        {
            var abaoutValues = abm.GetList();
            return View(abaoutValues);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            abm.AboutAdd(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {

            return PartialView();
        }



    }
}