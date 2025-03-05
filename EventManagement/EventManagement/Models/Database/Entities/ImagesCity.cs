using System;
using System.Collections.Generic;

namespace EventManagement.Models.Database;

public partial class ImagesCity
{
    public Guid Id { get; set; }

    public Guid NameId { get; set; }

    public Guid? ImageId { get; set; }

    public virtual ImagesCity1? Image { get; set; }

    public virtual City Name { get; set; } = null!;
}
