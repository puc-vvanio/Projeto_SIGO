using System;

namespace SIGO.Autenticacao.Infrastructure.CrossCutting.Security
{
    public static class SenhaHelper
    {

        /**
         * Method:    CriarSenhaHash
         *            Criador de senha criptografada para o usuário
         * FullName:  CriarSenhaHash
         * Access:    private 
         * Qualifier:
         * @param    string senha
         * @return   byte[] senhaSalt
         * @return   byte[] senhaHash
         */
        public static void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt)
        {
            if (senha == null)
                throw new ArgumentNullException("senha");

            if (string.IsNullOrWhiteSpace(senha))
                throw new ArgumentException("Valor não pode ser nulo ou conter espaços.", "senha");

            // cria hash
            using System.Security.Cryptography.HMACSHA512 hmac = new System.Security.Cryptography.HMACSHA512();
            senhaSalt = hmac.Key;
            senhaHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
        }

        /**
         * Method:    VerificarSenhaHash
         *            Verificador de senha criptografada do usuário
         * FullName:  CriarSenhaHash
         * Access:    private 
         * Qualifier:
         * @param    string senha
         * @param    byte[] senhaHash
         * @param    byte[] senhaSalt
         * @return   bool
         */
        public static bool VerificarSenhaHash(string senha, byte[] senhaHash, byte[] senhaSalt)
        {
            if (senha == null)
                throw new ArgumentNullException("senha");

            if (string.IsNullOrWhiteSpace(senha))
                throw new ArgumentException("Valor não pode ser nulo ou conter espaços.", "senha");

            if (senhaHash.Length != 64)
                throw new ArgumentException("Tamanho inválido de hash (64 bytes esperado).", "senhaHash");

            if (senhaSalt.Length
                != 128) throw new ArgumentException("Tamanho inválido de salt (128 bytes esperado).", "senhaSalt");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(senhaSalt))
            {
                // recria o hash
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
                // verifica se é igual ao armazenado
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != senhaHash[i])
                        return false;
                }
            }

            return true;
        }
    }
}
