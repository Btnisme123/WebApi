using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebApplication1.Models;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for ServiceShopBanHang
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ServiceShopBanHang : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Product> GetFeatureProduct()
        {
            ShopBanHangDbContext db= new ShopBanHangDbContext();
            return db.Products.Where(x => x.TopHot != null).OrderBy(x => x.ID).Take(2).ToList();
        }
    }
}
