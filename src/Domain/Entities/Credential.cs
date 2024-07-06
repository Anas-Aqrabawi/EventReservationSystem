using System;
using System.Collections.Generic;

namespace SampleProject.Core.Entities;

public partial class Credential
{
    public decimal CredentialId { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public decimal? UserId { get; set; }

    public virtual User User { get; set; }
}
