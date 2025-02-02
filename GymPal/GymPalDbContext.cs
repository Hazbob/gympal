using GymPal.Models.Plans;
using Microsoft.EntityFrameworkCore;

namespace GymPal;

public class GymPalDbContext : DbContext
{
    public GymPalDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Plan> Plans { get; set; }
}