using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProductsProject.Models
{
    public class ProductConnection : DbContext
    {
        public DbSet<Product> ProductsTable { get; set; }
    }
}