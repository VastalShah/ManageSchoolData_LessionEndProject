using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage_School_Data.Controllers
{
    public class BaseController<T> : Controller where T: BaseModel
    {
        private readonly IBaseRepository<T> _context;

        public BaseController(IBaseRepository<T> context)
        {
            _context = context;
        }

        // GET: Classes
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll());
        }

        // GET: Classes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TModel = await _context.Get(id);
            if (TModel == null)
            {
                return NotFound();
            }

            return View(TModel);
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
        public async Task<IActionResult> Create(T TModel)
        {
            if (ModelState.IsValid)
            {
                await _context.Insert(TModel);
                return RedirectToAction(nameof(Index));
            }
            return View(TModel);
        }

        // GET: Classes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TModel = await _context.Get(id);
            if (TModel == null)
            {
                return NotFound();
            }
            return View(TModel);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, T TModel)
        {
            if (id != TModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _context.Update(TModel);

                return RedirectToAction(nameof(Index));
            }
            return View(TModel);
        }

        // GET: Classes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TModel = await _context.Get(id);
            if (TModel == null)
            {
                return NotFound();
            }

            return View(TModel);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
