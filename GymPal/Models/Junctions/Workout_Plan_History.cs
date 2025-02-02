using GymPal.Models.NewFolder;
using GymPal.Models.Plans;
using GymPal.Models.Workouts;

namespace GymPal.Models.Junctions;

public class Workout_Plan_History
{
    public int WorkoutId { get; set; }
    public Workout Workout { get; set; }
    public int PlanId { get; set; }
    public Plan Plan { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public DateOnly DateOfWorkout { get; set; }
}