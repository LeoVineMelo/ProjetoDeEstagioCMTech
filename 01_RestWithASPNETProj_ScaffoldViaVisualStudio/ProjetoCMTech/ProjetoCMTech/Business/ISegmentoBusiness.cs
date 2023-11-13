using ProjetoCMTech.Model;

namespace ProjetoCMTech.Business
{
    public interface ISegmentoBusiness
    {
        SegmentoVO Create(SegmentoVO segmento);

        SegmentoVO FindByID(long id);
        List<SegmentoVO> FindAll();

        SegmentoVO Update(SegmentoVO segmento);

        void Delete(long id);

    }
}
