using ProjetoCMTech.Model;

namespace ProjetoCMTech.Repository
{
    public interface IAtendimentoRepository
    {
        Atendimento Create(Atendimento atendimento);

        Atendimento FindByID(long id);
        List<Atendimento> FindAll();

        Atendimento Update(Atendimento atendimento);

        void Delete(long id);

        bool Exists(long id);

    }
}
