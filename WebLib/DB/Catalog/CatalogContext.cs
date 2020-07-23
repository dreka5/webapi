using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebLib.DB.Catalog
{
    public partial class CatalogContext : DbContext
    {
        /// <summary>
        /// работники
        /// </summary>
        public DbSet<Employe> Employe { get; set; }

        /// <summary>
        /// фирмы
        /// </summary>
        public DbSet<Firm> Firm { get; set; }

        public CatalogContext()
        {
            Database.EnsureCreated();
        }   
        public CatalogContext(DbContextOptions<CatalogContext> options): base(options)
        {
            Database.EnsureCreated();  
        }
    }
    
}
