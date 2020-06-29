using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMEG.Web.Data.Entities
{
    public class CentroAsistencial
    {
        public int Id { get; set; }

        [MaxLength(60, ErrorMessage = "El campo {0} no debe exceder de {1}")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Centro Asistencial")]
        public string Nombre { get; set; }

        [Display(Name = "Logo")]
        public string Logo { get; set; }

        public ICollection<Equipo> Equipos { get; set; }
    }
}
