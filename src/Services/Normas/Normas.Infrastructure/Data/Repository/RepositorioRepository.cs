using Microsoft.EntityFrameworkCore;
using SIGO.Normas.Domain.Entities;
using SIGO.Normas.Domain.Interfaces.Repository;
using SIGO.Normas.Infrastructure.CrossCutting;
using SIGO.Normas.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.Normas.Infrastructure.Data.Repository
{
    public class RepositorioRepository : BaseRepository, IRepositoryRepositorio
    {
        private readonly MySqlContext _context;

        public RepositorioRepository(MySqlContext context, IDapperDbConnection dapperDbConnection) : base(dapperDbConnection)
        {
            _context = context;
        }

        public async Task Salvar(Repositorio repositorio)
        {
            try
            {
                await _context.Repositorios.AddAsync(repositorio);
            }
            catch
            {
                throw;
            }
        }

        public void Atualizar(Repositorio repositorio)
        {
            try
            {
                _context.Entry(repositorio).State = EntityState.Modified;
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
                var repositorio = await ObterRepositorio(id);

                if (repositorio == null)
                    throw new Exception();

                repositorio.DataExclusao = DateTime.Now;

                Atualizar(repositorio);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Repositorio> ObterRepositorio(int id)
        {
            try
            {
                return await _context.Repositorios.SingleOrDefaultAsync(x => x.Id.ToString().Equals(id) && x.DataExclusao == null);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Repositorio>> ObterRepositorios()
        {
            try
            {
                return await _context.Repositorios.Where(x => x.DataExclusao == null).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
