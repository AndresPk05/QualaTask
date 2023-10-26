using Microsoft.EntityFrameworkCore;
using WebQUOLA.Model;
using WebQUOLA.Objects.Dtos;
using WebQUOLA.Objects.Entities;

namespace WebQUOLA.Repository;

public class SucursalRepository : ISucursalRepository
{
    QualaContext _ctx;
    public SucursalRepository(QualaContext ctx)
    {
        _ctx = ctx;
    }
    public async Task<List<SucursalDto>> GetSucursales(RequestDto request)
    {
        var query = _ctx.Sucursales.Where(x => x.IsActive)
            .Select(x => new SucursalDto
            {
                IsActive = x.IsActive,
                Codigo = x.Codigo,
                Descripcion = x.Descripcion,
                Direccion = x.Direccion,
                FechaCreacion = x.FechaCreacion.Date,
                Identificacion = x.Identificacion,
                Id = x.Id,
            });

        if (request.CodigoSucursal != 0)
            query = query.Where(x => x.Codigo == request.CodigoSucursal);

        request.Count = query.Count();

        var result = await query.OrderBy(x => x.FechaCreacion)
            .Skip(request.CantidadRegistros * (request.PaginaActual))
            .Take(request.CantidadRegistros)
            .ToListAsync();

        return result;
    }

    public async Task Delete(int IdSucursal)
    {
        var entity = await _ctx.Sucursales.FirstOrDefaultAsync(x => x.Id == IdSucursal);
        if (entity is null)
            return;

        entity.IsActive = false;
        entity.FechaEliminacion = DateTime.Now;
        await _ctx.SaveChangesAsync();
    }

    public async Task UpdateSucursal(SucursalDto sucursal)
    {
        var entity = await _ctx.Sucursales.FirstOrDefaultAsync(x => x.Id == sucursal.Id);
        if (entity is null)
            return;

        entity.Descripcion = sucursal.Descripcion;
        entity.Codigo = sucursal.Codigo;
        entity.Direccion = sucursal.Direccion;
        entity.Identificacion = sucursal.Identificacion;

        await _ctx.SaveChangesAsync();
    }

    public async Task Create(SucursalDto sucursal)
    {
        var entitie = new Sucursal
        {
            Id = sucursal.Id,
            IsActive = true,
            Codigo = sucursal.Codigo,
            Descripcion = sucursal.Descripcion,
            Direccion = sucursal.Direccion,
            Identificacion = sucursal.Direccion,
            MonedaId = sucursal.MonedaId,
            FechaCreacion = sucursal.FechaCreacion,
        };

        _ctx.Sucursales.Add(entitie);
        await _ctx.SaveChangesAsync();
    }
}
