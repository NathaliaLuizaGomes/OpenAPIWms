using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WmsSystem.ViewModels
{
    public class CompraViewModels
    {
        public int IdCompra { get; set; }
        public int IdMercadoria { get; set; }
        public int QtdEntrada { get; set; }
        public DateTime DataEntrada { get; set; }
    }
}
