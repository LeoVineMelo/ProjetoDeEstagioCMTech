using ProjetoCMTech.Model;

namespace ProjetoCMTech.Business
{
    public interface IDepartamentoBusiness
    {
        DepartamentoVO Create(DepartamentoVO departamento);

        DepartamentoVO FindByID(long id);
        List<DepartamentoVO> FindAll();

        DepartamentoVO Update(DepartamentoVO departamento);

        void Delete(long id);

    }
}
