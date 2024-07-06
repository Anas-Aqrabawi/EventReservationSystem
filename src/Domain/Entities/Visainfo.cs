using System;
using System.Collections.Generic;

namespace SampleProject.Core.Entities;

public partial class Visainfo
{
    public decimal PaymentId { get; set; }

    public decimal Cvc { get; set; }

    public string CardHolderName { get; set; }

    public decimal CardNumber { get; set; }

    public decimal? UserId { get; set; }

    public virtual User User { get; set; }
}
