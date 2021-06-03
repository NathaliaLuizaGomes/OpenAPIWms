using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WmsSystem.Domain.Entites.Models;
using WmsSystem.Domain.Interfaces.Repositories;

namespace WmsSystem.Repository.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriasRepository
    {

        public Categoria ListarCategoriaId(int Id)
        {
            Categoria result = dbContext.Categoria.Where(q => q.IdCategoria == Id).FirstOrDefault();
            return result;
        }
        public IEnumerable<Categoria> ListarCategorias()
        {
            IEnumerable<Categoria> list = dbContext.Categoria.ToList();
            return list;
        }

        public bool IncluiCategoria(Categoria categoria)
        {
            dbContext.Categoria.Add(categoria);
            dbContext.SaveChanges();
            return true;
        }

        public bool EditarCategoria(int Id, Categoria modelEditado)
        {
            using (var ctx = GetContext())
            {
                using (var tran = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        Categoria _modelRegistrado = GetById(Id);

                        if (Id <= 0)
                        {
                            if (_modelRegistrado.IdCategoria  <= 0)
                                throw new Exception("NÃO FOI POSSÍVEL ENCONTRAR O REGISTRO PARA EDIÇÃO.");
                            return false;
                        }
                        else
                        {
                            #region MUDANÇA DE CAMPOS NA TABELA CATEGORIA
                            _modelRegistrado.NomeCategoria = String.IsNullOrEmpty(modelEditado.NomeCategoria) ? _modelRegistrado.NomeCategoria : modelEditado.NomeCategoria;
                            _modelRegistrado.Desconto = modelEditado.Desconto == 0 ? _modelRegistrado.Desconto : modelEditado.Desconto;
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
    }
}
