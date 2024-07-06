using System;
using System.Collections.Generic;

namespace SampleProject.Core.Entities;

public partial class Testimonial
{
    public decimal TestimonialId { get; set; }

    public string TestimonialContent { get; set; }

    public DateTime? CreationDate { get; set; }

    public decimal? UserId { get; set; }

    public virtual User User { get; set; }
}
