using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Bloc3_Caviste.Data
{
    class DBConnect : DbContext
    {
        //Private attributes for DB connection
        private static readonly string dbName = "RougePassion.db";
        //Path ensures DB files is searched for in the same folder the executable file is located
        private static readonly string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Data\", dbName);
        private readonly string connectionString = $"Data Source={Path.GetFullPath(dbPath)}";

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
