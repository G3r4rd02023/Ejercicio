﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejercicio.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboZonas();

        IEnumerable<SelectListItem> GetComboMarcas();

        IEnumerable<SelectListItem> GetComboPresentaciones();

        IEnumerable<SelectListItem> GetComboProveedores();

    }
}
