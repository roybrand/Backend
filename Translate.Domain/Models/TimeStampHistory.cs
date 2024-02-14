using System;
using System.Collections.Generic;

namespace Domain.Models;
public partial class TimeStampHistory 
{
    public long Id { get; set; }

    public string? TableName { get; set; }

    public byte[]? MaxTimeStamp { get; set; }

    public DateTime? InsertDate { get; set; }
}

public partial class TimeStampHistoryDto
{
    public string? TableName { get; set; }

    public byte[]? TimeStamp { get; set; }
}
