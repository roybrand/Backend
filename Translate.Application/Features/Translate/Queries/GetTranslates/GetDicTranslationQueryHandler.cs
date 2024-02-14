using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Translate.Application.Contracts.Persistence;
using Translate.Application.Features.Translate.Queries.GetTranslateTables;

namespace Translate.Application.Features.Translate.Queries.GetTranslates
{
    public class GetDicTranslationQueryHandler : IRequestHandler<GetDicTranslationQuery, List<DicTranslationDto>>
    {
        private readonly IMapper _mapper;   
        private readonly IDicTranslationRepository _dicTranslationRepository;   

        public GetDicTranslationQueryHandler(IMapper mapper,IDicTranslationRepository dicTranslationRepository )
        {
            _dicTranslationRepository = dicTranslationRepository;
            _mapper = mapper;   
                
        }
        public async Task<List<DicTranslationDto>> Handle(GetDicTranslationQuery request, CancellationToken cancellationToken)
        {
            var dicTranslation = await _dicTranslationRepository.GetTranslations(request.TableName,request.TableTypeCode
                        ,request.StatusCode,request.PageIndex,request.PageSize);
            if(dicTranslation == null)
            {
                throw new ArgumentNullException();
            }

            return dicTranslation;
        }
    }
}
