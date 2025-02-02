using GymPal.Models.Plans;
using GymPal.Repositories.Plans;

namespace GymPal.Services;

public class PlanService : IPlanService
{
    private readonly IPlanRepository _planRepository;
    
    public PlanService(IPlanRepository planRepository)
    {
        _planRepository = planRepository;
    }
    
    public async Task<PlanResponse> CreatePlanAsync(string planName, string userId)
    {
       var plan = await _planRepository.CreatePlanAsync(planName, userId);
       var response = new PlanResponse
       {
           Id = plan.Id,
           PlanName = plan.PlanName
       };
       return response;
    }
}