using Ejercicio.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ejercicio.Models
{
    public class ProductViewModel:Producto
    {
        
        [Display(Name = "Marca")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione una Marca.")]
        [Required]
        public int MarcaId { get; set; }

        
        [Display(Name = "Presentación")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione una Presentación.")]
        [Required]
        public int PresentacionId { get; set; }

        
        [Display(Name = "Proveedor")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un Proveedor.")]
        [Required]
        public int ProveedorId { get; set; }

       
        [Display(Name = "Zona")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione una Zona.")]
        [Required]
        public int ZonaId { get; set; }

        public IEnumerable<SelectListItem> Zonas { get; set; }

        public IEnumerable<SelectListItem> Presentaciones { get; set; }

        public IEnumerable<SelectListItem> Marcas { get; set; }

        public IEnumerable<SelectListItem> Proveedores { get; set; }
    }
}
