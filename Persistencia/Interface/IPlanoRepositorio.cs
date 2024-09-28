using HeatWise_Sprint_2.Net.Persistencia.Models;

namespace HeatWise_Sprint_2.Net.Interface
{
    public interface IPlanoRepositorio
    {
        IEnumerable<Plano> GetAll();

        Plano GetById(int? id);

        void Add(Plano plano);

        void Update(Plano plano);

        void Delete(Plano plano);
    }
}
