using HeatWise_Sprint_2.Net.Interface;
using HeatWise_Sprint_2.Net.Persistence;
using HeatWise_Sprint_2.Net.Persistencia.Models;

namespace HeatWise_Sprint_2.Net.Repositorios
{
    public class PlanoRepositorio : IPlanoRepositorio
    {
        private readonly HeatWiseDbContext _context;

        public PlanoRepositorio(HeatWiseDbContext context)
        {
            _context = context;
        }

        public void Add(Plano plano)
        {
            _context.Planos.Add(plano);
            _context.SaveChanges();
        }

        public void Delete(Plano plano)
        {
            _context.Planos.Remove(plano);
            _context.SaveChanges();
        }

        public IEnumerable<Plano> GetAll()
        {
            return _context.Planos.ToList();
        }

        public Plano GetById(int? id)
        {
            return _context.Planos.Find(id);
        }

        public void Update(Plano plano)
        {
            _context.Planos.Update(plano);
            _context.SaveChanges();
        }
    }
}
