using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imageuploading.Models
{
    public class Context :DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-VLDSRET;database=imageupload; integrated security=true");
        }

        public DbSet<ItemImage> itemImages { get; set; }

    }
}
