using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WorkoutApp2
    .Data
{
    public class WorkoutApp2Context : DbContext
    {
        public WorkoutApp2Context (DbContextOptions<WorkoutApp2Context> options)
            : base(options)
        {
        }

        public DbSet<WorkoutApp2.Models.Exercise> Exercise { get; set; } = default!;
        public DbSet<WorkoutApp2.Models.Workout> Workout { get; set; } = default!;
        public DbSet<WorkoutApp2.Models.TimedWorkout> TimedWorkout { get; set; } = default!;
        public DbSet<WorkoutApp2.Models.RepsWorkout> RepsWorkout { get; set; } = default!;
    }
}
