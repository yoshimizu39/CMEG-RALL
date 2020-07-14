using CMEG.Web.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CMEG.Web.Models
{
    public class EquipoViewModel : Equipo
    {
        [Display(Name = "Logo")]
        public IFormFile LogoFile { get; set; }

    }
}
