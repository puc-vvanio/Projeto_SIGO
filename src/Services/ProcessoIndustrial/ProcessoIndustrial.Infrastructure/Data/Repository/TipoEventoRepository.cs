using Microsoft.EntityFrameworkCore;
using SIGO.ProcessoIndustrial.Domain.Entities;
using SIGO.ProcessoIndustrial.Domain.Interfaces.Repository;
using SIGO.ProcessoIndustrial.Infrastructure.CrossCutting;
using SIGO.ProcessoIndustrial.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.ProcessoIndustrial.Infrastructure.Data.Repository
{
    public class TipoEventoRepository : BaseRepository, IRepositoryTipoEvento
    {
        private readonly MySqlContext _context;

        public TipoEventoRepository(MySqlContext context, IDapperDbConnection dapperDbConnection) : base(dapperDbConnection)
        {
            _context = context;
        }

        public async Task Salvar(TipoEvento tipoEvento)
        {
            try
            {
                await _context.TiposEventos.AddAsync(tipoEvento);
            }
            catch
            {
                throw;
            }
        }

        public void Atualizar(TipoEvento tipoEvento)
        {
            try
            {
                _context.Entry(tipoEvento).State = EntityState.Modified;
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
                var tipoEvento = await ObterTipoEvento(id);

                if (tipoEvento == null)
                    throw new Exception();

                tipoEvento.DataExclusao = DateTime.Now;

                Atualizar(tipoEvento);
            }
            catch
            {
                throw;
            }
        }

        public async Task<TipoEvento> ObterTipoEvento(int id)
        {
            try
            {
                return await _context.TiposEventos.SingleOrDefaultAsync(x => x.Id.ToString().Equals(id) && x.DataExclusao == null);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<TipoEvento>> ObterTiposEventos()
        {
            try
            {
                return await _context.TiposEventos.Where(x => x.DataExclusao == null).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
