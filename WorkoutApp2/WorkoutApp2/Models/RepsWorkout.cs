﻿using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutApp2.Models
{
    [Table("RepsWorkout")]
    public class RepsWorkout : Workout
    {
        public int reps { get; set; } = 10;

        public override void Initialize(int _rounds)
        {
            base.Initialize(_rounds);
        }
    }
}
