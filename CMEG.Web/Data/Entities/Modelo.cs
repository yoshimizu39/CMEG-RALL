using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CMEG.Web.Data.Entities
{
    public class Modelo
    {
        public int Id { get; set; }

        [MaxLength(60, ErrorMessage = "El campo {0} no debe exceder de {1}")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Modelo ed equipo")]
        public string Nombre { get; set; }

        public ICollection<Equipo> Equipos { get; set; }
    }
}
