using Ejercicio.Data;
using Ejercicio.Data.Entities;
using Ejercicio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejercicio.Helpers
{
    public class ConverterHelper : IConverterHelper
    {

        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }
        public async Task<Producto> ToProductAsync(ProductViewModel model,bool isNew)
        {
            return new Producto
            {
                Marca = await _context.Marcas.FindAsync(model.MarcaId),
                Presentacion = await _context.Presentaciones.FindAsync(model.PresentacionId),
                Proovedor = await _context.Proveedores.FindAsync(model.ProveedorId),
                Zona = await _context.Zonas.FindAsync(model.ZonaId),
                Descripcion = model.Descripcion,
                Id = isNew ? 0 : model.Id,
                Codigo = model.Codigo,
                Stock = model.Stock,
                IVA = model.IVA,
                Precio = model.Precio,
                Peso = model.Peso
            };
        }

        public ProductViewModel ToProductViewModel(Producto producto)
        {
            return new ProductViewModel
            {
                Marcas = _combosHelper.GetComboMarcas(),
                Presentaciones = _combosHelper.GetComboPresentaciones(),
                Proveedores = _combosHelper.GetComboProveedores(),
                Zonas = _combosHelper.GetComboZonas(),
                Marca = producto.Marca,
                MarcaId = producto.Marca.Id,
                Presentacion = producto.Presentacion,
                PresentacionId = producto.Presentacion.Id,
                Proovedor = producto.Proovedor,
                ProveedorId = producto.Proovedor.Id,
                Zona = producto.Zona,
                ZonaId = producto.Zona.Id,
                Descripcion = producto.Descripcion,
                Id = producto.Id,
                Codigo = producto.Codigo,
                Stock = producto.Stock,
                IVA = producto.IVA,
                Precio = producto.Precio,
                Peso = producto.Peso
            };
        }
    }
}
