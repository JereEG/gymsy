using System;
using System.Collections.Generic;

namespace gymsy.App.Models;

public partial class WalletAudit
{
    public int AuditId { get; set; }

    public DateTime ActionDate { get; set; }

    public string ActionUser { get; set; } = null!;

    public string ActionType { get; set; } = null!;

    public int? IdWallet { get; set; }

    public int IdPerson { get; set; }

    public double? TotalAntigua { get; set; }

    public double? TotalNueva { get; set; }

    public double? RetirableAntigua { get; set; }

    public double? RetirableNueva { get; set; }

    public bool? InactiveAntigua { get; set; }

    public bool? InactiveNueva { get; set; }

    public string? CBU_antigua { get; set; }
    public string? CBU_nueva { get; set; }

    public virtual Person IdPersonNavigation { get; set; } = null!;

    public virtual Wallet? IdWalletNavigation { get; set; }
}
