using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WmsSystem.Domain.Entites.Models;
using WmsSystem.Domain.Interfaces.Services;
using WmsSystem.ViewModels;
using WmsSystem.ViewModels.Reports;

namespace WmsSystem.Controllers
{
    
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private IProdutosServices _produtosServices;
        private ICategoriasServices _categoriasServices;
        private IComprasServices _comprasServices;
        private IVendasServices _vendasServices;

        public ReportsController(IProdutosServices _produtosServices,
            ICategoriasServices _categoriasServices, IComprasServices _comprasServices,
            IVendasServices _vendasServices)
        {
            this._produtosServices = _produtosServices;
            this._categoriasServices = _categoriasServices;
            this._comprasServices = _comprasServices;
            this._vendasServices = _vendasServices;
        }


        [HttpGet]
        [Route("api/produtos")]
        public IActionResult ListarMovimentacaoProdutos()
        {
            IEnumerable<Produto> list = _produtosServices.ListarProdutosAtivos();
            List<ProdutosReportViewModel> produtoView = new List<ProdutosReportViewModel>();

            if (list.AsQueryable().ToList().Count == 0)
            {

                return Ok(produtoView);
            }
            else
            {
                foreach (Produto item in list.ToList())
                {
                    var nomeCategoria = _categoriasServices.GetById(item.IdCategoria);
                    var ultimaEntada = _comprasServices.GetUltimaEntrada(item.Id);
                    var ultimaSaida = _vendasServices.GetUltimaSaida(item.Id);
                    var dataZerada = DateTime.Now.AddYears(-1000);

                    ProdutosReportViewModel view = new ProdutosReportViewModel()
                    {                        
                        Referencia = item.Referencia,
                        Nome = item.Nome,
                        PCusto = item.PCusto,
                        PVenda = item.PVenda,
                        Quantidade = item.Quantidade,
                        DataEntrada = ultimaEntada == null? dataZerada : ultimaEntada.DataEntrada,
                        DataSaida = ultimaEntada == null ? dataZerada : ultimaSaida.DataSaida
                    };

                    produtoView.Add(view);
                }

            }

            return Ok(produtoView);
        }

        [HttpGet]
        [Route("api/movimentacaoCompra")]
        public IActionResult ListarMovimentacaoCompra()
        {
            IEnumerable<Produto> list = _produtosServices.ListarProdutosAtivos();
            IEnumerable<Compra> listCompra = _comprasServices.ListarCompras();          

            List<MovimentacaoReportViewModel> movimentoView = new List<MovimentacaoReportViewModel>();

            if (list.AsQueryable().ToList().Count == 0)
            {
                return Ok(movimentoView);
            }
            else
            {
                foreach (Compra item in listCompra.ToList())
                {
                    var produtos = _produtosServices.ListarProdutoId(item.IdMercadoria);

                    MovimentacaoReportViewModel view = new MovimentacaoReportViewModel()
                    {
                        IdProduto = item.IdMercadoria,
                        Referencia = produtos.Referencia,
                        NomeProduto = produtos.Nome,                       
                        DataEntrada = item.DataEntrada                        
                    };

                    movimentoView.Add(view);
                }

            }

            return Ok(movimentoView);
        }

        [HttpGet]
        [Route("api/movimentacaoVenda")]
        public IActionResult ListarMovimentacaoVenda()
        {
            IEnumerable<Produto> list = _produtosServices.ListarProdutosAtivos();            
            IEnumerable<Venda> listVenda = _vendasServices.ListarVendas();            

            List<MovimentacaoReportViewModel> movimentoView = new List<MovimentacaoReportViewModel>();

            if (list.AsQueryable().ToList().Count == 0)
            {
                return Ok(movimentoView);
            }
            else
            {
                foreach (Venda item in listVenda.ToList())
                {
                    var produtos = _produtosServices.ListarProdutoId(item.IdMercadoria);

                    MovimentacaoReportViewModel view = new MovimentacaoReportViewModel()
                    {
                        IdProduto = item.IdMercadoria,
                        Referencia = produtos.Referencia,
                        NomeProduto = produtos.Nome,
                        DataEntrada = item.DataSaida
                    };

                    movimentoView.Add(view);
                }

            }

            return Ok(movimentoView);
        }

    }
}
