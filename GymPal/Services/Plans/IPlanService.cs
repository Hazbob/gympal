using GymPal.Models.Plans;

namespace GymPal.Services;

public interface IPlanService
{
    Task<PlanResponse> CreatePlanAsync(string planName, string userId);
}