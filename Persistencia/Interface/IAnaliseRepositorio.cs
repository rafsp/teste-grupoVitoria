using HeatWise_Sprint_2.Net.Persistencia.Models;

namespace HeatWise_Sprint_2.Net.Interface
{
    public interface IAnaliseRepositorio
    {
        IEnumerable<Analise> GetAll();

        Analise GetById(long id);

        void Add(Analise analise);

        void Update(Analise analise);

        void Delete(Analise analise);
    }
}
