using HeatWise_Sprint_2.Net.Persistencia.Models;

namespace HeatWise_Sprint_2.Net.Interface
{
    public interface IEmpresaRepositorio
    {
        IEnumerable<Empresa> GetAll();

        Empresa GetById(long id);

        void Add(Empresa empresa);

        void Update(Empresa empresa);

        void Delete(Empresa empresa);
    }
}
