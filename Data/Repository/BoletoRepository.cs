using BancoClass.Entities;
using BoletoClass.Entities;
using BoletoClass.Interfaces;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class BoletoRepository : BaseRepository<Boleto>, IBoletoRepository
    {
        private readonly DbSet<Boleto> _dbSetBoleto;
        private readonly DbSet<Banco> _dbSetBanco;
        public BoletoRepository(DataDbContext context) : base(context)
        {
            _dbSetBoleto = context.Set<Boleto>();
            _dbSetBanco = context.Set<Banco>();
        }

        #region Gets
        public Boleto GetBoletoByIdWithBanco(Guid idBoleto)
        {
            return (from ai in _dbSetBoleto
                    join al in _dbSetBanco on ai.IdBanco equals al.Id
                    where (ai.Id == idBoleto)
                    select new Boleto
                    {
                        Id = ai.Id,
                        IdBanco = ai.IdBanco,
                        CpfCnpjBeneficiario = ai.CpfCnpjBeneficiario,
                        CpfCnpjPagador = ai.CpfCnpjPagador,
                        DataVencimento = ai.DataVencimento,
                        NomeBeneficiario = ai.NomeBeneficiario,
                        NomePagador = ai.NomePagador,
                        Observacao = ai.Observacao,
                        Valor = ai.Valor,
                        Banco = new Banco
                        {
                            Id = al.Id,
                            Codigo = al.Codigo,
                            Nome = al.Nome,
                            PercentualJuros = al.PercentualJuros
                        }
                    }).FirstOrDefault() ?? new Boleto();
        }

        public List<Boleto> GetBoletosWithBanco()
        {
            return (from ai in _dbSetBoleto
                    join al in _dbSetBanco on ai.IdBanco equals al.Id
                    select new Boleto
                    {
                        Id = ai.Id,
                        IdBanco = ai.IdBanco,
                        CpfCnpjBeneficiario = ai.CpfCnpjBeneficiario,
                        CpfCnpjPagador = ai.CpfCnpjPagador,
                        DataVencimento = ai.DataVencimento,
                        NomeBeneficiario = ai.NomeBeneficiario,
                        NomePagador = ai.NomePagador,
                        Observacao = ai.Observacao,
                        Valor = ai.Valor,
                        Banco = new Banco
                        {
                            Id = al.Id,
                            Codigo = al.Codigo,
                            Nome = al.Nome,
                            PercentualJuros = al.PercentualJuros
                        }
                    }).ToList();
        }
        #endregion
    }
}
