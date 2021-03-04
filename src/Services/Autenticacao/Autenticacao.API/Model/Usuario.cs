using System;

namespace Sigo.Autenticacao.API.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataUltimaAtualizacao { get; set; }
        // public List<Acesso> UsuarioxSistema { get; set; }
    }
}
