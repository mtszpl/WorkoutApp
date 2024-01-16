using Microsoft.EntityFrameworkCore;
using WorkoutApp2.Data;

namespace WorkoutApp2.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider servieProvider)
        {
            using (WorkoutApp2Context context = new WorkoutApp2Context(
                servieProvider.GetRequiredService<
                    DbContextOptions<WorkoutApp2Context>>()
                ))
            {
                PopulateExercise(context);
                PopulateWorkout(context);
                context.SaveChanges();
            }
        }

        private static void PopulateExercise(WorkoutApp2Context context)
        {
            if (!context.Exercise.Any())
            {
                context.Exercise.AddRange(

                    new Exercise
                    {
                        Name = "Plank",
                        MuscleGroup = EMuscleGroup.Abs
                    },
                    new Exercise
                    {
                        Name = "Blade Crunches",
                        MuscleGroup = EMuscleGroup.Abs
                    },
                    new Exercise
                    {
                        Name = "Situps",
                        MuscleGroup = EMuscleGroup.Abs
                    },
                    new Exercise
                    {
                        Name = "Side Plank on Left Side",
                        MuscleGroup = EMuscleGroup.Abs
                    },
                    new Exercise
                    {
                        Name = "Side Plank on Right Side",
                        MuscleGroup = EMuscleGroup.Abs
                    },
                    new Exercise
                    {
                        Name = "Rolling Situps",
                        MuscleGroup = EMuscleGroup.Abs
                    },
                    new Exercise
                    {
                        Name = "Leg Raises",
                        MuscleGroup = EMuscleGroup.Abs
                    },
                    new Exercise
                    {
                        Name = "Bicycles",
                        MuscleGroup = EMuscleGroup.Abs
                    },
                    new Exercise
                    {
                        Name = "Flooder Kicks",
                        MuscleGroup = EMuscleGroup.Abs
                    },
                    new Exercise
                    {
                        Name = "V Sits",
                        MuscleGroup = EMuscleGroup.Abs
                    },

                    new Exercise
                    {
                        Name = "Push Ups",
                        MuscleGroup = EMuscleGroup.Arms
                    },
                    new Exercise
                    {
                        Name = "Biceps Curls",
                        MuscleGroup = EMuscleGroup.Arms
                    },
                    new Exercise
                    {
                        Name = "Dips",
                        MuscleGroup = EMuscleGroup.Arms
                    },
                    new Exercise
                    {
                        Name = "Triceps Extensions",
                        MuscleGroup = EMuscleGroup.Arms
                    },
                    new Exercise
                    {
                        Name = "Arm Lateral Raises",
                        MuscleGroup = EMuscleGroup.Arms
                    },
                    new Exercise
                    {
                        Name = "Pull-ups",
                        MuscleGroup = EMuscleGroup.Arms
                    },
                    new Exercise
                    {
                        Name = "Chin-ups",
                        MuscleGroup = EMuscleGroup.Arms
                    },

                    new Exercise
                    {
                        Name = "Left Static Lunge",
                        MuscleGroup = EMuscleGroup.Legs
                    },
                    new Exercise
                    {
                        Name = "Right Static Lunge",
                        MuscleGroup = EMuscleGroup.Legs
                    },
                    new Exercise
                    {
                        Name = "3 Count Squats",
                        MuscleGroup = EMuscleGroup.Legs
                    },
                    new Exercise
                    {
                        Name = "Squat Walk",
                        MuscleGroup = EMuscleGroup.Legs
                    },
                    new Exercise
                    {
                        Name = "Left Courtsy Lunge",
                        MuscleGroup = EMuscleGroup.Legs
                    },
                    new Exercise
                    {
                        Name = "Right Courtsy Lunge",
                        MuscleGroup = EMuscleGroup.Legs
                    },
                    new Exercise
                    {
                        Name = "3 Count Sumo Squats",
                        MuscleGroup = EMuscleGroup.Legs
                    },
                    new Exercise
                    {
                        Name = "Lateral Squat Walk",
                        MuscleGroup = EMuscleGroup.Legs
                    },
                    new Exercise
                    {
                        Name = "Left Front to Back Lunge",
                        MuscleGroup = EMuscleGroup.Legs
                    },
                    new Exercise
                    {
                        Name = "Right Front to Back Lunge",
                        MuscleGroup = EMuscleGroup.Legs
                    }
                    );
            }
        }

        private static void PopulateWorkout(WorkoutApp2Context context)
        {
            if (!context.TimedWorkout.Any())
                PopulateTimedWorkouts(context);
            if (!context.RepsWorkout.Any())
                PopulateRepsWorkout(context);

        }

        private static void PopulateRepsWorkout(WorkoutApp2Context context)
        {
            context.RepsWorkout.AddRange(
                new RepsWorkout
                {
                    Name = "Basic Beginner Arms",
                    rounds = 1,
                    reps = 10,
                    exercisesCount = 3,
                    MuscleGroup = EMuscleGroup.Arms
                },
                new RepsWorkout
                {
                    Name = "Intermediate Beginner Arms",
                    rounds = 2,
                    exercisesCount = 5,
                    reps = 10,
                    MuscleGroup = EMuscleGroup.Arms
                });
        }

        private static void PopulateTimedWorkouts(WorkoutApp2Context context)
        {
            context.TimedWorkout.AddRange(
                            new TimedWorkout
                            {
                                Name = "Advanced Abs Tabata",
                                restTime = 10,
                                workTime = 50,
                                rounds = 10,
                                exercisesCount = 10,
                                MuscleGroup = EMuscleGroup.Abs
                            },
                            new TimedWorkout
                            {
                                Name = "Intermediate Abs Tabata",
                                restTime = 20,
                                workTime = 40,
                                rounds = 10,
                                exercisesCount = 10,
                                MuscleGroup = EMuscleGroup.Abs
                            },
                            new TimedWorkout
                            {
                                Name = "Beginner Abs Tabata",
                                restTime = 30,
                                workTime = 30,
                                rounds = 10,
                                exercisesCount = 10,
                                MuscleGroup = EMuscleGroup.Abs
                            },

                            new TimedWorkout
                            {
                                Name = "Advanced Legs Tabata",
                                restTime = 10,
                                workTime = 50,
                                rounds = 10,
                                exercisesCount = 10,
                                MuscleGroup = EMuscleGroup.Legs
                            },
                            new TimedWorkout
                            {
                                Name = "Intermediate Legs Tabata",
                                restTime = 20,
                                workTime = 40,
                                rounds = 10,
                                exercisesCount = 10,
                                MuscleGroup = EMuscleGroup.Legs
                            },
                            new TimedWorkout
                            {
                                Name = "Beginner Legs Tabata",
                                restTime = 30,
                                workTime = 30,
                                rounds = 10,
                                exercisesCount = 10,
                                MuscleGroup = EMuscleGroup.Legs
                            }
                        );
        }
    }
}
