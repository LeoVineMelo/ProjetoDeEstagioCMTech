using ProjetoCMTech.Model;

namespace ProjetoCMTech.Repository
{
    public interface IDepartamentoRepository
    {
        Departamento Create(Departamento departamento);

        Departamento FindByID(long id);
        List<Departamento> FindAll();

        Departamento Update(Departamento departamento);

        void Delete(long id);

        bool Exists(long id);

    }
}
