using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WmsSystem.Domain.Entites.Models
{
    public class Venda
    {
        public int IdVenda { get; set; }
        public int IdMercadoria { get; set; }
        public int QtdSaida { get; set; }
        public DateTime DataSaida { get; set; }

        [Key]
        public int Seq { get; set; }
    }
}
