using ProjetoCMTech.Model;

namespace ProjetoCMTech.Business
{
    public interface IGrupoBusiness
    {
        GrupoVO Create(GrupoVO grupo);

        GrupoVO FindByID(long id);
        List<GrupoVO> FindAll();

        GrupoVO Update(GrupoVO grupo);

        void Delete(long id);

    }
}
