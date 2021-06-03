using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WmsSystem.Domain.Constante;
using WmsSystem.Domain.Entites.Models;
using WmsSystem.Domain.Interfaces.Services;
using WmsSystem.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WmsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private IComprasServices _comprasServices;
        private IProdutosServices _produtosServices;

        public CompraController(IComprasServices _comprasServices,
            IProdutosServices _produtosServices)
        {
            this._comprasServices = _comprasServices;
            this._produtosServices = _produtosServices;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Compra))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCompras(int id)
        {
            if (id <= 0)
            {
                return new NotFoundResult();
            }

            var compra = _comprasServices.ListarCompraId(id);
            if (compra == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(compra);
            }

        }

        [HttpGet]
        public IActionResult ListarCompras()
        {
            IEnumerable<Compra> list = _comprasServices.ListarCompras();

            List<CompraViewModels> compraView = new List<CompraViewModels>();

            if (list.AsQueryable().ToList().Count == 0)
            {

                return Ok(compraView);
            }
            else
            {
                foreach (Compra item in list.ToList())
                {
                    CompraViewModels view = new CompraViewModels()
                    {
                        IdCompra = item.IdCompra,
                        IdMercadoria = item.IdMercadoria,
                        QtdEntrada= item.QtdEntrada,
                        DataEntrada = item.DataEntrada
                    };

                    compraView.Add(view);
                }

                return Ok(compraView);
            }

        }

        [HttpPost]
        [Route("editar/id")]
        public IActionResult EditarCompra(int id, [FromBody] Compra compra)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Compra item = _comprasServices.ListarCompraId(id);

                    CompraViewModels compraView = new CompraViewModels();

                    CompraViewModels view = new CompraViewModels()
                    {
                        IdCompra = item.IdCompra,
                        IdMercadoria = item.IdMercadoria,
                        QtdEntrada = item.QtdEntrada,
                        DataEntrada = item.DataEntrada
                    };


                    bool alterado = _comprasServices.EditarCompra(id, compra);

                    if (alterado)
                    {
                        //Atualizar campo qtd no cadastro de produtos
                        bool produtoAtualizado = _produtosServices.AtualizarProdutoQtd(compra.IdMercadoria, compra.QtdEntrada, Constantes.COMPRA, Acoes.EDITE);

                    }

                    return Ok(compra);
                }
                else
                {
                    return new NotFoundResult();
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        public IActionResult IncluirCompra([FromBody] Compra compra)
        {
            try
            {
                if (ModelState.IsValid)
                {                    
                    compra.DataEntrada =  DateTime.UtcNow.AddHours(-3);
                    bool compraIncluida = _comprasServices.IncluirCompra(compra);

                    if (compraIncluida)
                    {
                        //Atualizar campo qtd no cadastro de produtos
                        bool produtoAtualizado = _produtosServices.AtualizarProdutoQtd(compra.IdMercadoria, compra.QtdEntrada, Constantes.COMPRA, Acoes.INSERT);

                    }

                    return Ok(compra);
                }
                else
                {
                    return new NotFoundResult();
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCompra(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Compra compra = _comprasServices.ListarCompraId(id);
                    
                    bool deletado = _comprasServices.DeleteCompra(compra);

                    if (deletado)
                    {
                        //Atualizar campo qtd no cadastro de produtos
                        bool produtoAtualizado = _produtosServices.AtualizarProdutoQtd(compra.IdMercadoria, compra.QtdEntrada, Constantes.COMPRA, Acoes.DELETE);

                    }

                    return Ok();
                }
                else
                {
                    return new NotFoundResult();
                }

            }
            catch (Exception e)
            {

                throw e;
            }

        }
    }
}
