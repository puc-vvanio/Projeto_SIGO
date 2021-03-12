namespace SIGO.Autenticacao.Domain.Enums
{
    public enum StatusUsuario : short
    {
        Ativo,
        Bloqueado,
        Inativo = short.MaxValue
    }
}
