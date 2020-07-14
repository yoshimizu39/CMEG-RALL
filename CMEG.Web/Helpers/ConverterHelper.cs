using CMEG.Web.Data;
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
        private readonly DataContext _context;
        private readonly IComboBoxHelper _combo;

        public ConverterHelper(DataContext context, IComboBoxHelper combo)
        {
            _context = context;
            _combo = combo;
        }
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

        public Equipo ToEquipo(EquipoViewModel model, string path, bool isNew)
        {
            return new Equipo
            {
                CentroAsistencial = model.CentroAsistencial,
                Empresa = model.Empresa,
                Etiqueta = model.Etiqueta,
                FechaCulminacion = model.FechaCulminacion,
                FechaInstalacion = model.FechaInstalacion,
                Garantia = model.Garantia,
                Id = isNew ? 0 : model.Id,
                Licitacion = model.Licitacion,
                Logo = path,
                Mantenimientos = model.Mantenimientos,
                Marca = model.Marca,
                Modelo = model.Modelo,
                Nombre = model.Nombre,
                Otms = model.Otms,
                Serie = model.Serie,
                TipoGarantia = model.TipoGarantia
            };
        }

        public EquipoViewModel ToEquipoViewModel(Equipo entity)
        {
            return new EquipoViewModel
            {
                TipoGarantia = entity.TipoGarantia,
                Serie = entity.Serie,
                Otms = entity.Otms,
                Nombre = entity.Nombre,
                Modelo = entity.Modelo,
                CentroAsistencial = entity.CentroAsistencial,
                Empresa = entity.Empresa,
                Etiqueta = entity.Etiqueta,
                FechaCulminacion = entity.FechaCulminacion,
                FechaInstalacion = entity.FechaInstalacion,
                Garantia = entity.Garantia,
                Id = entity.Id,
                Licitacion = entity.Licitacion,
                Logo = entity.Logo,
                Mantenimientos = entity.Mantenimientos,
                Marca = entity.Marca
            };
        }

        public async Task<Mantenimiento> ToMantenimientoEntityAsync(MantenimientoViewModel model, bool isNew)
        {
            return new Mantenimiento
            {
                AñoEjecucion = model.AñoEjecucion,
                DetalleMantenimientos = model.DetalleMantenimientos,
                FechaProgramacion = model.FechaProgramacion,
                Id = isNew ? 0 : model.Id,
                NumeroMantenimiento = model.NumeroMantenimiento,
                Equipo = await _context.Equipos.FindAsync(model.IdEquipo)                           
            };
        }

        public MantenimientoViewModel ToMantenimientoViewModel(Mantenimiento entity)
        {
            return new MantenimientoViewModel
            {
                AñoEjecucion = entity.AñoEjecucion,
                DetalleMantenimientos = entity.DetalleMantenimientos,
                FechaProgramacion = entity.FechaProgramacion,
                Id = entity.Id,
                Equipo = entity.Equipo,
                NumeroMantenimiento = entity.NumeroMantenimiento,
                IdEquipo = entity.Equipo.Id,
                Equipos = _combo.GetComboEquipos(),
                FechaInstalacion = entity.Equipo.FechaInstalacion
            };
        }
    }
}
