using GymPal.Helpers;
using GymPal.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GymPal.Controllers;

[Route("api")]
public class PlanController : ControllerBase
{
    private readonly IPlanService _planService;
    public PlanController(IPlanService planService)
    {
        _planService = planService;
    }
    // [HttpPost("[controller]")]
    [HttpGet("[controller]")]
    public async Task<ObjectResult> CreatePlan([FromQuery] string planName)
    {
        var test = HttpContext.Items["userId"];
        return await Handlers.RequestHandler(async () =>
        {
            var res = await _planService.CreatePlanAsync(planName, (string)test);
            return Ok(res);
        });
    }
}