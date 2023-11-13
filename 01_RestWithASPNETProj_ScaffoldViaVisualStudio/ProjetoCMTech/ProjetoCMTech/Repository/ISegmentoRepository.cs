using ProjetoCMTech.Model;

namespace ProjetoCMTech.Repository
{
    public interface ISegmentoRepository
    {
        Segmento Create(Segmento segmento);

        Segmento FindByID(long id);
        List<Segmento> FindAll();

        Segmento Update(Segmento segmento);

        void Delete(long id);

        bool Exists(long id);

    }
}
