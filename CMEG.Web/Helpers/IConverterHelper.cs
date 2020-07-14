using CMEG.Web.Data.Entities;
using CMEG.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMEG.Web.Helpers
{
    public interface IConverterHelper
    {
        CentroAsistencial ToCentroAsistencial(CentroAsistencialViewModel centroAsistencialViewModel, string path, bool isNew);
        CentroAsistencialViewModel ToCentroAsistencialViewModel(CentroAsistencial centroAsistencial);
        Empresa ToEmpresa(EmpresaViewModel empresaViewModel, string path, bool isNew);
        EmpresaViewModel ToEmpresaViewModel(Empresa empresa);
        Equipo ToEquipo(EquipoViewModel model, string path, bool isNew);
        EquipoViewModel ToEquipoViewModel(Equipo entity);
        Task<Mantenimiento> ToMantenimientoEntityAsync(MantenimientoViewModel model, bool isNew);
        MantenimientoViewModel ToMantenimientoViewModel(Mantenimiento entity);
    }
}
