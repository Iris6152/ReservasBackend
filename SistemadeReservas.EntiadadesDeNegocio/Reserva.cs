using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeReservas.EntidadesDeNegocio
{
    public class Reserva
    {
        public string? idServicio;

        [Key]
        public int Id { get; set; }

        [ForeignKey("Mesa")]
        [Required(ErrorMessage = "La mesa es requerida")]
        [Display(Name = "Mesa")]
        public int IdMesa { get; set; }

        [Required(ErrorMessage = "El servicio es requerido")]
        [MaxLength(100, ErrorMessage = "El largo máximo es 100 caracteres")]
        public string Servicio { get; set; }

        [Required(ErrorMessage = "El cliente es requerido")]
        [MaxLength(200, ErrorMessage = "El largo máximo es 50 caracteres")]
        public string Cliente { get; set; }

        [Required(ErrorMessage = "El telefono es requerido")]
        [MaxLength(200, ErrorMessage = "El largo máximo es 20 caracteres")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La fecha es requerida")]
        [MaxLength(200, ErrorMessage = "El largo máximo es 20 caracteres")]
        public string Fecha { get; set; }

        [Required(ErrorMessage = "Las personas son requeridos")]
        [MaxLength(200, ErrorMessage = "El largo máximo es 20 caracteres")]
        public string Personas { get; set; }

        [Required(ErrorMessage = "El horario entrada es requerido")]
        [MaxLength(200, ErrorMessage = "El largo máximo es 20 caracteres")]
        public string HorarioEntrada { get; set; }

        [Required(ErrorMessage = "El horario salida es requerido")]
        [MaxLength(200, ErrorMessage = "El largo máximo es 20 caracteres")]
        public string HorarioSalida { get; set; }


        [NotMapped]
        public int Top_Aux { get; set; }
        public Mesa Mesa { get; set; }
        public object IdServicio { get; set; }
        public string Nombre { get; set; }
    }
}
