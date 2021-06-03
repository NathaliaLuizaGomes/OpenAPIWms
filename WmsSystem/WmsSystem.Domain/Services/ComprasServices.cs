using System;
using System.Collections.Generic;
using System.Text;
using WmsSystem.Domain.Entites.Models;
using WmsSystem.Domain.Interfaces.Repositories;
using WmsSystem.Domain.Interfaces.Services;
using WmsSystem.Domain.Services.ServiceBase;

namespace WmsSystem.Domain.Services
{
    public class ComprasServices : ServiceBase<Compra>, IComprasServices
    {
        private readonly IComprasRepository _comprasRepository;
        public ComprasServices(IComprasRepository _comprasRepository) : base(_comprasRepository)
        {
            this._comprasRepository = _comprasRepository;
        }

        public Compra ListarCompraId(int Id)
        {
            return _comprasRepository.ListarCompraId(Id);
        }

        public IEnumerable<Compra> ListarCompras()
        {
            return _comprasRepository.ListarCompras();
        }

        public bool EditarCompra(int Id, Compra compra)
        {
            return _comprasRepository.EditarCompra(Id, compra);
        }
        public bool IncluirCompra(Compra compra)
        {
            return _comprasRepository.IncluirCompra(compra);
        }

        public bool DeleteCompra(Compra compra)
        {
            return _comprasRepository.DeleteCompra(compra);
        }

        public Compra GetUltimaEntrada(int IdProduto)
        {
            return _comprasRepository.GetUltimaEntrada(IdProduto);
        }
    }
}
