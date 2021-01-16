
using Microsoft.EntityFrameworkCore;
using ShopperProject.Areas.Admin.Models;

namespace ShopperProject.Data
{
    public class ShopperDbContext : DbContext
    {
        public DbSet<Loai> Loais { get; set; }
        public DbSet<HangHoa> HangHoas { get; set; }

        public ShopperDbContext(DbContextOptions options):base(options)
        {
        }
    }
}
