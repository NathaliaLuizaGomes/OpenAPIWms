using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WmsSystem.Domain.Entites.Models
{
    public class Produto
    {

        [Key]
        public int Id { get; set; }
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

        [ForeignKey("Categoria")]
        public int IdCategoria { get; set; }
        public virtual Categoria Categorias { get; set; }        

    }
}
