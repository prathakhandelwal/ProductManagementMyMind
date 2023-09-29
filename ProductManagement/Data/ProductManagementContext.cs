using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Model;

namespace ProductManagement.Data
{
    public class ProductManagementContext : DbContext
    {
        public ProductManagementContext (DbContextOptions<ProductManagementContext> options)
            : base(options)
        {
        }

        public DbSet<ProductManagement.Model.Product> Product { get; set; } = default!;
    }
}
