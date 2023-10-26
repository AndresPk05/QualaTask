using WebQUOLA.Objects.Dtos;

namespace WebQUOLA.Application
{
    public interface ISucursal
    {
        Task<Result> Create(SucursalDto sucursal);
        Task<Result> Delete(int IdSucursal);
        Task<ResultGeneric<List<SucursalDto>>> GetSucursales(RequestDto request);
        Task<Result> UpdateSucursal(SucursalDto sucursal);
    }
}