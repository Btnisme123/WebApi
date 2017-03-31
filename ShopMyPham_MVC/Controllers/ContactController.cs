using ShopMyPham_MVC.CodeEntity;
using ShopMyPham_MVC.Common;
using ShopMyPham_MVC.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopMyPham_MVC.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Send(string name, string mobile, string address, string email, string content)
        {
            var feedback = new Feedback();
            feedback.Name = name;
            feedback.Email = email;
            feedback.CreatedDate = DateTime.Now;
            feedback.Phone = mobile;
            feedback.Content = content;
            feedback.Address = address;

            var id = new CodeContact().InsertFeedBack(feedback);
            if (id > 0)
            {
                //send mail
                string contentKH = System.IO.File.ReadAllText(Server.MapPath("~/Accset/Client/template/ContactHelper.html"));
                contentKH = contentKH.Replace("{{CustomerName}}", name);
                contentKH = contentKH.Replace("{{Phone}}", mobile);
                contentKH = contentKH.Replace("{{Email}}", email);
                contentKH = contentKH.Replace("{{Address}}", address);
                contentKH = contentKH.Replace("{{Content}}", content);
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
                new MailHelper().SendMail(toEmail, "Tư vấn khách hàng", contentKH);
                return Json(new
                {
                    status = true
                });
            }
            else
                return Json(new
                {
                    status = false
                });

        }
        [HttpPost]
        public ActionResult SaveInfoBeacon(FormCollection form)
        {

       
            Beacon beacon = new Beacon();
            Random random = new Random();
            beacon.MACID = random.Next(1,100);
            beacon.ShopID= random.Next(1, 1000);
            //beacon.LocationX = Convert.ToInt64(form.Get("txtCordinateX"));
            //beacon.LocationY = Convert.ToInt64(form.Get("txtCordinateY"));
            //

            //String a = Request["LocX"].ToString();
            //String b = Request["LocY"].ToString();

           
            beacon.LocationX = Convert.ToDecimal(form.Get("txtCordinateX").ToString());
            beacon.LocationY = Convert.ToDecimal(form.Get("txtCordinateY").ToString());
            new CodeBeacon().insert(beacon);
            return View("Index");   
        }
       
    }
}