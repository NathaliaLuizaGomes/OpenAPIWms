using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WmsSystem.Domain.Entites.Models;
using WmsSystem.Domain.Interfaces.Repositories;

namespace WmsSystem.Repository.Repositories
{
    public class VendaRepository : RepositoryBase<Venda>, IVendasRepository
    {
        public Venda ListarVendaId(int Id)
        {
            Venda result = dbContext.Vendas.Where(q => q.IdVenda == Id).FirstOrDefault();
            return result;

        }

        public IEnumerable<Venda> ListarVendas()
        {
            IEnumerable<Venda> list = dbContext.Vendas.ToList();
            return list;
        }

        public bool EditarVenda(int Id, Venda modelEditado)
        {
            using (var ctx = GetContext())
            {
                using (var tran = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        Venda _modelRegistrado = GetById(Id);

                        if (Id <= 0)
                        {
                            if (_modelRegistrado.IdVenda <= 0)
                                throw new Exception("NÃO FOI POSSÍVEL ENCONTRAR O REGISTRO PARA EDIÇÃO.");
                            return false;
                        }
                        else
                        {
                            #region MUDANÇA DE CAMPOS NA TABELA VENDA

                            _modelRegistrado.IdVenda = modelEditado.IdVenda == 0 ? _modelRegistrado.IdVenda : modelEditado.IdVenda;
                            _modelRegistrado.QtdSaida = modelEditado.QtdSaida == 0 ? _modelRegistrado.QtdSaida : modelEditado.QtdSaida;
                            _modelRegistrado.DataSaida = DateTime.UtcNow.AddHours(-3);
                            
                            #endregion

                            ctx.Entry(_modelRegistrado).State = EntityState.Modified;
                            ctx.SaveChanges();

                            tran.Commit();
                            return true;
                        }
                    }
                    catch (Exception e)
                    {
                        return false;
                        throw e;

                    }
                }

            }
        }

        public bool IncluirVenda(Venda venda)
        {
            dbContext.Vendas.Add(venda);
            dbContext.SaveChanges();
            return true;
        }

        public bool DeleteVenda(Venda venda)
        {
            dbContext.Entry(venda).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return true;
        }

        public Venda GetUltimaSaida(int IdProduto)
        {
            Venda result = dbContext.Vendas.OrderByDescending(p => p.DataSaida).Where(q => q.IdMercadoria == IdProduto).FirstOrDefault();
            return result;
        }

    }
}
