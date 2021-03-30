using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SIGO.Autenticacao.Domain.Entities;
using SIGO.Autenticacao.Domain.Interfaces.Services;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SIGO.Autenticacao.Service.Services
{
    public class TokenService : IServiceToken
    {
        public string GerarToken(Usuario usuario)
        {
            //
            var tokenHandler = new JwtSecurityTokenHandler();
            //
            var parametro = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var chavetoken = parametro.GetSection("Chavedeacesso");
            var tempoExpiracao = parametro.GetSection("TempoExpiracaoTokenMinutos").Value;
            int tempoExpiracaoTokenMinutos = Convert.ToInt32(tempoExpiracao);

            //int tempoExpiracaoTokenMinutos = 2;
            var key = Encoding.ASCII.GetBytes(chavetoken.Value);
            //
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, usuario.Email.ToString()),
                    new Claim(ClaimTypes.Role, usuario.Perfil.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(tempoExpiracaoTokenMinutos),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            //
            var token = tokenHandler.CreateToken(tokenDescriptor);
            //
            return tokenHandler.WriteToken(token);
        }
    }
}
