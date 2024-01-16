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
    public class TimedWorkoutsController : Controller
    {
        private readonly WorkoutApp2Context _context;

        public TimedWorkoutsController(WorkoutApp2Context context)
        {
            _context = context;
        }

        // GET: TimedWorkouts
        public async Task<IActionResult> Index()
        {
            return View(await _context.TimedWorkout.ToListAsync());
        }

        // GET: TimedWorkouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timedWorkout = await _context.TimedWorkout
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timedWorkout == null)
            {
                return NotFound();
            }

            return View(timedWorkout);
        }

        // GET: TimedWorkouts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TimedWorkouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("workTime,restTime,Id,Name,MuscleGroup,rounds,exercisesCount")] TimedWorkout timedWorkout)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timedWorkout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(timedWorkout);
        }

        // GET: TimedWorkouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timedWorkout = await _context.TimedWorkout.FindAsync(id);
            if (timedWorkout == null)
            {
                return NotFound();
            }
            return View(timedWorkout);
        }

        // POST: TimedWorkouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("workTime,restTime,Id,Name,MuscleGroup,rounds,exercisesCount")] TimedWorkout timedWorkout)
        {
            if (id != timedWorkout.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timedWorkout);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimedWorkoutExists(timedWorkout.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(timedWorkout);
        }

        // GET: TimedWorkouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timedWorkout = await _context.TimedWorkout
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timedWorkout == null)
            {
                return NotFound();
            }

            return View(timedWorkout);
        }

        // POST: TimedWorkouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timedWorkout = await _context.TimedWorkout.FindAsync(id);
            if (timedWorkout != null)
            {
                _context.TimedWorkout.Remove(timedWorkout);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimedWorkoutExists(int id)
        {
            return _context.TimedWorkout.Any(e => e.Id == id);
        }
    }
}
