using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SIGO.Autenticacao.Domain.Entities;
using SIGO.Autenticacao.Domain.Interfaces.Services;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SIGO.Autenticacao.Service.Services
{
    public class TokenService : IServiceToken
    {
        public string GerarToken(Usuario usuario)
        {
            //
            var tokenHandler = new JwtSecurityTokenHandler();
            //
            var chavetoken = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Chavedeacesso");
            var key = Encoding.ASCII.GetBytes(chavetoken.ToString());
            //
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nome.ToString()),
                    new Claim(ClaimTypes.Email, usuario.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            //
            var token = tokenHandler.CreateToken(tokenDescriptor);
            //
            return tokenHandler.WriteToken(token);
        }
    }
}
