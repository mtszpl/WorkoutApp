

namespace Models
{
    public class TimedWorkout : Workout
    {
        public int workTime { get; set; }
        public int restTime { get; set; }

        public override void Initialize(int _rounds)
        {
            base.Initialize(_rounds);
        }
    }
}
