using GymPal.Models.NewFolder;

namespace GymPal.Models.Plans;

public class Plan
{
    public int Id { get; set; }
    public string PlanName { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
}