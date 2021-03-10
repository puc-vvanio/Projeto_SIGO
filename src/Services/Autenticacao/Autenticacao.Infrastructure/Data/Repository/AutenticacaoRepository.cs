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
    public class AutenticacaoRepository : BaseRepository, IRepositoryAutenticacao
    {
        private readonly MySqlContext _context;

        public AutenticacaoRepository(MySqlContext context, IDapperDbConnection dapperDbConnection) : base(dapperDbConnection)
        {
            _context = context;
        }

        public async Task Salvar(Autenticacao autenticacao)
        {
            try
            {
                await _context.Autenticacao.AddAsync(autenticacao);
            }
            catch
            {
                throw;
            }
        }

        public void Atualizar(Autenticacao autenticacao)
        {
            try
            {
                _context.Entry(autenticacao).State = EntityState.Modified;
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
                var autenticacao = await ObterAutenticacao(id);

                if (autenticacao == null)
                    throw new Exception();

                autenticacao.DataExclusao = DateTime.Now;

                Atualizar(autenticacao);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Autenticacao> ObterAutenticacao(int id)
        {
            try
            {
                return await _context.Autenticacao.SingleOrDefaultAsync(x => x.Id.ToString().Equals(id) && x.DataExclusao == null);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Autenticacao>> ObterAutenticacao()
        {
            try
            {
                return await _context.Autenticacao.Where(x => x.DataExclusao == null).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
