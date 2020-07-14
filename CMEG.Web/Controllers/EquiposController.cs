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

namespace CMEG.Web.Controllers
{
    public class EquiposController : Controller
    {
        private readonly DataContext _context;
        private readonly IConverterHelper _converterHelper;
        private readonly IImageHelper _imageHelper;

        public EquiposController(DataContext context, IConverterHelper converterHelper, IImageHelper imageHelper)
        {
            _context = context;
            _converterHelper = converterHelper;
            _imageHelper = imageHelper;
        }

        // GET: Equipos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Equipos.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Equipo equipo = await _context.Equipos.FirstOrDefaultAsync(m => m.Id == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EquipoViewModel model)
        {
            if (ModelState.IsValid)
            {
                string path = string.Empty;
                if (model.LogoFile != null)
                {
                    path = await _imageHelper.UpLoadImageAsync(model.LogoFile, "Equipos");
                }

                Equipo equipo = _converterHelper.ToEquipo(model, path, true);

                _context.Add(equipo);
                await _context.SaveChangesAsync();
                
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Equipo equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }

            EquipoViewModel model = _converterHelper.ToEquipoViewModel(equipo);

            return View(model);
        }

        // POST: Equipos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EquipoViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string path = model.Logo;
                if (model.LogoFile != null)
                {
                    path = await _imageHelper.UpLoadImageAsync(model.LogoFile, "Equipos");
                }

                Equipo equipo = _converterHelper.ToEquipo(model, path, false);
                if (equipo == null)
                {
                    return NotFound();
                }

                _context.Update(equipo);
                await _context.SaveChangesAsync();         
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Equipo equipo = await _context.Equipos.FirstOrDefaultAsync(m => m.Id == id);
            if (equipo == null)
            {
                return NotFound();
            }

            _context.Equipos.Remove(equipo);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool EquipoExists(int id)
        {
            return _context.Equipos.Any(e => e.Id == id);
        }
    }
}
