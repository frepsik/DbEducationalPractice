using System;
using System.Collections.Generic;

namespace EventManagement.Models.Database;

public partial class Activity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int NumberDay { get; set; }

    public TimeOnly TimeStart { get; set; }

    public Guid? ModeratorId { get; set; }

    public Guid? FirstJuryId { get; set; }

    public Guid? SecondJuryId { get; set; }

    public Guid? ThirdJuryId { get; set; }

    public Guid? FourthJuryId { get; set; }

    public Guid? FifthJuryId { get; set; }

    public Guid EventId { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual Jury? FifthJury { get; set; }

    public virtual Jury? FirstJury { get; set; }

    public virtual Jury? FourthJury { get; set; }

    public virtual Moderator? Moderator { get; set; }

    public virtual Jury? SecondJury { get; set; }

    public virtual Jury? ThirdJury { get; set; }
}
