using GymPal.Models.Plans;
using GymPal.Models.Workouts;

namespace GymPal.Models.Junctions;

public class Plan_Workout
{
    public int WorkoutId { get; set; }
    public Workout Workout { get; set; }
    public int PlanId { get; set; }
    public Plan Plan { get; set; }
}