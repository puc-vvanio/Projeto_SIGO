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
    public class NormaRepository : BaseRepository, IRepositoryNorma
    {
        private readonly MySqlContext _context;

        public NormaRepository(MySqlContext context, IDapperDbConnection dapperDbConnection) : base(dapperDbConnection)
        {
            _context = context;
        }

        public async Task Salvar(Norma norma)
        {
            try
            {
                await _context.Normas.AddAsync(norma);
            }
            catch
            {
                throw;
            }
        }

        public void Atualizar(Norma norma)
        {
            try
            {
                _context.Entry(norma).State = EntityState.Modified;
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
                var norma = await ObterNorma(id);

                if (norma == null)
                    throw new Exception();

                norma.DataExclusao = DateTime.Now;

                Atualizar(norma);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Norma> ObterNorma(int id)
        {
            try
            {
                return await _context.Normas.SingleOrDefaultAsync(x => x.Id.ToString().Equals(id) && x.DataExclusao == null);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Norma>> ObterNormas()
        {
            try
            {
                return await _context.Normas.Where(x => x.DataExclusao == null).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
