﻿
namespace Models
{
    public enum EMuscleGroup
    {
        Abs,
        Legs,
        Arms
    }

    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EMuscleGroup MuscleGroup { get; set; }
    }
}
