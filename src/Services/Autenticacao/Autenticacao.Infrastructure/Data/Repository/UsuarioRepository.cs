using Microsoft.EntityFrameworkCore;
using SIGO.Autenticacao.Domain.Entities;
using SIGO.Autenticacao.Domain.Interfaces.Repository;
using SIGO.Autenticacao.Infrastructure.CrossCutting;
using SIGO.Autenticacao.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.Autenticacao.Infrastructure.Data.Repository
{
    public class UsuarioRepository : BaseRepository, IRepositoryUsuario
    {
        private readonly MySqlContext _context;

        public UsuarioRepository(MySqlContext context, IDapperDbConnection dapperDbConnection) : base(dapperDbConnection)
        {
            _context = context;
        }

        public async Task Salvar(Usuario usuario)
        {
            try
            {
                await _context.Usuarios.AddAsync(usuario);
            }
            catch
            {
                throw;
            }
        }

        public void Atualizar(Usuario usuario)
        {
            try
            {
                _context.Entry(usuario).State = EntityState.Modified;
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
                var usuario = await ObterUsuario(id);

                if (usuario == null)
                    throw new Exception();

                usuario.DataExclusao = DateTime.Now;

                Atualizar(usuario);
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
                return await _context.Usuarios.SingleOrDefaultAsync(x => x.Id.ToString().Equals(id) && x.DataExclusao == null);
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
                return await _context.Usuarios.Where(x => x.DataExclusao == null).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
