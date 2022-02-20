namespace TeisterMask.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TeisterMask.Data;
    using TeisterMask.Data.Models;

    public class TaskController : Controller
    {
        private readonly TeisterMaskDbContext context;

        public TaskController(TeisterMaskDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Task> tasks = context.Tasks.ToList();
            return View(tasks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string title, string status)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return View();
            }

            Task task = new Task() {Title = title, Status = status };
            context.Tasks.Add(task);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> Edit(int id, [Bind("Id,Title,Status")] Task task)
        {
            if (id != task.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(task);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskExists(task.Id))
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
            return View(task);
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await context.Tasks
                .FirstOrDefaultAsync(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        public async System.Threading.Tasks.Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await context.Tasks.FindAsync(id);
            context.Tasks.Remove(task);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskExists(int id)
        {
            return context.Tasks.Any(e => e.Id == id);
        }
    }
}
