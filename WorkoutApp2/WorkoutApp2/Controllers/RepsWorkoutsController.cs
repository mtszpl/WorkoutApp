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
    public class RepsWorkoutsController : Controller
    {
        private readonly WorkoutApp2Context _context;

        public RepsWorkoutsController(WorkoutApp2Context context)
        {
            _context = context;
        }

        // GET: RepsWorkouts
        public async Task<IActionResult> Index()
        {
            return View(await _context.RepsWorkout.ToListAsync());
        }

        // GET: RepsWorkouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repsWorkout = await _context.RepsWorkout
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repsWorkout == null)
            {
                return NotFound();
            }

            return View(repsWorkout);
        }

        // GET: RepsWorkouts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RepsWorkouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("reps,Id,Name,MuscleGroup,rounds,exercisesCount")] RepsWorkout repsWorkout)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repsWorkout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(repsWorkout);
        }

        // GET: RepsWorkouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repsWorkout = await _context.RepsWorkout.FindAsync(id);
            if (repsWorkout == null)
            {
                return NotFound();
            }
            return View(repsWorkout);
        }

        // POST: RepsWorkouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("reps,Id,Name,MuscleGroup,rounds,exercisesCount")] RepsWorkout repsWorkout)
        {
            if (id != repsWorkout.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repsWorkout);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepsWorkoutExists(repsWorkout.Id))
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
            return View(repsWorkout);
        }

        // GET: RepsWorkouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repsWorkout = await _context.RepsWorkout
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repsWorkout == null)
            {
                return NotFound();
            }

            return View(repsWorkout);
        }

        // POST: RepsWorkouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var repsWorkout = await _context.RepsWorkout.FindAsync(id);
            if (repsWorkout != null)
            {
                _context.RepsWorkout.Remove(repsWorkout);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepsWorkoutExists(int id)
        {
            return _context.RepsWorkout.Any(e => e.Id == id);
        }
    }
}
