﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ejercicio.Data.Entities
{
    public class Presentacion
    {
        public int Id { get; set; }

        [Display(Name = "Presentación")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Descripcion { get; set; }

        public ICollection<Producto> Productos { get; set; }
    }
}
