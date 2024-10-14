using BincomAssign2.Okwe.Models;
using Microsoft.EntityFrameworkCore;

namespace BincomAssign2.Okwe.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Photo> Photos { get; set; }
    }
}
