using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WmsSystem.Domain.Entites.Models;
using WmsSystem.Domain.Interfaces.Services;

namespace WmsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionsController : ControllerBase
    {
        private ICategoriasServices _categoriasServices;
        private IProdutosServices _produtosServices;

        public ActionsController(ICategoriasServices _categoriasServices,
            IProdutosServices _produtosServices)
        {
            this._categoriasServices = _categoriasServices;
            this._produtosServices = _produtosServices;
        }

        [HttpPost]
        [Route("desconto/idCategoria")]
        public IActionResult DescontoProdutoPorCategoria(int idCategoria)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var descontoCategoria = _categoriasServices.GetById(idCategoria);
                    IEnumerable<Produto> listaProdutos = _produtosServices.ListarProdutosAtivos();


                    bool alterado = _produtosServices.DescontoProduto(descontoCategoria.Desconto, listaProdutos);
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

        [HttpPost]
        [Route("acrescimo/idCategoria")]
        public IActionResult AcrescimoProdutoPorCategoria(int idCategoria)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var acrescimoCategoria = _categoriasServices.GetById(idCategoria);
                    IEnumerable<Produto> listaProdutos = _produtosServices.ListarProdutosAtivos();


                    bool alterado = _produtosServices.AcrescimoProduto(acrescimoCategoria.Acrestimo, listaProdutos);
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
