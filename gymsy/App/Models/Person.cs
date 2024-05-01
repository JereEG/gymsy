using System;
using System.Collections.Generic;

namespace gymsy.App.Models;

public partial class Person
{
    public int IdPerson { get; set; }

    public string Nickname { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Avatar { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string LastName { get; set; } = null!;

    public string NumberPhone { get; set; } = null!;

    public DateTime Birthday { get; set; }

    public string Gender { get; set; } = null!;

    public int RolId { get; set; }

    public bool Inactive { get; set; }

    

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<InstructorAudit> InstructorAudits { get; set; } = new List<InstructorAudit>();

    public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();

    public virtual ICollection<PayAudit> PayAuditDestinatarios { get; set; } = new List<PayAudit>();

    public virtual ICollection<PayAudit> PayAuditRemitentes { get; set; } = new List<PayAudit>();

    public virtual ICollection<Pay> PayDestinatarios { get; set; } = new List<Pay>();

    public virtual ICollection<Pay> PayRemitentes { get; set; } = new List<Pay>();

    public virtual ICollection<PersonAudit> PersonAudits { get; set; } = new List<PersonAudit>();

    public virtual Rol Rol { get; set; } = null!;

    public virtual ICollection<WalletAudit> WalletAudits { get; set; } = new List<WalletAudit>();

    public virtual ICollection<Wallet> Wallets { get; set; } = new List<Wallet>();
}
