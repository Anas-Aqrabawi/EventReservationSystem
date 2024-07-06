using System;
using System.Collections.Generic;

namespace SampleProject.Core.Entities;

public partial class Feedback
{
    public decimal FeedbackId { get; set; }

    public string FeedbackContent { get; set; }

    public decimal? Rating { get; set; }

    public DateTime? CreationDate { get; set; }

    public decimal? UserId { get; set; }

    public decimal? HallId { get; set; }

    public virtual User User { get; set; }
}
