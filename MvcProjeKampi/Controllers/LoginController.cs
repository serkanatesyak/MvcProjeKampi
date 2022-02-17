using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFreamework;
using EntityLayer;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        WriterLoginManager wm=new WriterLoginManager(new EfWriterDal());


        // GET: Login
        [HttpGet]

        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c = new Context();
            var adminuserimfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);

            if (adminuserimfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserimfo.AdminUserName, false);
                Session["AdminUserName"] = adminuserimfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Writerlogin()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Writerlogin(Writer p)
        {
            //Context c = new Context();
            //var writeruserimfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);

            var writeruserimfo = wm.GetWriter(p.WriterMail, p.WriterPassword);
            if (writeruserimfo != null)
            {
                FormsAuthentication.SetAuthCookie(writeruserimfo.WriterMail, false);
                Session["WriterMail"] = writeruserimfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("Writerlogin");
            }


        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");

        }




    }


}
