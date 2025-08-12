using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloc3_Caviste.Data
{
    class DBConnect : DbContext
    {
        //Private attributes for DB connection
        private static readonly string dbName = "RougePassion.db";
        private readonly string connectionString = $"Data Source={dbName}";

        //Configure function
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString);
        }

        //Initialize Database
        protected void dbInit()
        {
            using var context = new DBConnect();
            context.Database.EnsureCreated();
        }
    }
}
