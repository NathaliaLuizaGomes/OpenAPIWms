using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WmsSystem.Domain.Entites.Models;
using WmsSystem.Domain.Interfaces.Repositories;

namespace WmsSystem.Repository.Repositories
{
    public class ComprasRepository : RepositoryBase<Compra>, IComprasRepository
    {
        public Compra ListarCompraId(int Id)
        {
            Compra result = dbContext.Compras.Where(q => q.IdCompra == Id).FirstOrDefault();
            return result;

        }

        public IEnumerable<Compra> ListarCompras()
        {
            IEnumerable<Compra> list = dbContext.Compras.ToList();
            return list;
        }

        public bool EditarCompra(int Id, Compra modelEditado)
        {
            using (var ctx = GetContext())
            {
                using (var tran = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        Compra _modelRegistrado = GetById(Id);

                        if (Id <= 0)
                        {
                            if (_modelRegistrado.IdCompra <= 0)
                                throw new Exception("NÃO FOI POSSÍVEL ENCONTRAR O REGISTRO PARA EDIÇÃO.");
                            return false;
                        }
                        else
                        {
                            #region MUDANÇA DE CAMPOS NA TABELA COMPRA
                            
                            _modelRegistrado.IdCompra = modelEditado.IdCompra == 0 ? _modelRegistrado.IdCompra : modelEditado.IdCompra;
                            _modelRegistrado.QtdEntrada = modelEditado.QtdEntrada == 0 ? _modelRegistrado.QtdEntrada : modelEditado.QtdEntrada;
                            _modelRegistrado.DataEntrada = DateTime.UtcNow.AddHours(-3);

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

        public bool IncluirCompra(Compra compra)
        {
            dbContext.Compras.Add(compra);
            dbContext.SaveChanges();
            return true;
        }

        public bool DeleteCompra(Compra compra)
        {
            dbContext.Entry(compra).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return true;
        }

        public Compra GetUltimaEntrada(int IdProduto)
        {
            Compra result = dbContext.Compras.OrderByDescending(p => p.DataEntrada).Where(q => q.IdMercadoria == IdProduto).FirstOrDefault();
            return result;
        }
    }
}
