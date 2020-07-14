using CMEG.Web.Data;
using CMEG.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMEG.Web.Helpers
{
    public class ConboBoxHelper : IComboBoxHelper
    {
        private readonly DataContext _context;

        public ConboBoxHelper(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetComboEquipos()
        {
            List<SelectListItem> list = _context.Equipos.Select(e => new SelectListItem
            {
                Text = e.Nombre,
                Value = $"{e.Id}"
            })
                .OrderBy(e => e.Text)
                .ToList();

            //list.Insert(0, new SelectListItem
            //{
            //    Text = "[Select a Equip]",
            //    Value = "0"
            //});

            return list;
        }
    }
}
