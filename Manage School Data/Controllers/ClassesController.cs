using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Manage_School_Data;
using Manage_School_Data.Models;

namespace Manage_School_Data.Controllers
{
    public class ClassesController : Controller
    {
        private readonly MVC_Context _context;

        public ClassesController(MVC_Context context)
        {
            _context = context;
        }

        // GET: Classes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClassesModel.ToListAsync());
        }

        // GET: Classes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classesModel = await _context.ClassesModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (classesModel == null)
            {
                return NotFound();
            }

            return View(classesModel);
        }

        // GET: Classes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Classes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Stream")] ClassesModel classesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classesModel);
        }

        // GET: Classes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classesModel = await _context.ClassesModel.FindAsync(id);
            if (classesModel == null)
            {
                return NotFound();
            }
            return View(classesModel);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Stream")] ClassesModel classesModel)
        {
            if (id != classesModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassesModelExists(classesModel.ID))
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
            return View(classesModel);
        }

        // GET: Classes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classesModel = await _context.ClassesModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (classesModel == null)
            {
                return NotFound();
            }

            return View(classesModel);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classesModel = await _context.ClassesModel.FindAsync(id);
            _context.ClassesModel.Remove(classesModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassesModelExists(int id)
        {
            return _context.ClassesModel.Any(e => e.ID == id);
        }
    }
}
