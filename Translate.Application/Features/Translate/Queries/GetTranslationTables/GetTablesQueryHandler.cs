using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translate.Application.Contracts.Persistence;
using Translate.Application.Features.Translate.Queries.GetTableTranslate;
using Translate.Application.Features.Translate.Queries.GetTranslates;
using Translate.Application.Features.Translate.Queries.GetTranslateTables;

namespace Translate.Application.Features.Translate.Queries.GetTranslationTables
{
    public class GetTablesQueryHandler : IRequestHandler<GetTranslationTablesQuery, List<TablesNamesDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITranslationTablesRepository _translationTablesRepository;

        public GetTablesQueryHandler(IMapper mapper, ITranslationTablesRepository translationTablesRepository)
        {
            _mapper = mapper;
            _translationTablesRepository = translationTablesRepository;
        }

        public async Task<List<TablesNamesDto>> Handle(GetTranslationTablesQuery request, CancellationToken cancellationToken)
        {
            var translationTables = await _translationTablesRepository.GetTranslateTables();

            return translationTables;
        }
    }
}
