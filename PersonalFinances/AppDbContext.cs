using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances
{
    public class AppDbContext : DbContext
    {
        //SQL configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Provide connection string for the database
            var connString = "";
            optionsBuilder.UseSqlServer();
        }

        //DB Sets (entities)
    }
}
