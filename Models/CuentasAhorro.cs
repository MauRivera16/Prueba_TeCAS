using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_TeCAS.Models
{
    public class CuentasAhorro
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="Matricula obligatoria")]
        [Display(Name ="Matricula del Cliente")]
        public int Cliente_id { get; set; }

        [ForeignKey("Cliente_id")]
        public Clientes ClientObj { get; set; }

        public int Saldo { get; set; }

    }
}
