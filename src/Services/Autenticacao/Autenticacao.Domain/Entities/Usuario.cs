﻿using SIGO.Autenticacao.Domain.Enums;

namespace SIGO.Autenticacao.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public byte[] SenhaHash { get; set; }
        public byte[] SenhaSalt { get; set; }
        public StatusUsuario Status { get; set; } = StatusUsuario.Ativo;
    }
}
