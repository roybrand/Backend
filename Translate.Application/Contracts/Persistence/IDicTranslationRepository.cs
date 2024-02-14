using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Translate.Application.Features.Translate.Queries.GetTableTranslate;
using Translate.Application.Features.Translate.Queries.GetTranslates;
using Translate.Application.Features.Translate.Queries.GetTranslateTables;
using Translate.Application.Features.Translate.Queries.GetTranslationTables;

namespace Translate.Application.Contracts.Persistence
{
    public interface IDicTranslationRepository
    {
        Task<List<DicTranslationDto>> GetTranslations(string tableName,int tableTypeCode,
                int statusCode,int pageIndex,int pageSize);

        
    }
}
