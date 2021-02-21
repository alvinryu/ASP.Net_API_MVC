using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    [Table("Tb_Item")]
    public class Item
    {
        public int Id { set; get; }

        public string Name { set; get; }

        public int Quantity { set; get; }

        public int Price { set; get; }

        [ForeignKey("Supplier")]
        public int SupplierId { set; get; }
        public Supplier Supplier { get; set; }
        
    }
}