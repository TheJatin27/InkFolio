using mine2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mine2.Controllers
{
    public class UserController : Controller
    {
        database DB = new database();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Blog()
        {
            string command = "select * from add_blog";

            DataTable dt = DB.SelectStatment(command);

            ViewBag.blog = dt;

            string cmd = "select * from comment";

            DataTable table_data = DB.SelectStatment(cmd);

            ViewBag.cmd = table_data;

            string comm = "SELECT * from add_blog full outer join comment on add_blog.serial = comment.blog_id";

            DataTable at = DB.SelectStatment(comm);

            ViewBag.comm = at;

            return View();
        }

        [HttpPost]
        public ActionResult Blog(string blog_id, string comment, string useres)
        {
            string command = "insert into comment values('"+blog_id+"', '"+useres+"', '" + comment + "')";

            int dt = DB.InsertUpdateDelete(command);

            if (dt > 0)
            {
                return Content("<script> alert('Thank you for comments.'); location.href = '/user/blog'</script>");
            }
            else
            {
                return Content("<script> alert('Error!')</script>");
            }

        }
        public ActionResult BookReviews()
        {
            string command = "select * from add_blog";

            DataTable dt = DB.SelectStatment(command);

            ViewBag.blog = dt;

            string cmd = "select * from comment";

            DataTable table_data = DB.SelectStatment(cmd);

            ViewBag.cmd = table_data;

            string comm = "SELECT * from add_blog full outer join comment on add_blog.serial = comment.blog_id where cat = 14";

            DataTable at = DB.SelectStatment(comm);

            ViewBag.comm = at;

            return View();
        }


        [HttpPost]

        public ActionResult BookReviews(string blog_id, string comment, string useres)
        {
            string command = "insert into comment values('" + blog_id + "', '" + useres + "', '" + comment + "')";

            int dt = DB.InsertUpdateDelete(command);

            if (dt > 0)
            {
                return Content("<script> alert('Thank you for comments.'); location.href = '/user/blog'</script>");
            }
            else
            {
                return Content("<script> alert('Error!')</script>");
            }

        }

        public ActionResult Lifestyle()
        {
            string command = "select * from add_blog";

            DataTable dt = DB.SelectStatment(command);

            ViewBag.blog = dt;

            string cmd = "select * from comment";

            DataTable table_data = DB.SelectStatment(cmd);

            ViewBag.cmd = table_data;

            string comm = "SELECT * from add_blog full outer join comment on add_blog.serial = comment.blog_id where cat = 13";

            DataTable at = DB.SelectStatment(comm);

            ViewBag.comm = at;
            return View();
        }


        [HttpPost]

        public ActionResult Lifestyle(string blog_id, string comment, string useres)
        {
            string command = "insert into comment values('" + blog_id + "', '" + useres + "', '" + comment + "')";

            int dt = DB.InsertUpdateDelete(command);

            if (dt > 0)
            {
                return Content("<script> alert('Thank you for comments.'); location.href = '/user/blog'</script>");
            }
            else
            {
                return Content("<script> alert('Error!')</script>");
            }

        }
        public ActionResult Health()
        {
            string command = "select * from add_blog";

            DataTable dt = DB.SelectStatment(command);

            ViewBag.blog = dt;

            string cmd = "select * from comment";

            DataTable table_data = DB.SelectStatment(cmd);

            ViewBag.cmd = table_data;

            string comm = "SELECT * from add_blog full outer join comment on add_blog.serial = comment.blog_id where cat = 12";

            DataTable at = DB.SelectStatment(comm);

            ViewBag.comm = at;
            return View();
        }


        [HttpPost]

        public ActionResult Health(string blog_id, string comment, string useres)
        {
            string command = "insert into comment values('" + blog_id + "', '" + useres + "', '" + comment + "')";

            int dt = DB.InsertUpdateDelete(command);

            if (dt > 0)
            {
                return Content("<script> alert('Thank you for comments.'); location.href = '/user/blog'</script>");
            }
            else
            {
                return Content("<script> alert('Error!')</script>");
            }

        }

        public ActionResult Fashion()
        {
            string command = "select * from add_blog";

            DataTable dt = DB.SelectStatment(command);

            ViewBag.blog = dt;

            string cmd = "select * from comment";

            DataTable table_data = DB.SelectStatment(cmd);

            ViewBag.cmd = table_data;

            string comm = "SELECT * from add_blog full outer join comment on add_blog.serial = comment.blog_id where cat = 15";

            DataTable at = DB.SelectStatment(comm);

            ViewBag.comm = at;


            return View();
        }


        [HttpPost]

        public ActionResult Fashion(string blog_id, string comment, string useres)
        {
            string command = "insert into comment values('" + blog_id + "', '" + useres + "', '" + comment + "')";

            int dt = DB.InsertUpdateDelete(command);

            if (dt > 0)
            {
                return Content("<script> alert('Thank you for comments.'); location.href = '/user/blog'</script>");
            }
            else
            {
                return Content("<script> alert('Error!')</script>");
            }

        }

        public ActionResult Poetry()
        {
            string command = "select * from add_blog";

            DataTable dt = DB.SelectStatment(command);

            ViewBag.blog = dt;

            string cmd = "select * from comment";

            DataTable table_data = DB.SelectStatment(cmd);

            ViewBag.cmd = table_data;

            string comm = "SELECT * from add_blog full outer join comment on add_blog.serial = comment.blog_id where cat = 11";

            DataTable at = DB.SelectStatment(comm);

            ViewBag.comm = at;


            return View();
        }

        [HttpPost]

        public ActionResult Poetry(string blog_id, string comment, string useres)
        {
            string command = "insert into comment values('" + blog_id + "', '" + useres + "', '" + comment + "')";

            int dt = DB.InsertUpdateDelete(command);

            if (dt > 0)
            {
                return Content("<script> alert('Thank you for comments.'); location.href = '/user/poetry'</script>");
            }
            else
            {
                return Content("<script> alert('Error!')</script>");
            }

        }


        //public ActionResult Comment(string comment)
        //{
        //    string command = "insert into comment values('" + comment + "')";

        //    int dt = DB.InsertUpdateDelete(command);

        //    if(dt > 0) 
        //     {
        //        return Content("<script> alert('Thank you for comments.')</script>");
        //     }
        //    else
        //    {
        //       return Content("<script> alert('Error!')</script>");
        //    }
        //}

        public ActionResult My_profile()
        {
            string command = "select * from user_profile where username = '" + Session["user"] +"'";

            DataTable dt = DB.SelectStatment(command);

            ViewBag.command = dt;

            return View();
        }

        [HttpPost]
        public ActionResult My_profile(HttpPostedFileBase Profile_pic, string username, string password, string gender, string email)
        {
            string command = "update user_profile set profile_pic = '"+Profile_pic.FileName+"' username = '"+username+"' password = '"+password+"' gender = '"+gender+"' email = '"+email+"' where username = '" + Session["user"] +"'";

           int dt = DB.InsertUpdateDelete(command);

            if (dt > 0)
            {
                //return Content("<script>alert('Information saved succesfully')</script>");

                return RedirectToAction("My_profile", "user");
            }

            else
            {
                return Content("<script> alert('Wrong username or password!')</script>");
            }


        }


    }


    class Session : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;

            if (session["user"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                {
                    {"Controller", "User"},
                    {"Action", "Index"}
                });
            }
        }

    }
}