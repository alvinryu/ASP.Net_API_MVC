using API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("myConnection")
        {

        }

        //public MyContext() : base("myConnection") { }

        public DbSet<Supplier> Suppliers { set; get; }

        public DbSet<Item> Items { set; get; }

        public System.Data.Entity.DbSet<API.Models.ItemViewModel> ItemViewModels { get; set; }
    }
}