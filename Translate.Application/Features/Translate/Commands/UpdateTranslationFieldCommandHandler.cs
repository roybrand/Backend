using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translate.Application.Features.Translate.Commands
{
    public class UpdateTranslationFieldCommandHandler : IRequestHandler<UpdateTranslationFieldCommand, Unit>
    {
        private readonly IMapper _mapper;
        //private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateTranslationFieldCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<Unit> Handle(UpdateTranslationFieldCommand request, CancellationToken cancellationToken)
        {
            return Unit.Task;
        }
    }
}
