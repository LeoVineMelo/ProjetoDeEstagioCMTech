﻿using ProjetoCMTech.Data.Converter.Contract;
using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;

namespace ProjetoCMTech.Data.Converter.Implementations
{
    public class UsuarioCoverter : IParser<UsuarioVO, Usuario>, IParser<Usuario, UsuarioVO>
    {
        public Usuario Parse(UsuarioVO origin)
        {
            if (origin == null) return null;
            return new Usuario
            {
                Id = origin.Id,
                DepartamentoId = origin.DepartamentoId,
                OrganizacaoId = origin.OrganizacaoId,
                PerfilId = origin.PerfilId,
                Nome = origin.Nome,
                Email = origin.Email,
                Senha = origin.Senha,
                DataCadastro = origin.DataCadastro,
                

            };
        }
        public UsuarioVO Parse(Usuario origin)
        {
            if (origin == null) return null;
            return new UsuarioVO
            {
                Id = origin.Id,
                DepartamentoId = origin.DepartamentoId,
                OrganizacaoId = origin.OrganizacaoId,
                PerfilId = origin.PerfilId,
                Nome = origin.Nome,
                Email = origin.Email,
                Senha = origin.Senha,
                DataCadastro = origin.DataCadastro,
            };
        }

        public List<UsuarioVO> Parse(List<Usuario> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
        public List<Usuario> Parse(List<UsuarioVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

    }
}
