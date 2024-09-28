using HeatWise_Sprint_2.Net.Interface;
using HeatWise_Sprint_2.Net.Persistencia.Models;

namespace HeatWise_Sprint_2.Net.Persistence.Repositorio
{
    public class EmpresaRepositorio : IEmpresaRepositorio
    {
        private readonly HeatWiseDbContext _context;

        public EmpresaRepositorio(HeatWiseDbContext context)
        {
            _context = context;
        }

        public void Add(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            _context.SaveChanges();
        }

        public void Delete(Empresa empresa)
        {
            _context.Empresas.Remove(empresa);
            _context.SaveChanges();
        }

        public IEnumerable<Empresa> GetAll()
        {
            return _context.Empresas.ToList();
        }

        public Empresa GetById(int? id)
        {
            return _context.Empresas.Find(id);
        }

        public Empresa GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(Empresa empresa)
        {
            _context.Empresas.Update(empresa);
            _context.SaveChanges();
        }
    }
}
