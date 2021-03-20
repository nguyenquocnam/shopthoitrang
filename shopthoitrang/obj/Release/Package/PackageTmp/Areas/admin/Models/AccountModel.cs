using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Shopthucung.Models;

namespace Shopthucung.Areas.admin.Models
{
    public class AccountModel
    {
        private shopDBmodel conn = null;
        public AccountModel()
        {
            conn = new shopDBmodel();

        }
        public bool Login(string userName, string password)
        {
            
            var res = conn.Users.Where(c=>c.TaiKhoan==userName && c.MatKhau==password).ToList();
            if (res.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}