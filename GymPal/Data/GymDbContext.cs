using Microsoft.EntityFrameworkCore;

namespace GymPal.Data
{
    public class GymDbContext : DbContext
    {
        public GymDbContext(DbContextOptions options): base(options) { }
    }
}
