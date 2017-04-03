using PagedList;
using ShopMyPham_MVC.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopMyPham_MVC.CodeEntity
{
    public class CodeBeacon
    {
        private ShopBanHangDbContext context = null;
        public CodeBeacon()
        {
            context = new ShopBanHangDbContext();
        }

        public void insert(Beacon beacon)
        {
            Random random = new Random();
            beacon.MACID = random.Next(1, 1000);
            context.Beacons.Add(beacon);
            context.SaveChanges();
        }
    }
}