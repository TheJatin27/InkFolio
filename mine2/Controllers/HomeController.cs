using mine2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace mine2.Controllers
{
    public class HomeController : Controller
    {
        database DB = new database();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }

        public ActionResult BookReviews()
        {
            string command = "select * from add_blog where cat = '14'";

            DataTable jt = DB.SelectStatment(command);

           ViewBag.book = jt;

            return View();
        }

        public ActionResult Lifestyle()
        {
            string command = "select * from add_blog where cat = '13'";

            DataTable dt = DB.SelectStatment(command);

            ViewBag.Lifestyle = dt;

            return View();
        }
        
        public ActionResult Health()
        {
            string command = "select * from add_blog where cat = '12'";

            DataTable dt = DB.SelectStatment(command);

            ViewBag.health = dt;

            return View();
        }

        public ActionResult Fashion()
        {
            string command = "select * from add_blog where cat = '15'";

            DataTable dataTable = DB.SelectStatment(command);

            ViewBag.fashion = dataTable; 

            return View();
        }

        public ActionResult Poetry()
        {
            string command = "select * from add_blog where cat = '11'";

            DataTable dataTable= DB.SelectStatment(command);    

            ViewBag.poetry = dataTable;

            return View();
        }
        public ActionResult SignIn()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SignIn( string username, string password)
        {
            string command = "select * from user_profile where username = '" + username + "' and password = '" + password + "'";

            DataTable dt = DB.SelectStatment(command);

            if (dt.Rows.Count > 0)
            {
                Session["user"] = username;

                return RedirectToAction("Index", "User");
            }

            else
            {
                return Content("<script> alert('Wrong username or password!'); location.href = '/home/signin'</script>");
            }


        }

    

        public ActionResult SignUp()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SignUp(HttpPostedFileBase Photo, string Username, string Password, string gender, string Email)
        {
            string command = "insert into user_profile values('" + Photo.FileName + "', '" + Username + "', '" + Password + "', '" + gender + "', '" + Email + "')";

            int dt =  DB.InsertUpdateDelete(command);

            if(dt > 0)
            {
                return Content("<script>alert('Thank you for connecting with us.') </script>");
            }

            else
            {
                return Content("<script> alert('Error!');location.href = '/home/signin' </script>");
            }

        }

        public ActionResult Admin()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Admin(string username, string password)
        {
            string command = "select * from admin where username = '" + username + "' and password = '" + password + "'";

            DataTable dt = DB.SelectStatment(command);

            if (dt.Rows.Count > 0)
            {
                Session["admin"] = username;

                return RedirectToAction("Index", "Admin");
            }

            else
            {
                return Content("<script> alert('Wrong username or password!'); location </script>");
            }


        }

    }


    class CheckSession : ActionFilterAttribute 
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;

            if (session["admin"]==null) 
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                {
                    {"Controller", "Home"},
                    {"Action", "Admin"}
                });
            }
        }

    }

}
   