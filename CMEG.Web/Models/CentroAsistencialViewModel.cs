using CMEG.Web.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CMEG.Web.Models
{
    public class CentroAsistencialViewModel : CentroAsistencial
    {
        [Display(Name = "Logo")]
        public IFormFile LogoFile { get; set; }
    }
}
