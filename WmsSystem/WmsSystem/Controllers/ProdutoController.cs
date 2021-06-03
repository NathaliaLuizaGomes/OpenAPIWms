using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WmsSystem.Domain.Entites.Models;
using WmsSystem.Domain.Interfaces.Services;
using WmsSystem.ViewModels;

namespace WmsSystem.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private IProdutosServices _produtosServices;
        private ICategoriasServices _categoriasServices;

        public ProdutoController(IProdutosServices _produtosServices,
            ICategoriasServices _categoriasServices)
        {
            this._produtosServices = _produtosServices;
            this._categoriasServices = _categoriasServices;
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Produto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetProduto(int id)      {
           
            if (id <= 0)
            {
                return new NotFoundResult();
            }

            var produto = _produtosServices.ListarProdutoId(id);
            if(produto == null)
            {
                return NotFound();
            }
            else
            {


                return Ok(produto);
            }
            
        }

        [HttpGet]
        public IActionResult ListarProdutos()
        {
            IEnumerable<Produto> list = _produtosServices.ListarProdutosAtivos();
            List<ProdutoViewModel> produtoView = new List<ProdutoViewModel>();

            if (list.AsQueryable().ToList().Count == 0)
            {

                return Ok(produtoView);
            }
            else
            {
                foreach (Produto item in list.ToList())
                {
                    var nomeCategoria = _categoriasServices.GetById(item.IdCategoria);                    

                    ProdutoViewModel view = new ProdutoViewModel()
                    {
                        Referencia = item.Referencia,
                        Nome = item.Nome,
                        PCusto = item.PCusto,
                        PVenda = item.PVenda,
                        Quantidade = item.Quantidade,
                        Estoque = item.Estoque,
                        UndMedida = item.UndMedida,
                        Grupo = item.Grupo,
                        DtAlteracao = item.DtAlteracao,                       
                        Categoria = item.IdCategoria == 0 ? "" : nomeCategoria.NomeCategoria

                    };

                    produtoView.Add(view);
                }

            }

            return Ok(produtoView);
        }


        [HttpPost]
        [Route("editar/id")]
        public IActionResult EditarProduto(int id, [FromBody] Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   bool alterado = _produtosServices.EditarProduto(id, produto);
                    return Ok(produto);
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
        public IActionResult IncluirProduto([FromBody] Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _produtosServices.IncluirProduto(produto);
                    return Ok(produto);
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
        [Route("desativar/id")]
        public IActionResult DesativarProduto(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Produto produto = _produtosServices.ListarProdutoId(id);

                    produto.Desativado = true;
                    bool alterado = _produtosServices.DesativarProduto(produto);
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

        [HttpDelete("{id}")]
        public IActionResult DeleteProduto(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Produto produto =  _produtosServices.ListarProdutoId(id);
                    
                    produto.Desativado = true;
                    bool deletado = _produtosServices.DeleteProduto(produto);
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
