using HeatWise_Sprint_2.Net.Interface;
using HeatWise_Sprint_2.Net.Persistencia.Models;

namespace HeatWise_Sprint_2.Net.Persistence.Repositorio
{
    public class SiteRepositorio : ISiteRepositorio
    {
        private readonly HeatWiseDbContext _context;

        public SiteRepositorio(HeatWiseDbContext context)
        {
            _context = context;
        }

        public void Add(Site site)
        {
            _context.Sites.Add(site);
            _context.SaveChanges();
        }

        public void Delete(Site site)
        {
            _context.Sites.Remove(site);
            _context.SaveChanges();
        }

        public IEnumerable<Site> GetAll()
        {
            return _context.Sites.ToList();
        }

        public Site GetById(int? id)
        {
            return _context.Sites.Find(id);
        }

        public Site GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(Site site)
        {
            _context.Sites.Update(site);
            _context.SaveChanges();
        }
    }
}
