using CMEG.Web.Data.Entities;
using CMEG.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMEG.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public CentroAsistencial ToCentroAsistencial(CentroAsistencialViewModel model, string path, bool isNew)
        {
            return new CentroAsistencial
            {
                Equipos = model.Equipos,
                Id = isNew ? 0 : model.Id,
                Logo = path,
                Nombre = model.Nombre
            };
        }

        public CentroAsistencialViewModel ToCentroAsistencialViewModel(CentroAsistencial entidad)
        {
            return new CentroAsistencialViewModel
            {
                Equipos = entidad.Equipos,
                Id = entidad.Id,
                Logo = entidad.Logo,
                Nombre = entidad.Nombre
            };
        }

        public Empresa ToEmpresa(EmpresaViewModel model, string path, bool isNew)
        {
            return new Empresa
            {
                Correo = model.Correo,
                Direccion = model.Direccion,
                Equipos = model.Equipos,
                Id = isNew ? 0 : model.Id,
                Logo = path,
                RazonSocial = model.RazonSocial,
                RUC = model.RUC,
                Telefono = model.Telefono
            };
        }

        public EmpresaViewModel ToEmpresaViewModel(Empresa entidad)
        {
            return new EmpresaViewModel
            {
                Correo = entidad.Correo,
                Direccion = entidad.Direccion,
                Equipos = entidad.Equipos,
                Id = entidad.Id,
                Logo = entidad.Logo,
                RazonSocial = entidad.RazonSocial,
                RUC = entidad.RUC,
                Telefono = entidad.Telefono
            };
        }
    }
}
