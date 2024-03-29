﻿using ProjetoCMTech.Configuration;
using ProjetoCMTech.Data.Converter.Implementations;
using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;
using ProjetoCMTech.Repository;
using ProjetoCMTech.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace ProjetoCMTech.Business.Implementations
{
    public class LoginBusinessImplementation : ILoginBusiness
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private TokenConf _conf;

        private IUsuarioRepository _repository;
        private readonly ITokenService _tokenService;
        private readonly UsuarioConverter _converter;

        public LoginBusinessImplementation(TokenConf conf, IUsuarioRepository repository, ITokenService tokenService)
        {
            _conf = conf;
            _repository = repository;
            _tokenService = tokenService;
            _converter = new UsuarioConverter();
        }

        public TokenVO ValidateCredentials(UsuarioLoginVO usuarioCredentials)
        {
            var usuario = _repository.ValidateCredentials(usuarioCredentials);
            if (usuario == null) return null;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Email)

            };
            var accessToken = _tokenService.GenerateAccessToken(claims);


            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_conf.Minutes);

            var usuarioVO = _converter.Parse(usuario);

            return new TokenVO(
                true,
                createDate.ToString(DATE_FORMAT)
                , expirationDate.ToString(DATE_FORMAT),
                accessToken,
                usuarioVO
               
                );
        }
    }
}
