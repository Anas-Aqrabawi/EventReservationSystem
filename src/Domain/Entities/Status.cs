using System;
using System.Collections.Generic;

namespace SampleProject.Core.Entities;

public partial class Status
{
    public decimal StatusId { get; set; }

    public string Status1 { get; set; }

    public virtual ICollection<Hall> Halls { get; set; } = new List<Hall>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
