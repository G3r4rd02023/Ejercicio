using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ejercicio.Data.Entities
{
    public class Producto
    {
        public int Id { get; set; }

        public Marca Marca { get; set; }

        public Presentacion Presentacion { get; set; }

        public Proveedor Proovedor { get; set; }

        public Zona Zona { get; set; }

        [Display(Name = "Código")]
        [MaxLength(10, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Codigo { get; set; }

        [Display(Name = "Producto")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Descripcion { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Precio { get; set; }

        
        public decimal Stock { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal IVA { get; set; }

        
        public decimal Peso { get; set; }
    }
}
