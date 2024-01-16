using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutApp2.Models
{
    [Table("Workout")]
    public class Workout
    {
        public int Id { get; set; }
        public int isTimed {  get; set; } = -1;
        public string Name { get; set; }
        public EMuscleGroup MuscleGroup { get; set; }
        public int rounds { get; set; }

        public List<Exercise> exerciseList { get; set;  } = new List<Exercise>();

        public int exercisesCount { get; set; } = 0;

        public virtual void Initialize(int _rounds) { }

    }
}
