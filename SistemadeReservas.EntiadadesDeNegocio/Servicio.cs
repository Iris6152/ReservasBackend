using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeReservas.EntidadesDeNegocio
{
    public class Servicio
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100, ErrorMessage = "El largo máximo es de 30 caracteres")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        [MaxLength(50, ErrorMessage = "El largo máximo es de 30 caracteres")]
        public string Estado { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
    }
}
