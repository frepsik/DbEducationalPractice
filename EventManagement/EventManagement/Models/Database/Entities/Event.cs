using System;
using System.Collections.Generic;

namespace EventManagement.Models.Database;

public partial class Event
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string ImagePath { get; set; } = null!;

    public DateOnly DateEvent { get; set; }

    public int Days { get; set; }

    public Guid CityId { get; set; }

    public Guid? WinnerId { get; set; }

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();

    public virtual City City { get; set; } = null!;

    public virtual User? Winner { get; set; }
}
