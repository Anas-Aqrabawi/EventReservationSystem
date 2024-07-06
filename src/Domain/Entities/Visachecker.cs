using System;
using System.Collections.Generic;

namespace SampleProject.Core.Entities;

public partial class Visachecker
{
    public decimal VisaChecherId { get; set; }

    public decimal Cvc { get; set; }

    public string CardHolderName { get; set; }

    public decimal? Balance { get; set; }

    public decimal CardNumber { get; set; }
}
