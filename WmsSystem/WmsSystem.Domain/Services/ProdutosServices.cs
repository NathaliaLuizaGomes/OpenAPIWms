using System;
using System.Collections.Generic;
using System.Text;
using WmsSystem.Domain.Entites.Models;
using WmsSystem.Domain.Interfaces.Repositories;
using WmsSystem.Domain.Interfaces.Services;
using WmsSystem.Domain.Services.ServiceBase;

namespace WmsSystem.Domain.Services
{
    public class ProdutosServices : ServiceBase<Produto>, IProdutosServices
    {
        private readonly IProdutosRepository _produtosRepository;

        public ProdutosServices(IProdutosRepository produtosRepository) : base(produtosRepository)
        {
            this._produtosRepository = produtosRepository;
        }

        public Produto ListarProdutoId(int Id)
        {
            return _produtosRepository.ListarProdutoId(Id);
        }

        public IEnumerable<Produto> ListarProdutosAtivos()
        {
            return _produtosRepository.ListarProdutosAtivos();
        }

        public bool IncluirProduto(Produto produto)
        {
           return _produtosRepository.IncluirProduto(produto);
        }

        public bool EditarProduto(int Id, Produto produto)
        {
            return _produtosRepository.EditarProduto(Id, produto);
        }
        public bool DesativarProduto(Produto produto)
        {
            return _produtosRepository.DesativarProduto(produto);
        }
        public bool DeleteProduto(Produto produto)
        {
            return _produtosRepository.DeleteProduto(produto);
        }
        public bool AtualizarProdutoQtd(int Id, float Qtd, string type, string acoes)
        {
            return _produtosRepository.AtualizarProdutoQtd(Id, Qtd, type, acoes);
        }
        public bool DescontoProduto(float desconto, IEnumerable<Produto> listaProduto)
        {
            return _produtosRepository.DescontoProduto(desconto, listaProduto);
        }
        public bool AcrescimoProduto(float acrescimo, IEnumerable<Produto> listaProdutos)
        {
            return _produtosRepository.DescontoProduto(acrescimo, listaProdutos);
        }
    }
}
