using Ejercicio.Data.Entities;
using Ejercicio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejercicio.Helpers
{
    public interface IConverterHelper
    {
        Task<Producto> ToProductAsync(ProductViewModel model, bool isNew);

        ProductViewModel ToProductViewModel(Producto producto);
    }
}
