using System;
using System.Collections.Generic;
using System.Text;
using WmsSystem.Domain.Entites.Models;

namespace WmsSystem.Domain.Interfaces.Repositories
{
    public interface ICategoriasRepository: IRepositoryBase<Categoria>
    {
        Categoria ListarCategoriaId(int Id);
        IEnumerable<Categoria> ListarCategorias();
        bool IncluiCategoria(Categoria categoria);
        bool EditarCategoria(int Id, Categoria categoria);
    }
}
