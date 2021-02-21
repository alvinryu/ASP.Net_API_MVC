using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    [Table("Tb_M_Supplier")]
    public class Supplier
    {
        [Key]
        public int Id { set; get; }

        [StringLength(20, MinimumLength = 6, ErrorMessage = "Name must be more than 5 char")]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Name must be Alpanumeric")]
        public string SupplierName { set; get; }

        public ICollection<Item> Items { get; set; }
    }
}