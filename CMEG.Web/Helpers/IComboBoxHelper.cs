using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CMEG.Web.Helpers
{
    public interface IComboBoxHelper
    {
        IEnumerable<SelectListItem> GetComboEquipos();
    }
}
