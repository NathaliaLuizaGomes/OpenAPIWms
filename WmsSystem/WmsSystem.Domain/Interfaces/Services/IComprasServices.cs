using System;
using System.Collections.Generic;
using System.Text;
using WmsSystem.Domain.Entites.Models;
using WmsSystem.Domain.Interfaces.Services.Base;

namespace WmsSystem.Domain.Interfaces.Services
{
    public interface IComprasServices : IServiceBase<Compra>
    {
        Compra ListarCompraId(int Id);
        IEnumerable<Compra> ListarCompras();
        bool EditarCompra(int Id, Compra compra);
        bool IncluirCompra(Compra compra);
        bool DeleteCompra(Compra compra);
        Compra GetUltimaEntrada(int IdProduto);
    }
}
