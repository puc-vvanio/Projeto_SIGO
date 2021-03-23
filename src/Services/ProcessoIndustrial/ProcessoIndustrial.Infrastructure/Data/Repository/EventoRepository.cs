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
    public class EventoRepository : BaseRepository, IRepositoryEvento
    {
        private readonly MySqlContext _context;

        public EventoRepository(MySqlContext context, IDapperDbConnection dapperDbConnection) : base(dapperDbConnection)
        {
            _context = context;
        }

        public async Task Salvar(Evento evento)
        {
            try
            {
                await _context.Eventos.AddAsync(evento);
            }
            catch
            {
                throw;
            }
        }

        public void Atualizar(Evento evento)
        {
            try
            {
                _context.Entry(evento).State = EntityState.Modified;
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
                var evento = await ObterEvento(id);

                if (evento == null)
                    throw new Exception();

                evento.DataExclusao = DateTime.Now;

                Atualizar(evento);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Evento> ObterEvento(int id)
        {
            try
            {
                return await _context.Eventos.SingleOrDefaultAsync(x => x.Id.ToString().Equals(id.ToString()) && x.DataExclusao == null);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Evento> ObterUltimoEvento(int tipoEventoId)
        {
            try
            {
                return await _context.Eventos.Where(x => x.DataExclusao == null && x.TipoEventoID == tipoEventoId).OrderByDescending(x => x.DataCriacao).FirstAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Evento>> ObterEventos()
        {
            try
            {
                return await _context.Eventos.Where(x => x.DataExclusao == null).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
