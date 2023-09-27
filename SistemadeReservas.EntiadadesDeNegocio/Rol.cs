using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeReservas.EntidadesDeNegocio
{
    public class Rol
    {
        [Key] 
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "El largo máximo es 30 caracteres")]
        public string Nombre { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
        public List<Usuario> Usuarios { get; set; } //propiedad de navegación
    }
}
