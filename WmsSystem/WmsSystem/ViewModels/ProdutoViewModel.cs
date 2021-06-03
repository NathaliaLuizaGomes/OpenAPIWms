using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WmsSystem.ViewModels
{
    public class ProdutoViewModel
    {        
        public string Referencia { get; set; }
        public string Nome { get; set; }
        public float PCusto { get; set; }
        public float PVenda { get; set; }
        public float Quantidade { get; set; }
        public int Estoque { get; set; }        
        public string UndMedida { get; set; }
        public string Grupo { get; set; }
        public DateTime? DtAlteracao { get; set; }
        public bool Desativado { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
    }
}
