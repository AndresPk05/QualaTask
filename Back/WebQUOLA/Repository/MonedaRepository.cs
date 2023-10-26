using Microsoft.EntityFrameworkCore;
using WebQUOLA.Model;
using WebQUOLA.Objects.Dtos;

namespace WebQUOLA.Repository
{
    public class MonedaRepository : IMonedaRepository
    {
        QualaContext _ctx;
        public MonedaRepository(QualaContext context)
        {
            _ctx = context;
        }

        public async Task<List<MonedaDto>> GetAllAsync()
        {
            var monedas = await _ctx.Monedas.Select(x => new MonedaDto
            {
                Id = x.Id,
                Codigo = x.Codigo,
                Nombre = x.Nombre,
            })
            .ToListAsync();

            return monedas;
        }
    }
}
