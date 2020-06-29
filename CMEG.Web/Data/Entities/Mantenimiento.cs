using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMEG.Web.Data.Entities
{
    public class Mantenimiento
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = false)]
        public string FechaProgramacion { get; set; }

        [MaxLength(20, ErrorMessage = "El campo {0} no debe exceder de {1}")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Año que se ejcutò el Servicio")]
        public string AñoEjecucion { get; set; }

        [MaxLength(10, ErrorMessage = "El campo {0} no debe exceder de {1}")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Mantenimiento")]
        public string NumeroMantenimiento { get; set; }

        public ICollection<DetalleMantenimiento> Mantenimientos { get; set; }
    }
}
