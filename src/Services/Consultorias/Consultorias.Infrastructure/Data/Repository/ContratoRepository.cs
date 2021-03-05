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
    public class ContratoRepository : BaseRepository, IRepositoryContrato
    {
        private readonly MySqlContext _context;

        public ContratoRepository(MySqlContext context, IDapperDbConnection dapperDbConnection) : base(dapperDbConnection)
        {
            _context = context;
        }

        public async Task Salvar(Contrato contrato)
        {
            try
            {
                await _context.Contratos.AddAsync(contrato);
            }
            catch
            {
                throw;
            }
        }

        public void Atualizar(Contrato contrato)
        {
            try
            {
                _context.Entry(contrato).State = EntityState.Modified;
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
                var contrato = await ObterContrato(id);

                if (contrato == null)
                    throw new Exception();

                contrato.DataExclusao = DateTime.Now;

                Atualizar(contrato);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Contrato> ObterContrato(int id)
        {
            try
            {
                return await _context.Contratos.SingleOrDefaultAsync(x => x.Id.ToString().Equals(id) && x.DataExclusao == null);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Contrato>> ObterContratos()
        {
            try
            {
                return await _context.Contratos.Where(x => x.DataExclusao == null).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
