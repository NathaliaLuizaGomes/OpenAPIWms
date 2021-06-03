using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WmsSystem.Domain.Entites.Models
{
    public class Compra
    {
        
        public int IdCompra { get; set; }
        public int IdMercadoria { get; set; }
        public int QtdEntrada { get; set; }
        public DateTime DataEntrada { get; set; }

        [Key]
        public int Seq { get; set; }
    }
}
