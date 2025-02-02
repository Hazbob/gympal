using GymPal.Models.NewFolder;

namespace GymPal.Models.Workouts;

public class Workout
{
    public int Id { get; set; }
    public string WorkoutName { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
}