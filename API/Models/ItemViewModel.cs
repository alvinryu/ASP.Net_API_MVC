using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class ItemViewModel
    {
        public int Id { set; get; }

        public string Name { set; get; }

        public int Quantity { set; get; }

        public int Price { set; get; }

        public int SupplierId { set; get; }

        public string SupplierName { set; get; }
    }
}