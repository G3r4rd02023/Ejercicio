using Ejercicio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejercicio.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CreateMarcasAsync();
            await CreateZonasAsync();
            await CreatePresentacionesAsync();
            await CreateProveedoresAsync();
        }

        private async Task CreateProveedoresAsync()
        {
            if (!_context.Proveedores.Any())
            {
                _context.Proveedores.Add(new Proveedor
                {
                    Descripcion = "DIUNSA"
                });
                _context.Proveedores.Add(new Proveedor
                {
                    Descripcion = "SPORTLINE"
                });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CreatePresentacionesAsync()
        {
            if (!_context.Presentaciones.Any())
            {
                _context.Presentaciones.Add(new Presentacion
                {
                    Descripcion = "No 8"
                });
                _context.Presentaciones.Add(new Presentacion
                {
                    Descripcion = "No 9"
                });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CreateZonasAsync()
        {
            if (!_context.Zonas.Any())
            {
                _context.Zonas.Add(new Zona
                {
                    Descripcion = "CENTRO"
                });
                _context.Zonas.Add(new Zona
                {
                    Descripcion = "NORTE"
                });
                _context.Zonas.Add(new Zona
                {
                    Descripcion = "SUR"
                });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CreateMarcasAsync()
        {
            if (!_context.Marcas.Any())
            {
                _context.Marcas.Add(new Marca
                {
                    Descripcion = "ADIDAS"
                });
                _context.Marcas.Add(new Marca
                {
                    Descripcion = "PUMA"
                });
                _context.Marcas.Add(new Marca
                {
                    Descripcion = "NIKE"
                });
                await _context.SaveChangesAsync();
            }
        }
    }
}
