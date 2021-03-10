using System;

namespace SIGO.Autenticacao.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public DateTime? UltimoAcesso { get; set; }
    }
}
