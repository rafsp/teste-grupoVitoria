using HeatWise_Sprint_2.Net.Interface;
using HeatWise_Sprint_2.Net.Persistencia.Models;


namespace HeatWise_Sprint_2.Net.Persistence.Repositorio
{
    public class AnaliseRepositorio : IAnaliseRepositorio
    {
        private readonly HeatWiseDbContext _context;

        public AnaliseRepositorio(HeatWiseDbContext context)
        {
            _context = context;
        }

        public void Add(Analise analise)
        {
            _context.Analises.Add(analise);
            _context.SaveChanges();
        }

        public void Delete(Analise analise)
        {
            _context.Analises.Remove(analise);
            _context.SaveChanges();
        }

        public IEnumerable<Analise> GetAll()
        {
            return _context.Analises.ToList();
        }

        public Analise GetById(long id)
        {
            return _context.Analises.FirstOrDefault(a => a.Id == id);
        }

        public void Update(Analise analise)
        {
            _context.Analises.Update(analise);
            _context.SaveChanges();
        }
    }
}
