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
    public class AnalisesController : Controller
    {
        private readonly HeatWiseDbContext _context;

        public AnalisesController(HeatWiseDbContext context)
        {
            _context = context;
        }

        // GET: Analises
        public async Task<IActionResult> Index()
        {
            var heatWiseDbContext = _context.Analises.Include(a => a.Site);
            return View(await heatWiseDbContext.ToListAsync());
        }

        // GET: Analises/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analise = await _context.Analises
                .Include(a => a.Site)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (analise == null)
            {
                return NotFound();
            }

            return View(analise);
        }

        // GET: Analises/Create
        public IActionResult Create()
        {
            ViewData["SiteId"] = new SelectList(_context.Sites, "Id", "Nome");
            return View();
        }

        // POST: Analises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Relatorio,TempoTelaAtiva,TempoInatividade,NumeroCliquesMouse,NumeroTeclasPressionadas,TempoMedioConclusaoTarefas,TarefasConcluidasPorTempo,TaxaErros,TempoMedioCorrecaoErros,IndiceEficiencia,SatisfacaoUsuario,SiteId")] Analise analise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(analise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SiteId"] = new SelectList(_context.Sites, "Id", "Nome", analise.SiteId);
            _context.Add(analise);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Analises/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analise = await _context.Analises.FindAsync(id);
            if (analise == null)
            {
                return NotFound();
            }
            ViewData["SiteId"] = new SelectList(_context.Sites, "Id", "Nome", analise.SiteId);
            return View(analise);
        }

        // POST: Analises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Relatorio,TempoTelaAtiva,TempoInatividade,NumeroCliquesMouse,NumeroTeclasPressionadas,TempoMedioConclusaoTarefas,TarefasConcluidasPorTempo,TaxaErros,TempoMedioCorrecaoErros,IndiceEficiencia,SatisfacaoUsuario,SiteId")] Analise analise)
        {
            if (id != analise.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(analise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnaliseExists(analise.Id))
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
            ViewData["SiteId"] = new SelectList(_context.Sites, "Id", "Nome", analise.SiteId);
            _context.Update(analise);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Analises/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analise = await _context.Analises
                .Include(a => a.Site)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (analise == null)
            {
                return NotFound();
            }

            return View(analise);
        }

        // POST: Analises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var analise = await _context.Analises.FindAsync(id);
            if (analise != null)
            {
                _context.Analises.Remove(analise);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnaliseExists(long id)
        {
            return _context.Analises.Any(e => e.Id == id);
        }
    }
}
