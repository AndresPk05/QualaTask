using WebQUOLA.Objects.Dtos;
using WebQUOLA.Repository;

namespace WebQUOLA.Application
{
    public class Sucursal : ISucursal
    {
        ISucursalRepository _repository;

        public Sucursal(ISucursalRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultGeneric<List<SucursalDto>>> GetSucursales(RequestDto request)
        {
            try
            {
                var sucursales = await _repository.GetSucursales(request);
                return new ResultGeneric<List<SucursalDto>>
                {
                    Result = sucursales,
                    Count = request.Count,
                };
            }
            catch (Exception ex)
            {

                return new ResultGeneric<List<SucursalDto>>
                {
                    Error = true,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Result> Delete(int IdSucursal)
        {
            try
            {
                await _repository.Delete(IdSucursal);
                return new Result();
            }
            catch (Exception ex)
            {

                return new Result
                {
                    Error = true,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Result> UpdateSucursal(SucursalDto sucursal)
        {
            try
            {
                await _repository.UpdateSucursal(sucursal);
                return new Result();
            }
            catch (Exception ex)
            {

                return new Result
                {
                    Error = true,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Result> Create(SucursalDto sucursal)
        {
            try
            {
                var resultValidation = ValidateRequest(sucursal);
                if (resultValidation.Error)
                    return resultValidation;

                await _repository.Create(sucursal);
                return new Result();
            }
            catch (Exception ex)
            {
                return new Result
                {
                    Error = true,
                    Message = ex.Message
                };
            }
        }

        private Result ValidateRequest(SucursalDto sucursal)
        {
            if (sucursal is null)
                return new Result
                {
                    Error = true,
                    Message = "No se recibio la sucursal que desea crear"
                };

            if (sucursal.Codigo is 0)
                return new Result
                {
                    Error = true,
                    Message = "El codigo de la sucursal debe ser mayor a cero"
                };

            if (string.IsNullOrEmpty(sucursal.Direccion) || sucursal.Direccion.Length > 250)
                return new Result
                {
                    Error = true,
                    Message = "La direccion no puede estar vacia o superar 250 caracteres"
                };

            if (string.IsNullOrEmpty(sucursal.Descripcion) || sucursal.Descripcion.Length > 250)
                return new Result
                {
                    Error = true,
                    Message = "La descripcion no puede estar vacia o superar 250 caracteres"
                };

            if (string.IsNullOrEmpty(sucursal.Identificacion) || sucursal.Identificacion.Length > 50)
                return new Result
                {
                    Error = true,
                    Message = "La Identificación no puede estar vacia o superar 50 caracteres"
                };

            if (sucursal.FechaCreacion.Date <= DateTime.Now.Date)
                return new Result
                {
                    Error = true,
                    Message = "La Fecha no puede ser menor a la fecha actual"
                };

            return new Result();
        }
    }
}
