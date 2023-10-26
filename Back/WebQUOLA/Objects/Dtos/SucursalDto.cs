﻿namespace WebQUOLA.Objects.Dtos;

public record SucursalDto
{
    public int Id { get; set; }
    public int Codigo { get; set; }
    public string Descripcion { get; set; }
    public string Direccion { get; set; }
    public string Identificacion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaEliminacion { get; set; }
    public bool IsActive { get; set; }
    public int MonedaId { get; set; }
    public MonedaDto Moneda { get; set; }
}
