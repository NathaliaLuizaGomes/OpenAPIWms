using System;
using System.Collections.Generic;
using System.Text;
using WmsSystem.Domain.Entites.Models;
using WmsSystem.Domain.Interfaces.Services.Base;

namespace WmsSystem.Domain.Interfaces.Services
{
    public interface ICategoriasServices : IServiceBase<Categoria>
    {
        Categoria ListarCategoriaId(int Id);
        IEnumerable<Categoria> ListarCategorias();
        bool IncluiCategoria(Categoria categoria);
        bool EditarCategoria(int Id, Categoria categoria);
    }
}
