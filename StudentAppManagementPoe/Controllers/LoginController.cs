using StudentAppManagementPoe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentAppManagementPoe.Controllers
{
    public class LoginController : Controller
    {

        StudentInfoEntities db = new StudentInfoEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index(user objchk)
        {

            if (ModelState.IsValid)
            {

                using(StudentInfoEntities db = new StudentInfoEntities())
                {


                    var obj = db.users.Where(a => a.username.Equals(objchk.username) && a.password.Equals(objchk.password)).FirstOrDefault();

                    if (obj != null)
                    {

                        Session["UserId"] = obj.id.ToString();
                        Session["UserName"] = obj.username.ToString();
                        return RedirectToAction("../SelfStudies/Create");

                    }
                    else
                    {

                        ModelState.AddModelError("", "The UserName or Password Incorrect");


                    }
                }
            }
            
            return View(objchk);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }



    }
}