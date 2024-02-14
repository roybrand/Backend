using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class DicActivityStatus
{
    public short Status { get; set; }

    public string? StatusDescription { get; set; }

    public string? EnumName { get; set; }

    public byte[] TimeStamp { get; set; } = null!;
}
