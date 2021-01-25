using System;
using System.Collections.Generic;
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

    public class Autenticado
    {
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Token { get; set; }
        public List<AcessosSistemas> AcessosSistemas { get; set; }
    }

    public class AcessosSistemas    {
        public string Sistema { get; set; }
        public string Regra { get; set; }
    }
}
