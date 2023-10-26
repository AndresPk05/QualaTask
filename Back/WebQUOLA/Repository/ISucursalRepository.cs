using WebQUOLA.Objects.Dtos;

namespace WebQUOLA.Repository
{
    public interface ISucursalRepository
    {
        Task Create(SucursalDto sucursal);
        Task Delete(int IdSucursal);
        Task<List<SucursalDto>> GetSucursales(RequestDto request);
        Task UpdateSucursal(SucursalDto sucursal);
    }
}