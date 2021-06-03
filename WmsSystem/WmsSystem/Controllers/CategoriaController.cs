using System;
using System.Collections.Generic;
using System.Linq;
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
    public class CategoriaController : ControllerBase
    {

        private ICategoriasServices _categoriasServices;

        public CategoriaController(ICategoriasServices _categoriasServices)
        {
            this._categoriasServices = _categoriasServices;
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Categoria))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCategoria(int id)
        {
            if (id <= 0)
            {
                return new NotFoundResult();
            }

            var categoria = _categoriasServices.ListarCategoriaId(id);
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
        public IActionResult ListarCategorias()
        {
            IEnumerable<Categoria> list = _categoriasServices.ListarCategorias();

            List<CategoriaViewModels> categoriaView = new List<CategoriaViewModels>();

            if (list.AsQueryable().ToList().Count == 0)
            {
                
                return Ok(categoriaView);
            }
            else
            {
                foreach (Categoria item in list.ToList())
                {
                    CategoriaViewModels view = new CategoriaViewModels()
                    {
                        IdCategoria = item.IdCategoria,
                        NomeCategoria = item.NomeCategoria
                    };

                    categoriaView.Add(view);
                }
                
                return Ok(categoriaView);
            }
            
        }


        [HttpPost]
        [Route("editar/id")]
        public IActionResult EditarCategoria(int id, [FromBody] Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Categoria item = _categoriasServices.ListarCategoriaId(id);

                    CategoriaViewModels categoriaView = new CategoriaViewModels();
                   
                        CategoriaViewModels view = new CategoriaViewModels()
                        {                            
                            NomeCategoria = item.NomeCategoria
                        };                        
                    

                    bool alterado = _categoriasServices.EditarCategoria(id, categoria);
                    return Ok(categoria);
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
        public IActionResult IncluirCategoria([FromBody] Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _categoriasServices.IncluiCategoria(categoria);
                    return Ok(categoria);
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
