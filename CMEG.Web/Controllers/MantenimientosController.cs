using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CMEG.Web.Data;
using CMEG.Web.Data.Entities;
using CMEG.Web.Models;
using CMEG.Web.Helpers;
using SQLitePCL;

namespace CMEG.Web.Controllers
{
    public class MantenimientosController : Controller
    {
        private readonly DataContext _context;
        private readonly IConverterHelper _converter;
        private readonly IComboBoxHelper _combo;

        public MantenimientosController(DataContext context, IConverterHelper converter, IComboBoxHelper combo)
        {
            _context = context;
            _converter = converter;
            _combo = combo;
        }

        // GET: Mantenimientos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mantenimientos.ToListAsync());
        }

        // GET: Mantenimientos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mantenimiento = await _context.Mantenimientos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mantenimiento == null)
            {
                return NotFound();
            }

            return View(mantenimiento);
        }

        public IActionResult Create()
        {
            Mantenimiento entity = _context.Mantenimientos.FirstOrDefault();
            if (entity == null)
            {
                return NotFound();
            }

            MantenimientoViewModel model = new MantenimientoViewModel
            {
                Equipos = _combo.GetComboEquipos(),
                FechaInstalacion = entity.Equipo.FechaInstalacion
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MantenimientoViewModel model)
        {
            if (ModelState.IsValid)
            {
                Mantenimiento entity = await _converter.ToMantenimientoEntityAsync(model, true);

                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            //model.Equipos = _combo.GetComboEquipos();

            return View(model);
        }

        // GET: Mantenimientos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mantenimiento = await _context.Mantenimientos.FindAsync(id);
            if (mantenimiento == null)
            {
                return NotFound();
            }
            return View(mantenimiento);
        }

        // POST: Mantenimientos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaProgramacion,AñoEjecucion,NumeroMantenimiento")] Mantenimiento mantenimiento)
        {
            if (id != mantenimiento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mantenimiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MantenimientoExists(mantenimiento.Id))
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
            return View(mantenimiento);
        }

        // GET: Mantenimientos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mantenimiento = await _context.Mantenimientos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mantenimiento == null)
            {
                return NotFound();
            }

            return View(mantenimiento);
        }

        // POST: Mantenimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mantenimiento = await _context.Mantenimientos.FindAsync(id);
            _context.Mantenimientos.Remove(mantenimiento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MantenimientoExists(int id)
        {
            return _context.Mantenimientos.Any(e => e.Id == id);
        }
    }
}
