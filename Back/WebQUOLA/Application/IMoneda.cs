using WebQUOLA.Objects.Dtos;

namespace WebQUOLA.Application
{
    public interface IMoneda
    {
        Task<ResultGeneric<List<MonedaDto>>> GetAll();
    }
}