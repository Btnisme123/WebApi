using ShopMyPham_MVC.CodeEntity;
using ShopMyPham_MVC.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopMyPham_MVC.Areas.Admin.Models;

namespace ShopMyPham_MVC.Areas.Admin.Controllers
{
    public class BeaconController : Controller
    {

        public ActionResult Index()
        {
         return View();
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

            String a = form.Get("txtCordinateX");
           
            if (form.Get("txtCordinateX")!=null&& form.Get("txtCordinateY") !=null)
            {
                beacon.LocationX = Convert.ToDecimal(form.Get("txtCordinateX").ToString());
                beacon.LocationY = Convert.ToDecimal(form.Get("txtCordinateY").ToString());
                new CodeBeacon().insert(beacon);
            }
            else
            {
                beacon.LocationX = Convert.ToDecimal(form.Get("txtCordinateX").ToString());
            }
           
             return View("Index");   		
         }


}
}
