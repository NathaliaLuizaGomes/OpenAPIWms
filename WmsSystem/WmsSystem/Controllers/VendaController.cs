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

namespace WmsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private IVendasServices _vendasServices;
        private IProdutosServices _produtosServices;

        public VendaController(IVendasServices _vendasServices,
            IProdutosServices _produtosServices)
        {
            this._vendasServices = _vendasServices;
            this._produtosServices = _produtosServices;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Venda))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetVendas(int id)
        {
            if (id <= 0)
            {
                return new NotFoundResult();
            }

            var categoria = _vendasServices.ListarVendaId(id);
            if (categoria == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(categoria);
            }

        }

        [HttpGet]
        public IActionResult ListarVendas()
        {
            IEnumerable<Venda> list = _vendasServices.ListarVendas();

            List<VendaViewModel> vendaView = new List<VendaViewModel>();

            if (list.AsQueryable().ToList().Count == 0)
            {

                return Ok(vendaView);
            }
            else
            {
                foreach (Venda item in list.ToList())
                {
                    VendaViewModel view = new VendaViewModel()
                    {
                        IdVenda = item.IdVenda,
                        IdMercadoria = item.IdMercadoria,
                        QtdSaida = item.QtdSaida,
                        DataSaida = item.DataSaida
                    };

                    vendaView.Add(view);
                }

                return Ok(vendaView);
            }

        }

        [HttpPost]
        [Route("editar/id")]
        public IActionResult EditarVenda(int id, [FromBody] Venda venda)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Venda item = _vendasServices.ListarVendaId(id);

                    VendaViewModel compraView = new VendaViewModel();

                    VendaViewModel view = new VendaViewModel()
                    {
                        IdVenda = item.IdVenda,
                        IdMercadoria = item.IdMercadoria,
                        QtdSaida = item.QtdSaida,
                        DataSaida = item.DataSaida
                    };


                    bool alterado = _vendasServices.EditarVenda(id, venda);
                    if (alterado)
                    {
                        //Atualizar campo qtd no cadastro de produtos
                        bool produtoAtualizado = _produtosServices.AtualizarProdutoQtd(venda.IdMercadoria, venda.QtdSaida, Constantes.VENDA, Acoes.EDITE);

                    }

                    return Ok(venda);
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
        public IActionResult IncluirVenda([FromBody] Venda venda)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    venda.DataSaida = DateTime.UtcNow.AddHours(-3);
                    bool vendaConcluida = _vendasServices.IncluirVenda(venda);


                    if (vendaConcluida)
                    {
                        //Atualizar campo qtd no cadastro de produtos
                        bool produtoAtualizado = _produtosServices.AtualizarProdutoQtd(venda.IdMercadoria, venda.QtdSaida, Constantes.VENDA, Acoes.INSERT);

                    }
                    return Ok(venda);
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
        public IActionResult DeleteVenda(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Venda venda = _vendasServices.ListarVendaId(id);

                    bool deletado = _vendasServices.DeleteVenda(venda);

                    if (deletado)
                    {
                        //Atualizar campo qtd no cadastro de produtos
                        bool produtoAtualizado = _produtosServices.AtualizarProdutoQtd(venda.IdMercadoria, venda.QtdSaida, Constantes.VENDA, Acoes.DELETE);

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
