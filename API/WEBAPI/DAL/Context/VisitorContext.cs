using Microsoft.EntityFrameworkCore;
using WEBAPI.DAL.Entities;

namespace WEBAPI.DAL.Context
{
    public class VisitorContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("server=CINPOSOFT\\DB;Database=TraversalDB;integrated security=true");
        }
        public DbSet<Visitor> Visitors { get; set; }
    }
}
