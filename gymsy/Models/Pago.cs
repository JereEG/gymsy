using System;
using System.Collections.Generic;

namespace gymsy.Modelos;

public partial class Pago
{
    public int IdPago { get; set; }

    public int IdUsuario { get; set; }

    public int IdTipoPago { get; set; }

    public string CbuDestino { get; set; } = null!;

    public string CbuOrigen { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public decimal Monto { get; set; }

    public bool InactivoPago { get; set; }

    public virtual TipoDePago IdTipoPagoNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
