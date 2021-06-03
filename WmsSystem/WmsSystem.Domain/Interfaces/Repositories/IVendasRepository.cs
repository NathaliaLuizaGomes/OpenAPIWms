using System;
using System.Collections.Generic;
using System.Text;
using WmsSystem.Domain.Entites.Models;
using WmsSystem.Domain.Interfaces.Services.Base;

namespace WmsSystem.Domain.Interfaces.Repositories
{
    public interface IVendasRepository: IRepositoryBase<Venda>
    {
        Venda ListarVendaId(int Id);
        IEnumerable<Venda> ListarVendas();
        bool EditarVenda(int Id, Venda compra);
        bool IncluirVenda(Venda compra);
        bool DeleteVenda(Venda compra);
        Venda GetUltimaSaida(int IdProduto);
    }
}
