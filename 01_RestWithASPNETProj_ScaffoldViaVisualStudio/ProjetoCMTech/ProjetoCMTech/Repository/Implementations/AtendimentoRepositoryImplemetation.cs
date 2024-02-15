using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;
using ProjetoCMTech.Model.Context;
using System;

namespace ProjetoCMTech.Repository.Implementations
{
    public class AtendimentoRepositoryImplemetation : IAtendimentoRepository
    {
        private PostgreSQLContext _context;

        public AtendimentoRepositoryImplemetation(PostgreSQLContext context)
        {
            _context = context;
        }
       public List<Atendimento> FindAll(AtendimentoPesquisaVO pesquisa = null)
        {
           
            var list = _context.Atendimentos
                .Include (x => x.Departamento)
                .Include (x => x.Organizacao)
                .Include (x => x.StatusAtendimento)
                .Include (x => x.Usuario)
                .Include (x => x.Cliente)
                
                .AsQueryable();
            list = FindAllFilter(list, pesquisa);
                 return list.ToList();
        }

        public int FindAllCount(AtendimentoPesquisaVO pesquisa = null)
        {

            var list = _context.Atendimentos
                      .Include(x => x.Departamento)
                      .Include(x => x.Organizacao)
                      .Include(x => x.StatusAtendimento)
                      .Include(x => x.Usuario)
                      .Include(x => x.Cliente)
                      
                      .AsQueryable();
                      
                list = FindAllFilter(list, pesquisa);
                       return list.Count();
        }

        private IQueryable<Atendimento>FindAllFilter(IQueryable<Atendimento> list, AtendimentoPesquisaVO pesquisa)
        {
            if (pesquisa != null)
            {
                if (!string.IsNullOrEmpty(pesquisa.Nome))
                    list = list.Where(x => EF.Functions.Like(x.Usuario.Nome.Trim().ToLower(), $"%{pesquisa.Nome.Trim().ToLower()}%"));
                if (!string.IsNullOrEmpty(pesquisa.Area))
                    list = list.Where(x => EF.Functions.Like(x.Departamento.Nome.Trim().ToLower(), $"%{pesquisa.Area.Trim().ToLower()}%"));
                if (!string.IsNullOrEmpty(pesquisa.Canal))
                    list = list.Where(x => EF.Functions.Like(x.StatusAtendimento.Nome.Trim().ToLower(), $"%{pesquisa.Canal.Trim().ToLower()}"));
                if (pesquisa.PeriodoDe != null)
                    list = list.Where(x => x.DataHoraAtendimento >= pesquisa.PeriodoDe);
                if (pesquisa.Ate != null)
                    list = list.Where(x => x.DataHoraAtendimento <= pesquisa.Ate);

            }
            return list;
        }



        public Atendimento FindByID(long id)
        {
            return _context.Atendimentos
                .Include (x => x.Departamento)
                .Include (x => x.Organizacao)
                .Include (x => x.StatusAtendimento)
                .Include (x => x.Usuario)
                 // .ThenInclude(u => u.Perfil) :recupera o include do include (ex: perfil do usuário)
                .Include (x => x.Cliente)
                
                .SingleOrDefault (p => p.Id.Equals(id));
        }

        public Atendimento Create(Atendimento atendimento)
        {
            try
            {
                _context.Add(atendimento);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return atendimento;
        }
       public Atendimento Update(Atendimento atendimento)
        {
            if(!Exists(atendimento.Id)) return null;

            var result = _context.Atendimentos.FirstOrDefault(p => p.Id.Equals(atendimento.Id));

            if(result != null)
            {
                 try
                            {
                                _context.Entry(result).CurrentValues.SetValues(atendimento);
                                _context.SaveChanges();
                            }
                            catch (Exception)
                            {

                                throw;
                            }
            }

           
            return atendimento;
        }
        public void Delete(long id)
        {
            var result = _context.Atendimentos.FirstOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Atendimentos.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

 
 

        public bool Exists(long id)
        {
            return _context.Atendimentos.Any(p => p.Id.Equals(id));
        }
    }
}
