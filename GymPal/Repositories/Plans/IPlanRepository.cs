using GymPal.Models.Plans;

namespace GymPal.Repositories.Plans;

public interface IPlanRepository
{
    Task<Plan> CreatePlanAsync(string PlanName, string userId);
}