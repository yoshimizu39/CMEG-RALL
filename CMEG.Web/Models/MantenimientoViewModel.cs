using CMEG.Web.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMEG.Web.Models
{
    public class MantenimientoViewModel : Mantenimiento
    {
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = false)]
        [Display(Name = "Fecha Instalaciòn")]
        public DateTime FechaInstalacion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Equipo")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecciona un Equipo")]
        public int IdEquipo { get; set; }

        public IEnumerable<SelectListItem> Equipos { get; set; }
    }
}
