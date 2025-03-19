using System;
using System.Collections.Generic;

namespace JELD19032025.AppWebMVC.Models;

public partial class Venta
{
    public int Id { get; set; }

    public string Correlativo { get; set; } = null!;

    public DateTime? FechaVenta { get; set; }

    public decimal? Total { get; set; }

    public string? NombreCliente { get; set; }

    public virtual ICollection<DetallesVentum> DetallesVenta { get; set; } = new List<DetallesVentum>();
}
