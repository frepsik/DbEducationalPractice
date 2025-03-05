using System;
using System.Collections.Generic;

namespace EventManagement.Models.Database;

public partial class User
{
    public Guid Id { get; set; }

    public string FullName { get; set; } = null!;

    public Guid GenderId { get; set; }

    public Guid StateId { get; set; }

    public string Email { get; set; } = null!;

    public DateOnly Birthday { get; set; }

    public Guid CountryId { get; set; }

    public string Phone { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? ImagePath { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual Gender Gender { get; set; } = null!;

    public virtual Jury? Jury { get; set; }

    public virtual Moderator? Moderator { get; set; }

    public virtual UserState State { get; set; } = null!;
}
