namespace SIGO.Autenticacao.Domain.Enums
{
    public enum PerfilUsuario : short
    {
        Colaborador,
        Gerente,
        Admin = short.MaxValue
    }
}
