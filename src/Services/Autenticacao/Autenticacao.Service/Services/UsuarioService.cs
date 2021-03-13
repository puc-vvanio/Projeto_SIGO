using SIGO.Autenticacao.Domain.Entities;
using SIGO.Autenticacao.Domain.Interfaces;
using SIGO.Autenticacao.Domain.Interfaces.Services;
using SIGO.Autenticacao.Infrastructure.CrossCutting.Security;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.Autenticacao.Service.Services
{
    public class UsuarioService : IServiceUsuario
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Usuario> Autenticar(string email, string senha)
        {
            try
            {
                var usuario = new Usuario();
                usuario = await _unitOfWork.Usuarios.ObterUsuarioPorEmail(email);

                if (usuario != null)
                {
                    if ((usuario.SenhaHash != null && usuario.SenhaHash?.Length > 0) && (usuario.SenhaSalt != null && usuario.SenhaSalt?.Length > 0))
                    {
                        // verificar se a senha está correta
                        if (SenhaHelper.VerificarSenhaHash(senha, usuario.SenhaHash, usuario.SenhaSalt))
                        {
                            // Usuário autenticado
                            return usuario;
                        }
                    }

                    return null;

                }

                return null;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Usuario> Salvar(Usuario usuario, string senha)
        {
            // validação
            if (string.IsNullOrWhiteSpace(senha))
                throw new Exception("Senha é obrigatória");

            if (await _unitOfWork.Usuarios.VerificarExisteUsuario(usuario.Email))
                throw new Exception("e-mail \"" + usuario.Email + "\" já cadastrado");

            // Hash da senha
            SenhaHelper.CriarSenhaHash(senha, out byte[] senhaHash, out byte[] senhaSalt);

            usuario.SenhaHash = senhaHash;
            usuario.SenhaSalt = senhaSalt;

            try
            {
                await _unitOfWork.Usuarios.Salvar(usuario);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }

            return usuario;
        }

        public async Task Atualizar(Usuario usuario, string senha = null)
        {
            // validação
            if (await _unitOfWork.Usuarios.VerificarExisteUsuario(usuario.Email))
                throw new Exception("e-mail \"" + usuario.Email + "\" já cadastrado");

            if (string.IsNullOrWhiteSpace(senha))
            {
                // Hash da senha
                SenhaHelper.CriarSenhaHash(senha, out byte[] senhaHash, out byte[] senhaSalt);

                usuario.SenhaHash = senhaHash;
                usuario.SenhaSalt = senhaSalt;
            }

            try
            {
                _unitOfWork.Usuarios.Atualizar(usuario);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task Excluir(int id)
        {
            try
            {
                await _unitOfWork.Usuarios.Excluir(id);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Usuario> ObterUsuario(int id)
        {

            try
            {
                return await _unitOfWork.Usuarios.ObterUsuario(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Usuario>> ObterUsuarios()
        {
            try
            {
                return await _unitOfWork.Usuarios.ObterUsuarios();
            }
            catch
            {
                throw;
            }
        }

        // private helper methods
    }
}
