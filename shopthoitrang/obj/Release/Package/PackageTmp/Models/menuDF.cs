using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopthucung.Models
{
    public class menuDF
    {
        public List<List<PhanLoaiSP>> list { get; set; }
        public menuDF()
        {
            list = new List<List<PhanLoaiSP>>();
        }
    }
}