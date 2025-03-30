using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;
using mine2.Models;

namespace mine2.Controllers
{

    public class AdminController : Controller
    {
        
        SqlConnection connect = new SqlConnection("Data Source=AYUSHI;Initial Catalog=My_Project;Integrated Security=True");

        database DB = new database();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add_User() 
        {
            string command = "select * from user_profile ";

             DataTable dt = DB.SelectStatment(command);

            ViewBag.data = dt;
            

            return View();
       
        }

        [HttpPost]
        public ActionResult Add_User(HttpPostedFileBase Photo, string Username, string Password, string gender, string Email )
        {
            string command = "insert into user_profile values('"+ Photo.FileName+"', '" + Username+ "', '"+Password+ "', '"+gender+"', '" + Email+"')"; 

            SqlCommand cmd = new SqlCommand(command, connect);

            connect.Open();
            int a = cmd.ExecuteNonQuery();
            connect.Close();

            if(a>0)
            {
                return Content("<script> alert('Data added successfully'); location.href='/Admin/Add_User' </script>");
            }

            else
            {
                return Content("<script> alert('Unable to add data'); location.href='/Admin/Add_User' </script>");
            }

        }
        public ActionResult Remove_User()
        {
            return View();
        }

        public ActionResult Add_Blog()
        {
            string command = "SELECT sr, category_name FROM category";

            DataTable dt = DB.SelectStatment(command);

            ViewBag.cat = dt;

            return View();

        }

        [HttpPost]
        public ActionResult Add_Blog(string Category, string heading, string blog_content, HttpPostedFileBase Images)
        {

            String command = "insert into add_blog values('"+Category+"','"+heading+"','"+blog_content+"','"+Images.FileName+"')";

               int b = DB.InsertUpdateDelete(command);


            if (b > 0)
            {
                Images.SaveAs(Server.MapPath("/Content/Blog_img/")+Images.FileName);

                return Content("<script> alert('Data added successfully'); location.href='/Admin/Add_Blog' </script>");
            }

            else
            {
               
                return Content("<script> alert('Unable to add data'); location.href='/Admin/Add_Blog' </script>");
            }

        }

        public ActionResult Add_Poetry()
        {
            string command = "select * from add_poem";

            DataTable dt = DB.SelectStatment(command);

            ViewBag.data = dt;

            return View();
        }

        [HttpPost]
        public ActionResult Add_Poetry(string Title, HttpPostedFileBase Images, string Poem)
        {
            string command = "insert into add_poem values('"+Title+"', '"+Images+"', '"+Poem+"')";

            SqlCommand sqlcommand = new SqlCommand(command, connect);

            connect.Open();
            int c = sqlcommand.ExecuteNonQuery();
            connect.Close();

            if (c > 0)
            {
                return Content("<script> alert('Data added successfully'); location.href='/Admin/Add_Poetry' </script>");
            }

            else
            {
                return Content("<script> alert('Unable to add data'); location.href='/Admin/Add_Poetry' </script>");
            }
        }

        public ActionResult Add_Project()
        {
            string command = "select * from add_project";

            DataTable dt = DB.SelectStatment(command);

            ViewBag.data = dt;

            return View();
        }

        [HttpPost]
        public ActionResult Add_Project(string Title, HttpPostedFileBase Image, string Link)
        {

            string command = "insert into add_project values('"+Title+"', '"+Image+"', '"+Link+"')";

            SqlCommand comm = new SqlCommand(command, connect);

            connect.Open();
            int d = comm.ExecuteNonQuery();
            connect.Close();

            if (d > 0)
            {
                return Content("<script> alert('Data added successfully'); location.href='/Admin/Add_Poetry' </script>");
            }

            else
            {
                return Content("<script> alert('Unable to add data'); location.href='/Admin/Add_Poetry' </script>");
            }
        }


    
    public ActionResult Category()
        {
            string command = "select * from category";

            DataTable dt = DB.SelectStatment(command);

            ViewBag.category = dt;

            return View();
        }

        [HttpPost]
        public ActionResult Category(string Category_name, HttpPostedFileBase category_icon)
        {

            String command = "insert into category values('" + Category_name + "','" + category_icon.FileName+ "')";

            int e = DB.InsertUpdateDelete(command);

            if (e > 0)
            {
                return Content("<script> alert('Data added successfully'); location.href='/Admin/Category' </script>");
            }

            else
            {
                return Content("<script> alert('Unable to add data'); location.href='/Admin/Category' </script>");
            }

        }

        public ActionResult Logout() 
        {
            Session.Remove("admin");

            return RedirectToAction("Index", "Home");
        }
    }
}