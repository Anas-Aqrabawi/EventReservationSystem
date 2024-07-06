using System;
using System.Collections.Generic;

namespace SampleProject.Core.Entities;

public partial class User
{
    public decimal UserId { get; set; }

    public string Firstname { get; set; }

    public string Lastname { get; set; }

    public string Gender { get; set; }

    public string ImagePath { get; set; }

    public decimal? Roleid { get; set; }

    public decimal? Statusid { get; set; }

    public virtual Credential Credential { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Hall> Halls { get; set; } = new List<Hall>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual Status Status { get; set; }

    public virtual ICollection<Testimonial> Testimonials { get; set; } = new List<Testimonial>();

    public virtual Visainfo Visainfo { get; set; }
}
