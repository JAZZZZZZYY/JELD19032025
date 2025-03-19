using System;
using System.Collections.Generic;

namespace JELD19032025.AppWebMVC.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int? Stock { get; set; }

    public virtual ICollection<DetallesVentum> DetallesVenta { get; set; } = new List<DetallesVentum>();
}
