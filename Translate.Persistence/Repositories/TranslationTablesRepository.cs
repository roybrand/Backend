using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translate.Application.Contracts.Persistence;
using Translate.Application.Features.Translate.Queries.GetTableTranslate;
using Translate.Application.Features.Translate.Queries.GetTranslateTables;
using Translate.Application.Features.Translate.Queries.GetTranslationTables;

namespace Translate.Persistence.Repositories
{
    public class TranslationTablesRepository : GenericRepository<TablesNamesDto>, ITranslationTablesRepository
    {
        public TranslationTablesRepository(TranslateDataContext context) : base(context)
        {
        }

      

        public async Task<List<TablesNamesDto>> GetTranslateTables()
        {
            var result = await (from translate in this._context.DicTranslations
                                join tableType in this._context.TableTypes on translate.TableTypeCode equals tableType.Code
                                select new TablesNamesDto()
                                {
                                    TableName = translate.TableName,
                                    Type = tableType.Type,
                                    LastUpdate = translate.LastUpdate.ToString().Substring(0, 11)
                                }).DistinctBy(t => t.TableName).ToListAsync();               
                         

            return result;
        }
    }
}
