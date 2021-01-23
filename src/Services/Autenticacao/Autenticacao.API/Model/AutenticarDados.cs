using System;
using System.Linq;
using Sigo.Autenticacao.API.Infrasctructure;
using Sigo.Autenticacao.API.Model;

namespace Sigo.Autenticacao.API.Model
{
    public class DadosAcesso
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
