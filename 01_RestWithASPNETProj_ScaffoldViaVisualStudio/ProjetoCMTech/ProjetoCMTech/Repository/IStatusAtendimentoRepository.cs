using ProjetoCMTech.Model;

namespace ProjetoCMTech.Repository
{
    public interface IStatusAtendimentoRepository
    {
        StatusAtendimento Create(StatusAtendimento statusatendimento);

        StatusAtendimento FindByID(long id);
        List<StatusAtendimento> FindAll();

        StatusAtendimento Update(StatusAtendimento statusatendimento);

        void Delete(long id);

        bool Exists(long id);

    }
}
