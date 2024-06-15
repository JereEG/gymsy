using System;
using System.Collections.Generic;

namespace gymsy.Models;

public partial class TipoDePago
{
    public int IdTipoPago { get; set; }

    public string Nombre { get; set; } = null!;

    public bool TipoPagoInactivo { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
