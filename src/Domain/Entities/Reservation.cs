using System;
using System.Collections.Generic;

namespace SampleProject.Core.Entities;

public partial class Reservation
{
    public decimal ReservationId { get; set; }

    public DateTime? ReservationDate { get; set; }

    public string ReservationNotes { get; set; }

    public decimal? Userid { get; set; }

    public decimal? Statusid { get; set; }

    public virtual Status Status { get; set; }

    public virtual User User { get; set; }
}
