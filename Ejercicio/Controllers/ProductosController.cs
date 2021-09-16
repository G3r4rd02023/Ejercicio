using Ejercicio.Data;
using Ejercicio.Data.Entities;
using Ejercicio.Helpers;
using Ejercicio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejercicio.Controllers
{
    public class ProductosController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;

        public ProductosController(DataContext context, ICombosHelper combosHelper,IConverterHelper converterHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Productos
                .Include(p => p.Zona)
                .Include(p => p.Presentacion)
                .Include(p => p.Marca)
                .Include(p => p.Proovedor)
                .ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.Zona)
                .Include(p => p.Presentacion)
                .Include(p => p.Marca)
                .Include(p => p.Proovedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        public IActionResult Create()
        {
            ProductViewModel model = new ProductViewModel
            {
                Marcas = _combosHelper.GetComboMarcas(),
                Presentaciones = _combosHelper.GetComboPresentaciones(),
                Proveedores = _combosHelper.GetComboProveedores(),
                Zonas =_combosHelper.GetComboZonas()               
            };
            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var producto = await _converterHelper.ToProductAsync(model, true);
                    _context.Add(producto);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un producto con ese código.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                 .Include(p => p.Zona)
                .Include(p => p.Presentacion)
                .Include(p => p.Marca)
                .Include(p => p.Proovedor)
                 .FirstOrDefaultAsync(p => p.Id == id);
            
            if (producto == null)
            {
                return NotFound();
            }
            ProductViewModel model = _converterHelper.ToProductViewModel(producto);
            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var producto = await _converterHelper.ToProductAsync(model, false);
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un producto con ese código.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            model.Marcas = _combosHelper.GetComboMarcas();
            model.Presentaciones = _combosHelper.GetComboPresentaciones();
            model.Proveedores = _combosHelper.GetComboProveedores();
            model.Zonas = _combosHelper.GetComboZonas();
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.Productos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
