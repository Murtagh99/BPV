using Microsoft.EntityFrameworkCore;

namespace Adressdaten.Models
{
    public class AdressdatenContext : DbContext
    {
        public AdressdatenContext(DbContextOptions<AdressdatenContext> options)
            : base(options)
        {
        }

        public DbSet<AdressdatenItem> AdressdatenItems { get; set; }
    }
}