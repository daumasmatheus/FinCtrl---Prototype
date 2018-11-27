using System;
using System.ComponentModel.DataAnnotations;

namespace FinCtrl.Domain.Entities
{
    public class Financas
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }
        public string Observacao { get; set; }
        public decimal Valor { get; set; }
        public int TipoId { get; set; }

        public virtual Tipo Tipo { get; set; }
    }
}