﻿namespace WebQUOLA.Objects.Entities;

public class Moneda
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public ICollection<Sucursal> Sucursales { get; set; }
}
