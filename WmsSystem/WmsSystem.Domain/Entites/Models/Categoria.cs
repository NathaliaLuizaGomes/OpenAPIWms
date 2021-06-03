using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WmsSystem.Domain.Entites.Models
{
    public class Categoria
    {

        [Key]
        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; }
        public float Desconto { get; set; }
        public float Acrestimo { get; set; }
    }
}
