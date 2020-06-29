using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMEG.Web.Data.Entities
{
    public class DetalleMantenimiento
    {
        public int Id { get; set; }

        [Display(Name = "Fecha de Ejecuciòn")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = false)]
        public string FechaEjecucion { get; set; }

        [MaxLength(20, ErrorMessage = "El campo {0} no debe exceder de {1}")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Nùmero de OTM")]
        public string NumeroOTM { get; set; }

        [MaxLength(60, ErrorMessage = "El campo {0} no debe exceder de {1}")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Persona que Ejecutò el Servicio")]
        public string Persona { get; set; }

        public Equipo Equipo { get; set; }

        public Mantenimiento Mantenimiento { get; set; }
    }
}
