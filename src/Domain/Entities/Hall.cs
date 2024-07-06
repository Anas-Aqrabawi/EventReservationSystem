using System;
using System.Collections.Generic;

namespace SampleProject.Core.Entities;

public partial class Hall
{
    public decimal HallId { get; set; }

    public decimal? FloorNumber { get; set; }

    public decimal? HallNumber { get; set; }

    public decimal? NumberOfTables { get; set; }

    public decimal? NumberOfChairs { get; set; }

    public decimal? HallCapacity { get; set; }

    public string HallIdentity { get; set; }

    public string HallLocation { get; set; }

    public decimal? Price { get; set; }

    public DateTime? HallAvailabilityDate { get; set; }

    public string Services { get; set; }

    public string Hall1ImagePath { get; set; }

    public string Hall2ImagePath { get; set; }

    public string Hall3ImagePath { get; set; }

    public string Hall4ImagePath { get; set; }

    public string Hall5ImagePath { get; set; }

    public decimal? Userid { get; set; }

    public decimal? Statusid { get; set; }

    public virtual Status Status { get; set; }

    public virtual User User { get; set; }
}
