using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translate.Application.Features.Translate.Queries.GetTableTranslate;

namespace Translate.Application.Features.Translate.Queries.GetTranslationTables
{
    public record GetTranslationTablesQuery: IRequest<List<TablesNamesDto>>  
    {


    }
}
