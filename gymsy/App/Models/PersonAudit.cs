using System;
using System.Collections.Generic;

namespace gymsy.App.Models;

public partial class PersonAudit
{
    public int AuditId { get; set; }

    public DateTime ActionDate { get; set; }

    public string ActionUser { get; set; } = null!;

    public char ActionType { get; set; } = ' ';

    public int? IdPerson { get; set; }

    public string FirstName { get; set; } = null!;

    public int RolId { get; set; }

    public string? NicknameAntigua { get; set; }

    public string? NicknameNueva { get; set; }

    public bool? InactiveAntigua { get; set; }

    public bool? InactiveNueva { get; set; }

    public string? GenderAntigua { get; set; }

    public string? GenderNueva { get; set; }

    public DateTime? BirthdayAntigua { get; set; }

    public DateTime? BirthdayNueva { get; set; }

    public string? NumberPhoneAntigua { get; set; }

    public string? NumberPhoneNueva { get; set; }

    public string? LastNameAntigua { get; set; }

    public string? LastNameNueva { get; set; }

    public DateTime? CreatedAtAntigua { get; set; }

    public DateTime? CreatedAtNueva { get; set; }

    public string? PasswordAntigua { get; set; }

    public string? PasswordNueva { get; set; }

    public string? AvatarAntigua { get; set; }

    public string? AvatarNueva { get; set; }

    public virtual Person? IdPersonNavigation { get; set; }

    public virtual Rol Rol { get; set; } = null!;
}
