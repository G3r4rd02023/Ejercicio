using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ejercicio.Data;
using Ejercicio.Data.Entities;

namespace Ejercicio.Controllers
{
    public class PresentacionesController : Controller
    {
        private readonly DataContext _context;

        public PresentacionesController(DataContext context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index()
        {
            return View(await _context.Presentaciones.ToListAsync());
        }

       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presentacion = await _context.Presentaciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (presentacion == null)
            {
                return NotFound();
            }

            return View(presentacion);
        }

       
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Presentacion presentacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(presentacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(presentacion);
        }

        // GET: Presentaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presentacion = await _context.Presentaciones.FindAsync(id);
            if (presentacion == null)
            {
                return NotFound();
            }
            return View(presentacion);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Presentacion presentacion)
        {
            if (id != presentacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(presentacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PresentacionExists(presentacion.Id))
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
            return View(presentacion);
        }

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presentacion = await _context.Presentaciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (presentacion == null)
            {
                return NotFound();
            }

            return View(presentacion);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var presentacion = await _context.Presentaciones.FindAsync(id);
            _context.Presentaciones.Remove(presentacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PresentacionExists(int id)
        {
            return _context.Presentaciones.Any(e => e.Id == id);
        }
    }
}
