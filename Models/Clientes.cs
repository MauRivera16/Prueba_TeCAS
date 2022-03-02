using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_TeCAS.Models
{
    public class Clientes
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="Nombre Obligatorio")]
        [Display(Name =("Nombre del Cliente"))]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido Obligatorio")]
        [Display(Name = ("Apellido Paterno del Cliente"))]
        public string  ApellidoP { get; set; }

        [Required(ErrorMessage = "Apellido Obligatorio")]
        [Display(Name = ("Apellido Materno del Cliente"))]
        public string ApellidoM { get; set; }


        [Required(ErrorMessage = "Genero Obligatorio")]
        [Display(Name = ("Genero Materno del Cliente"))]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Matricula Obligatoria")]
        [Display(Name = ("Genera una matricula para ti"))]
        [MaxLength(7)]
        [RegularExpression(@"[a-zA-z]{3}-[0-9]{3}$", ErrorMessage ="El formato es ABC-000")]
        public string Matricula { get; set; }



    }
}
