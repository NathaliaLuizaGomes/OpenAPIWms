using System;
using System.Collections.Generic;
using System.Text;
using WmsSystem.Domain.Entites.Models;

namespace WmsSystem.Domain.Interfaces.Repositories
{
    public interface IComprasRepository : IRepositoryBase<Compra>
    {
        Compra ListarCompraId(int Id);
        IEnumerable<Compra> ListarCompras();
        bool EditarCompra(int Id, Compra compra);
        bool IncluirCompra(Compra compra);
        bool DeleteCompra(Compra compra);
        Compra GetUltimaEntrada(int IdProduto);
    }
}
