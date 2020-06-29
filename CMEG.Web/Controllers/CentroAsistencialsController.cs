using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CMEG.Web.Data;
using CMEG.Web.Data.Entities;
using CMEG.Web.Helpers;
using CMEG.Web.Models;
using Microsoft.AspNetCore.Builder;

namespace CMEG.Web.Controllers
{
    public class CentroAsistencialsController : Controller
    {
        private readonly DataContext _context;
        private readonly IImageHelper _imageHelper;
        private readonly IConverterHelper _converterHelper;

        public CentroAsistencialsController(DataContext context, IImageHelper imageHelper, IConverterHelper converterHelper)
        {
            _context = context;
            _imageHelper = imageHelper;
            _converterHelper = converterHelper;
        }

        // GET: CentroAsistencials
        public async Task<IActionResult> Index()
        {
            return View(await _context.CentrosAsistenciales.ToListAsync());
        }

        // GET: CentroAsistencials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CentroAsistencial centroAsistencial = await _context.CentrosAsistenciales.FindAsync(id);
            if (centroAsistencial == null)
            {
                return NotFound();
            }

            CentroAsistencialViewModel centroAsistencialViewModel = _converterHelper.ToCentroAsistencialViewModel(centroAsistencial);

            return View(centroAsistencialViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CentroAsistencialViewModel model)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;
                if (model.LogoFile !=  null)
                {
                    path = await _imageHelper.UpLoadImageAsync(model.LogoFile, "Centros");
                }

                CentroAsistencial centroAsistencial = _converterHelper.ToCentroAsistencial(model, path, true);

                _context.Add(centroAsistencial);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, $"Centro Asistencial {centroAsistencial.Nombre} ya existe");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
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

            CentroAsistencial centroAsistencial = await _context.CentrosAsistenciales.FindAsync(id);
            if (centroAsistencial == null)
            {
                return NotFound();
            }

            CentroAsistencialViewModel centroAsistencialViewModel = _converterHelper.ToCentroAsistencialViewModel(centroAsistencial);
            return View(centroAsistencialViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CentroAsistencialViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var path = model.Logo;
                if (model.LogoFile != null)
                {
                    path = await _imageHelper.UpLoadImageAsync(model.LogoFile, "Centros");
                }

                CentroAsistencial entity = _converterHelper.ToCentroAsistencial(model, path, false);

                _context.Update(entity);
                try
                {                    
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, $"Centro Asistencial {model.Nombre} ya existe");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CentroAsistencial centroAsistencial = await _context.CentrosAsistenciales.FirstOrDefaultAsync(m => m.Id == id);
            if (centroAsistencial == null)
            {
                return NotFound();
            }

            _context.CentrosAsistenciales.Remove(centroAsistencial);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool CentroAsistencialExists(int id)
        {
            return _context.CentrosAsistenciales.Any(e => e.Id == id);
        }
    }
}
