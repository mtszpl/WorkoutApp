using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutApp2.Models
{
    [Table("TimedWorkout")]
    public class TimedWorkout : Workout
    {
        public int workTime { get; set; }
        public int restTime { get; set; }

        public int remainingTime;

        public override void Initialize(int _rounds)
        {
            base.Initialize(_rounds);
        }
    }
}
