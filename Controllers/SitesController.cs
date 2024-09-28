using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HeatWise_Sprint_2.Net.Persistence;
using HeatWise_Sprint_2.Net.Persistencia.Models;

namespace HeatWise_Sprint_2.Net.Controllers
{
    public class SitesController : Controller
    {
        private readonly HeatWiseDbContext _context;

        public SitesController(HeatWiseDbContext context)
        {
            _context = context;
        }

        // GET: Sites
        public async Task<IActionResult> Index()
        {
            var heatWiseDbContext = _context.Sites.Include(s => s.Empresa);
            return View(await heatWiseDbContext.ToListAsync());
        }

        // GET: Sites/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewData["PlanoId"] = new SelectList(_context.Planos, "PlanoId", "Nome");

            var site = await _context.Sites
                .Include(s => s.Empresa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // GET: Sites/Create
        public IActionResult Create()
        {
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Nome");
            return View();
        }

        // POST: Sites/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,URL,Descricao,Usuario,EmpresaId")] Site site)
        {
            if (ModelState.IsValid)
            {
                var ultimoId = await _context.Sites.MaxAsync(s => (int?)s.Id) ?? 0;
                site.Id = ultimoId + 1;

                _context.Add(site);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = site.Id });
            }
            var ultimoId2 = await _context.Sites.MaxAsync(s => (int?)s.Id) ?? 0;
            site.Id = ultimoId2 + 1;

            _context.Add(site);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = site.Id });
        }


        // GET: Sites/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.Sites.FindAsync(id);
            if (site == null)
            {
                return NotFound();
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Nome", site.EmpresaId);
            return View(site);
        }

        // POST: Sites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Nome,URL,Descricao,Usuario,EmpresaId")] Site site)
        {
            if (id != site.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(site);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiteExists(site.Id))
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
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Nome", site.EmpresaId);
            _context.Update(site);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Sites/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.Sites
                .Include(s => s.Empresa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // POST: Sites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var site = await _context.Sites.FindAsync(id);
            if (site != null)
            {
                _context.Sites.Remove(site);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiteExists(long id)
        {
            return _context.Sites.Any(e => e.Id == id);
        }
    }
}
