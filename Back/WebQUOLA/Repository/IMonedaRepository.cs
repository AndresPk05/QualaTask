using WebQUOLA.Objects.Dtos;

namespace WebQUOLA.Repository
{
    public interface IMonedaRepository
    {
        Task<List<MonedaDto>> GetAllAsync();
    }
}