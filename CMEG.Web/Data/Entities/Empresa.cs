using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMEG.Web.Data.Entities
{
    public class Empresa
    {
        public int Id { get; set; }

        [MaxLength(60, ErrorMessage = "El campo {0} no debe exceder de {1}")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Razòn Socila")]
        public string RazonSocial { get; set; }

        [MaxLength(11, ErrorMessage = "El campo {0} no debe exceder de {1}")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "RUC")]
        public string RUC { get; set; }

        [MaxLength(15, ErrorMessage = "El campo {0} no debe exceder de {1}")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Telèfono")]
        public string Telefono { get; set; }

        [MaxLength(60, ErrorMessage = "El campo {0} no debe exceder de {1}")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Direcciòn")]
        public string Direccion { get; set; }

        [Display(Name = "Logo")]
        public string Logo { get; set; }

        [EmailAddress]
        public string Correo { get; set; }

        public ICollection<Equipo> Equipos { get; set; }
    }
}
