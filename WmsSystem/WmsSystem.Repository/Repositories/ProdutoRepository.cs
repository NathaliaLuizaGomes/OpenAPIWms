using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WmsSystem.Domain.Constante;
using WmsSystem.Domain.Entites.Models;
using WmsSystem.Domain.Interfaces.Repositories;

namespace WmsSystem.Repository.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutosRepository
    {
        public Produto ListarProdutoId(int Id)
        {
            Produto result = dbContext.Produtos.Where(q => q.Id == Id).FirstOrDefault();
            return result;
        }
        public IEnumerable<Produto> ListarProdutosAtivos()
        {
            IEnumerable<Produto> list = dbContext.Produtos.Where(q => q.Desativado == false).ToList();
            return list;
        }

        public bool IncluirProduto(Produto produto)
        {
            dbContext.Produtos.Add(produto);
            dbContext.SaveChanges();
            return true;
        }

        public bool EditarProduto(int Id, Produto modelEditado)
        {
            using (var ctx = GetContext())
            {
                using (var tran = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        Produto _modelRegistrado = GetById(Id);

                        if (Id <= 0)
                        {
                            if (_modelRegistrado.Id <= 0)
                                throw new Exception("NÃO FOI POSSÍVEL ENCONTRAR O REGISTRO PARA EDIÇÃO.");
                            return false;
                        }
                        else
                        {
                            #region MUDANÇA DE CAMPOS NA TABELA PRODUTOS

                            _modelRegistrado.Referencia = String.IsNullOrEmpty(modelEditado.Referencia) ? _modelRegistrado.Referencia : modelEditado.Referencia;
                            _modelRegistrado.Nome = String.IsNullOrEmpty(modelEditado.Nome) ? _modelRegistrado.Nome : modelEditado.Nome;
                            _modelRegistrado.PCusto = modelEditado.PCusto == 0 ? _modelRegistrado.PCusto : modelEditado.PCusto;
                            _modelRegistrado.PVenda = modelEditado.PVenda == 0 ? _modelRegistrado.PVenda : modelEditado.PVenda;
                            _modelRegistrado.UndMedida = String.IsNullOrEmpty(modelEditado.UndMedida) ? _modelRegistrado.UndMedida : modelEditado.UndMedida;
                            _modelRegistrado.Grupo = String.IsNullOrEmpty(modelEditado.Grupo) ? _modelRegistrado.Grupo : modelEditado.Grupo;
                            _modelRegistrado.IdCategoria = modelEditado.IdCategoria == 0 ? _modelRegistrado.IdCategoria : modelEditado.IdCategoria;
                            _modelRegistrado.DtAlteracao = DateTime.UtcNow.AddHours(-3);
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

        public bool DesativarProduto(Produto produto)
        {
            dbContext.Entry(produto).State = EntityState.Modified;
            dbContext.SaveChanges();
            return true;
        }

        public bool DeleteProduto(Produto produto)
        {
            dbContext.Entry(produto).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return true;
        }

        public bool AtualizarProdutoQtd(int Id, float Qtd, string type, string acoes)
        {
            using (var ctx = GetContext())
            {
                using (var tran = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        Produto _modelRegistrado = GetById(Id);

                        float QtdTotal = 0;

                        //COMPRA
                        if (_modelRegistrado != null && type == Constantes.COMPRA && acoes == Acoes.INSERT || acoes == Acoes.EDITE)
                        {
                            QtdTotal = _modelRegistrado.Quantidade + Qtd;
                        }

                        if (_modelRegistrado != null && type == Constantes.COMPRA && acoes == Acoes.DELETE)
                        {
                            QtdTotal = _modelRegistrado.Quantidade - Qtd;
                        }


                        //VENDA
                        if (_modelRegistrado != null && type == Constantes.VENDA && acoes == Acoes.INSERT || acoes == Acoes.EDITE)
                        {
                            QtdTotal = _modelRegistrado.Quantidade - Qtd;
                        }

                        if (_modelRegistrado != null && type == Constantes.VENDA && acoes == Acoes.DELETE)
                        {
                            QtdTotal = _modelRegistrado.Quantidade + Qtd;
                        }


                        if (Id <= 0)
                        {
                            if (_modelRegistrado.Id <= 0)
                                throw new Exception("NÃO FOI POSSÍVEL ENCONTRAR O REGISTRO PARA EDIÇÃO.");
                            return false;
                        }
                        else
                        {
                            #region MUDANÇA DE CAMPOS NA TABELA PRODUTOS
                            _modelRegistrado.Quantidade = QtdTotal == 0 ? _modelRegistrado.Quantidade : QtdTotal;
                            _modelRegistrado.DtAlteracao = DateTime.UtcNow.AddHours(-3);
                            #endregion

                            ctx.Entry(_modelRegistrado).State = EntityState.Modified;
                            ctx.SaveChanges();

                            tran.Commit();
                            return true;
                        }


                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }

            }
        }

        public bool DescontoProduto(float desconto, IEnumerable<Produto> listaProduto)
        {
            using (var ctx = GetContext())
            {
                using (var tran = ctx.Database.BeginTransaction())
                {
                    try
                        {
                            if (listaProduto.AsQueryable().ToList().Count > 0)
                            {
                                foreach (var item in listaProduto)
                                {
                                    var percDesconto = desconto / 100;
                                    var valorDescontado = item.PVenda * percDesconto;
                                    var valorAlterado = item.PVenda - valorDescontado;


                                #region MUDANÇA DE CAMPOS NA TABELA PRODUTOS

                                item.PVenda = valorAlterado;

                                #endregion

                                    ctx.Entry(item).State = EntityState.Modified;
                                    ctx.SaveChanges();                                                                    

                                }

                                tran.Commit();
                            }
                        }


                    catch (Exception)
                    {

                        throw;
                    }


                    return true;
                }
            }
        }

        public bool AcrescimoProduto(float acrescimo, IEnumerable<Produto> listaProdutos)
        {
            using (var ctx = GetContext())
            {
                using (var tran = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        if (listaProdutos.AsQueryable().ToList().Count > 0)
                        {
                            foreach (var item in listaProdutos)
                            {
                                var percAcrescimo = acrescimo / 100;
                                var valorDescontado = item.PVenda * percAcrescimo;
                                var valorAlterado = item.PVenda + valorDescontado;


                                #region MUDANÇA DE CAMPOS NA TABELA PRODUTOS

                                item.PVenda = valorAlterado;

                                #endregion

                                ctx.Entry(item).State = EntityState.Modified;
                                ctx.SaveChanges();

                            }

                            tran.Commit();
                        }
                    }


                    catch (Exception)
                    {

                        throw;
                    }


                    return true;
                }
            }
        }
    }
}
