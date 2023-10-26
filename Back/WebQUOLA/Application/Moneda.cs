using WebQUOLA.Objects.Dtos;
using WebQUOLA.Repository;

namespace WebQUOLA.Application
{
    public class Moneda : IMoneda
    {
        IMonedaRepository _repository;

        public Moneda(IMonedaRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultGeneric<List<MonedaDto>>> GetAll()
        {
            try
            {
                var monedas = await _repository.GetAllAsync();
                return new ResultGeneric<List<MonedaDto>>
                {
                    Result = monedas,
                };
            }
            catch (Exception ex)
            {

                return new ResultGeneric<List<MonedaDto>>
                {
                    Error = true,
                    Message = ex.Message,
                };
            }
        }
    }
}
