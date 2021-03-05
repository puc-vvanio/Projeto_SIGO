using Microsoft.EntityFrameworkCore;
using SIGO.Consultorias.Domain.Entities;
using SIGO.Consultorias.Domain.Interfaces.Repository;
using SIGO.Consultorias.Infrastructure.CrossCutting;
using SIGO.Consultorias.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.Consultorias.Infrastructure.Data.Repository
{
    public class ConsultoriaRepository : BaseRepository, IRepositoryConsultoria
    {
        private readonly MySqlContext _context;

        public ConsultoriaRepository(MySqlContext context, IDapperDbConnection dapperDbConnection) : base(dapperDbConnection)
        {
            _context = context;
        }

        public async Task Salvar(Consultoria consultoria)
        {
            try
            {
                await _context.Consultorias.AddAsync(consultoria);
            }
            catch
            {
                throw;
            }
        }

        public void Atualizar(Consultoria consultoria)
        {
            try
            {
                _context.Entry(consultoria).State = EntityState.Modified;
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
                var consultoria = await ObterConsultoria(id);

                if (consultoria == null)
                    throw new Exception();

                consultoria.DataExclusao = DateTime.Now;

                Atualizar(consultoria);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Consultoria> ObterConsultoria(int id)
        {
            try
            {
                return await _context.Consultorias.SingleOrDefaultAsync(x => x.Id.ToString().Equals(id) && x.DataExclusao == null);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Consultoria>> ObterConsultorias()
        {
            try
            {
                return await _context.Consultorias.Where(x => x.DataExclusao == null).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
