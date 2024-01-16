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
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutsController : Controller
    {
        private readonly WorkoutApp2Context _context;
        private ExercisesController _exercisesController;


        public WorkoutsController(WorkoutApp2Context context)
        {
            _context = context;
            _exercisesController = new ExercisesController(context);
        }

        [HttpGet]
        public List<Workout> GetAllWorkouts()
        {
            return _context.Workout.ToList();
        }

        [HttpGet("{group}")]
        public List<Workout> GetByMuscleGroup(EMuscleGroup group)
        {
            IEnumerable<Workout> workouts = from w in _context.Workout where w.MuscleGroup == @group select w;
            if (workouts == null)
                return new List<Workout>();
            return workouts.ToList();
        }

        [HttpGet("id={id}")]
        public Workout? GetById(int id) 
        {
            Workout? workout = _context.Workout.Find(id);
            if (workout != null)
                workout.exerciseList = _exercisesController.GetByMuscleGroup(workout.MuscleGroup, workout.exercisesCount);
            else
                return null;
            TimedWorkout? timed = workout as TimedWorkout;
            if (timed != null)
            {
                timed.isTimed = 1;
                return timed;
            }
            RepsWorkout? reps = workout as RepsWorkout;
            if (reps != null)
            {
                reps.isTimed = 0;
                return reps;
            }
            return workout;
        }

        // GET: Workouts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Workout.ToListAsync());
        }
    }
}
