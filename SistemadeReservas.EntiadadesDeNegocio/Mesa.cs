using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeReservas.EntidadesDeNegocio
{
    public class Mesa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El tipo es requerido")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        public string Estado { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

    }
}
