using System;
using System.Collections.Generic;
using System.Text;
using WmsSystem.Domain.Entites.Models;
using WmsSystem.Domain.Interfaces.Repositories;
using WmsSystem.Domain.Interfaces.Services;
using WmsSystem.Domain.Services.ServiceBase;

namespace WmsSystem.Domain.Services
{
    public class CategoriasServices : ServiceBase<Categoria>, ICategoriasServices
    {
        private readonly ICategoriasRepository _categoriasRepository;

        public CategoriasServices(ICategoriasRepository categoriasRepository) : base(categoriasRepository)
        {
            this._categoriasRepository = categoriasRepository;
        }

        public Categoria ListarCategoriaId(int Id)
        {
            return _categoriasRepository.ListarCategoriaId(Id);
        }

        public IEnumerable<Categoria> ListarCategorias()
        {
            return _categoriasRepository.ListarCategorias();
        }

        public bool IncluiCategoria(Categoria categoria)
        {
            return _categoriasRepository.IncluiCategoria(categoria);
        }

        public bool EditarCategoria(int Id, Categoria categoria)
        {
            return _categoriasRepository.EditarCategoria(Id, categoria);
        }
    }
}
