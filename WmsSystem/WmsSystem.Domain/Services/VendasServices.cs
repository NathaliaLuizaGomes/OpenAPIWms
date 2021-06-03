using System;
using System.Collections.Generic;
using System.Text;
using WmsSystem.Domain.Entites.Models;
using WmsSystem.Domain.Interfaces.Repositories;
using WmsSystem.Domain.Interfaces.Services;
using WmsSystem.Domain.Services.ServiceBase;

namespace WmsSystem.Domain.Services
{
    public class VendasServices : ServiceBase<Venda>, IVendasServices
    {
        private readonly IVendasRepository _vendasRepository;

        public VendasServices(IVendasRepository _vendasRepository) : base(_vendasRepository)
        {
            this._vendasRepository = _vendasRepository;
        }

        public Venda ListarVendaId(int Id)
        {
            return _vendasRepository.ListarVendaId(Id);
        }

        public IEnumerable<Venda> ListarVendas()
        {
            return _vendasRepository.ListarVendas();
        }

        public bool IncluirVenda(Venda produto)
        {
            return _vendasRepository.IncluirVenda(produto);
        }

        public bool EditarVenda(int Id, Venda produto)
        {
            return _vendasRepository.EditarVenda(Id, produto);
        }

        public bool DeleteVenda(Venda produto)
        {
            return _vendasRepository.DeleteVenda(produto);
        }

        public Venda GetUltimaSaida(int IdProduto)
        {
            return _vendasRepository.GetUltimaSaida(IdProduto);
        }

    }
}
