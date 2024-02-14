using MediatR;

namespace Translate.Application.Features.Translate.Commands;

public class UpdateTranslationFieldCommand : IRequest<Unit>
{
    public string TableName { get; set; }
    public int TableCode { get; set; }
    public string Translate { get; set; }
    public string Timestamp { get; set; }
}
