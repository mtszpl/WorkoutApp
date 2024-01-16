using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkoutApp2.Data;
using WorkoutApp2.Models;

namespace WorkoutApp2.Controllers
{
    public class ExercisesController : Controller
    {
        private readonly WorkoutApp2Context _context;

        public ExercisesController(WorkoutApp2Context context)
        {
            _context = context;
        }

       public List<Exercise> GetByMuscleGroup(EMuscleGroup group, int limit = -1) 
       {
            IEnumerable<Exercise> exercises = from e in _context.Exercise where e.MuscleGroup == @group select e;
            if(exercises == null)
                return new List<Exercise>();
            if(limit > 0)
                exercises = exercises.Take(limit);
            return exercises.ToList();
       }
    }
}
