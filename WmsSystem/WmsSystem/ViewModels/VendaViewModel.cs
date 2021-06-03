using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WmsSystem.ViewModels
{
    public class VendaViewModel
    {
        public int IdVenda { get; set; }
        public int IdMercadoria { get; set; }
        public int QtdSaida { get; set; }
        public DateTime DataSaida { get; set; }
    }
}
