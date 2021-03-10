using SIGO.Autenticacao.Domain.Entities;
using SIGO.Autenticacao.Domain.Interfaces;
using SIGO.Autenticacao.Domain.Interfaces.Services;
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

        public async Task<Usuario> Salvar(Usuario usuario)
        {
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

        public async Task Atualizar(Usuario usuario)
        {
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
            var usuario = new Usuario();

            try
            {
                usuario = await _unitOfWork.Usuarios.ObterUsuario(id);
            }
            catch
            {
                throw;
            }

            return usuario;
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
    }
}
