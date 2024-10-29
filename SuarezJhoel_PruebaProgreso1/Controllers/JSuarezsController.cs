using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuarezJhoel_PruebaProgreso1.Data;
using SuarezJhoel_PruebaProgreso1.Models;

namespace SuarezJhoel_PruebaProgreso1.Controllers
{
    public class JSuarezsController : Controller
    {
        private readonly SuarezJhoel_PruebaProgreso1Context _context;

        public JSuarezsController(SuarezJhoel_PruebaProgreso1Context context)
        {
            _context = context;
        }

        // GET: JSuarezs
        public async Task<IActionResult> Index()
        {
            var suarezJhoel_PruebaProgreso1Context = _context.JSuarez.Include(j => j.Celular);
            return View(await suarezJhoel_PruebaProgreso1Context.ToListAsync());
        }

        // GET: JSuarezs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jSuarez = await _context.JSuarez
                .Include(j => j.Celular)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jSuarez == null)
            {
                return NotFound();
            }

            return View(jSuarez);
        }

        // GET: JSuarezs/Create
        public IActionResult Create()
        {
            ViewData["IdCelular"] = new SelectList(_context.Set<Celular>(), "Id", "Modelo");
            return View();
        }

        // POST: JSuarezs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Correo,Edad,Donante_de_organos,FechaNaciemiento,IdCelular")] JSuarez jSuarez)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jSuarez);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCelular"] = new SelectList(_context.Set<Celular>(), "Id", "Modelo", jSuarez.IdCelular);
            return View(jSuarez);
        }

        // GET: JSuarezs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jSuarez = await _context.JSuarez.FindAsync(id);
            if (jSuarez == null)
            {
                return NotFound();
            }
            ViewData["IdCelular"] = new SelectList(_context.Set<Celular>(), "Id", "Modelo", jSuarez.IdCelular);
            return View(jSuarez);
        }

        // POST: JSuarezs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Correo,Edad,Donante_de_organos,FechaNaciemiento,IdCelular")] JSuarez jSuarez)
        {
            if (id != jSuarez.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jSuarez);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JSuarezExists(jSuarez.Id))
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
            ViewData["IdCelular"] = new SelectList(_context.Set<Celular>(), "Id", "Modelo", jSuarez.IdCelular);
            return View(jSuarez);
        }

        // GET: JSuarezs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jSuarez = await _context.JSuarez
                .Include(j => j.Celular)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jSuarez == null)
            {
                return NotFound();
            }

            return View(jSuarez);
        }

        // POST: JSuarezs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jSuarez = await _context.JSuarez.FindAsync(id);
            if (jSuarez != null)
            {
                _context.JSuarez.Remove(jSuarez);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JSuarezExists(int id)
        {
            return _context.JSuarez.Any(e => e.Id == id);
        }
    }
}
