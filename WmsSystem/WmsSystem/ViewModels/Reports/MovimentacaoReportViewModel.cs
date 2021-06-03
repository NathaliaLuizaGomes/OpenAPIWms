using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WmsSystem.ViewModels.Reports
{
    public class MovimentacaoReportViewModel
    {
        public int IdProduto { get; set; }
        public string Referencia { get; set; }
        public string NomeProduto { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public int? IdVenda { get; set; }
        public int QtdVenda { get; set; }
        public int? IdCompra { get; set; }
        public int QtdCompra { get; set; }

    }
}
