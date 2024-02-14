using System;
using System.Collections.Generic;

namespace Domain.Models;
public partial class DicAgreementType
{
    public byte AgreementTypeId { get; set; }

    public string AgreementTypeDescription { get; set; } = null!;

    public string? EnumName { get; set; }

    public byte? OrganizationSectorId { get; set; }

    public bool? IsDefault { get; set; }

    public byte[] TimeStamp { get; set; } = null!;
}
