using HeatWise_Sprint_2.Net.Persistencia.Models;

namespace HeatWise_Sprint_2.Net.Interface
{
    public interface ISiteRepositorio
    {
        IEnumerable<Site> GetAll();

        Site GetById(long id);

        void Add(Site site);

        void Update(Site site);

        void Delete(Site site);
    }
}
