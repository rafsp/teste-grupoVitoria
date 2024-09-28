using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HeatWise_Sprint_2.Net.Persistence;
using HeatWise_Sprint_2.Net.Persistencia.Models;

namespace HeatWise_Sprint_2.Net.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly HeatWiseDbContext _context;

        public EmpresasController(HeatWiseDbContext context)
        {
            _context = context;
        }

        // GET: Empresas
        public async Task<IActionResult> Index()
        {
            var heatWiseDbContext = _context.Empresas.Include(e => e.Plano);
            return View(await heatWiseDbContext.ToListAsync());
        }
        // GET: Empresas/Details/5
        public async Task<IActionResult> Details(long? id)

        {

            if (id == null)
            {
                return NotFound();
            }

            ViewData["PlanoId"] = new SelectList(_context.Planos, "PlanoId", "Nome");

            var empresa = await _context.Empresas
                .Include(e => e.Plano)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empresa == null)

            {
                return NotFound();
            }

            return View(empresa);
        }

        // GET: Empresas/Create
        public IActionResult Create()
        {
            ViewData["PlanoId"] = new SelectList(_context.Planos, "PlanoId", "Nome");
            return View();
        }

        // POST: Empresas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,CNPJ,Email,Telefone,FormaPagamento,PlanoId")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                var ultimoId2 = await _context.Empresas.MaxAsync(e => (int?)e.Id) ?? 0;
                empresa.Id = ultimoId2 + 1;

                _context.Add(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = empresa.Id });
            }
            var ultimoId = await _context.Empresas.MaxAsync(e => (int?)e.Id) ?? 0;
            empresa.Id = ultimoId + 1;

            _context.Add(empresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = empresa.Id });
        }


        // GET: Empresas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }
            ViewData["PlanoId"] = new SelectList(_context.Planos, "PlanoId", "Nome", empresa.PlanoId);
            return View(empresa);
        }

        // POST: Empresas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Nome,CNPJ,Email,Telefone,FormaPagamento,PlanoId")] Empresa empresa)
        {
            if (id != empresa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpresaExists(empresa.Id))
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
            ViewData["PlanoId"] = new SelectList(_context.Planos, "PlanoId", "Nome", empresa.PlanoId);
            return View(empresa);
        }

        // GET: Empresas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas
                .Include(e => e.Plano)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa != null)
            {
                _context.Empresas.Remove(empresa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpresaExists(long id)
        {
            return _context.Empresas.Any(e => e.Id == id);
        }
    }
}
