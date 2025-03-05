using System;
using System.Collections.Generic;

namespace EventManagement.Models.Database;

public partial class Jury
{
    public Guid Id { get; set; }

    public Guid DirectionId { get; set; }

    public Guid UserId { get; set; }

    public virtual ICollection<Activity> ActivityFifthJuries { get; set; } = new List<Activity>();

    public virtual ICollection<Activity> ActivityFirstJuries { get; set; } = new List<Activity>();

    public virtual ICollection<Activity> ActivityFourthJuries { get; set; } = new List<Activity>();

    public virtual ICollection<Activity> ActivitySecondJuries { get; set; } = new List<Activity>();

    public virtual ICollection<Activity> ActivityThirdJuries { get; set; } = new List<Activity>();

    public virtual Direction Direction { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
