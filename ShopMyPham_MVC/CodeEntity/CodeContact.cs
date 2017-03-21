using ShopMyPham_MVC.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopMyPham_MVC.CodeEntity
{
    public class CodeContact
    {
        private ShopBanHangDbContext context = null;

        public CodeContact()
        {
            context = new ShopBanHangDbContext();
        }

        public int InsertFeedBack(Feedback fb)
        {
            context.Feedbacks.Add(fb);
            context.SaveChanges();
            return fb.ID;
        }
    }
}