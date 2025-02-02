using GymPal.Models.Plans;

namespace GymPal.Repositories.Plans;

public class PlanRepository : IPlanRepository
{
    private readonly GymPalDbContext _context;
    public PlanRepository(GymPalDbContext context)
    {
        _context = context;
    }
    public async Task<Plan> CreatePlanAsync(string planName, string userId)
    {
        var newPlan = new Plan
        {
            PlanName = planName,
            UserId = userId
        };
        var result = await _context.Plans.AddAsync(newPlan);
        return result.Entity;
    }
}