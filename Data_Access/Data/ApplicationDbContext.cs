using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;

namespace Project.Data
{
    public class ApplicationDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer();
            }
        }
    }
}
