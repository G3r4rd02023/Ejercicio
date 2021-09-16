using Ejercicio.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejercicio.Helpers
{
    public class CombosHelper : ICombosHelper
    {

        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetComboMarcas()
        {
            List<SelectListItem> list = _context.Marcas.Select(t => new SelectListItem
            {
                Text = t.Descripcion,
                Value = $"{t.Id}"
            })
               .OrderBy(t => t.Text)
               .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione una marca...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboPresentaciones()
        {
            List<SelectListItem> list = _context.Presentaciones.Select(t => new SelectListItem
            {
                Text = t.Descripcion,
                Value = $"{t.Id}"
            })
               .OrderBy(t => t.Text)
               .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione una presentación..]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboProveedores()
        {
            List<SelectListItem> list = _context.Proveedores.Select(t => new SelectListItem
            {
                Text = t.Descripcion,
                Value = $"{t.Id}"
            })
               .OrderBy(t => t.Text)
               .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un proveedor...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboZonas()
        {
            List<SelectListItem> list = _context.Zonas.Select(t => new SelectListItem
            {
                Text = t.Descripcion,
                Value = $"{t.Id}"
            })
               .OrderBy(t => t.Text)
               .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione una zona...]",
                Value = "0"
            });

            return list;
        }
    }
}
