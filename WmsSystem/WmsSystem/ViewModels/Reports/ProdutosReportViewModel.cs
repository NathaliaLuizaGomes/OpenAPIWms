using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WmsSystem.ViewModels.Reports
{
    public class ProdutosReportViewModel
    {
        public int Id { get; set; }
        public string Referencia { get; set; }
        public string Nome { get; set; }
        public float PCusto { get; set; }
        public float PVenda { get; set; }
        public float Quantidade { get; set; }
        public DateTime? DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }

    }
}
