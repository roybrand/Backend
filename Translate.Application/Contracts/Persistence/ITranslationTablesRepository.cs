using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translate.Application.Features.Translate.Queries.GetTableTranslate;

namespace Translate.Application.Contracts.Persistence
{
    public interface ITranslationTablesRepository
    {
        Task<List<TablesNamesDto>> GetTranslateTables();
    }
}
