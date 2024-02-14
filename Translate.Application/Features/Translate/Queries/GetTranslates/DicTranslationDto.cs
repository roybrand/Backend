using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translate.Application.Features.Translate.Queries.GetTranslateTables
{
    public class DicTranslationDto
    {
        public long Id { get; set; }
        public string TableName { get; set; } = null!;
        public int TableCode { get; set; }
        public string Translate { get; set; }
        public short TableTypeCode { get; set; }
        public string UnitType { get; set; }
        public string UnitTypeTimestamp { get; set; }
        public string ActivityStatus { get; set; }
        public string ActivityStatusTimestamp { get; set; }
        public string AgreementType { get; set; }
        public string AgreementTypeTimestamp { get; set; }
        public string DeptName { get; set; }
        public string DeptTimestamp { get; set; }
        public string LanguageDescription { get; set; }
        public DateTime? LastUpdate { get; set; }
        public int TotalCount { get; set; }

    }
}
