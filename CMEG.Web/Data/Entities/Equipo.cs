using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMEG.Web.Data.Entities
{
    public class Equipo
    {
        public int Id { get; set; }

        [MaxLength(60, ErrorMessage = "El campo {0} no debe exceder de {1}")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Nomre de Equipo")]
        public string Nombre { get; set; }

        [MaxLength(20, ErrorMessage = "El campo {0} no debe exceder de {1}")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Etiqueta Patrimonial")]
        public string Etiqueta { get; set; }

        [MaxLength(60, ErrorMessage = "El campo {0} no debe exceder de {1}")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Serie de Equipo")]
        public string Serie { get; set; }

        [MaxLength(60, ErrorMessage = "El campo {0} no debe exceder de {1}")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Nùmero de Licitaciòn")]
        public string Licitacion { get; set; }

        [MaxLength(10, ErrorMessage = "El campo {0} no debe exceder de {1}")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Años de Garantìa de equipo")]
        public string Garantia { get; set; }

        [MaxLength(20, ErrorMessage = "El campo {0} no debe exceder de {1}")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Tipo de Garantia de Equipo")]
        public string TipoGarantia { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}" ,ApplyFormatInEditMode = false)]
        public DateTime FechaInstalacion { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = false)]
        public DateTime FechaCulminacion { get; set; }

        [MaxLength(10, ErrorMessage = "El campo {0} no debe exceder de {1}")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Cantidad de OT>Ms a Ejecutar")]
        public int Otms { get; set; }

        [Display(Name = "Logo")]
        public string Logo { get; set; }

        public CentroAsistencial CentroAsistencial { get; set; }

        public Empresa Empresa { get; set; }

        public Marca Marca { get; set; }

        public Modelo Modelo { get; set; }

        public ICollection<DetalleMantenimiento> Mantenimientos { get; set; }
    }
}
