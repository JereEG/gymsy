using System;
using System.Collections.Generic;

namespace gymsy.App.Models;

public partial class Wallet
{
    public int IdWallet { get; set; }

    public double Total { get; set; }

    public double Retirable { get; set; }

    public string? CBU { get; set; }
    public bool Inactive { get; set; }

    public int IdPerson { get; set; }

    public virtual Person IdPersonNavigation { get; set; } = null!;

    public virtual ICollection<WalletAudit> WalletAudits { get; set; } = new List<WalletAudit>();
}
