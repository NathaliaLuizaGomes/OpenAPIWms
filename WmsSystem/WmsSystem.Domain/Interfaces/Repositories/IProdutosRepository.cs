using System;
using System.Collections.Generic;
using System.Text;
using WmsSystem.Domain.Entites.Models;

namespace WmsSystem.Domain.Interfaces.Repositories
{
    public interface IProdutosRepository : IRepositoryBase<Produto>
    {
        Produto ListarProdutoId(int Id);
        IEnumerable<Produto> ListarProdutosAtivos();
        bool IncluirProduto(Produto produto);
        bool EditarProduto(int Id, Produto produto);
        bool DesativarProduto(Produto produto);
        bool DeleteProduto(Produto produto);
        bool AtualizarProdutoQtd(int Id, float Qtd, string type, string acoes);
        bool DescontoProduto(float desconto, IEnumerable<Produto> listaProduto);
        bool AcrescimoProduto(float acrescimo, IEnumerable<Produto> listaProdutos);
    }
}
