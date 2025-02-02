using Common.Application.Commands;
using Finance.Application.Common.Errors;
using Finance.Application.Common.Interface.Repository;
using Finance.Domain.Aggregates.Reasons;
using Result;

namespace Finance.Application.Business.Reasons.Commands.CreateReason;

public class CreateReasonsHandler : ICommandHandler<CreateReasonCommand, Guid>
{
    private readonly IReasonRepository _reasonRepository;

    public CreateReasonsHandler(IReasonRepository reasonRepository)
    {
        _reasonRepository = reasonRepository;
    }

    public async Task<Result<Guid>> Handle(CreateReasonCommand request, CancellationToken cancellationToken)
    {
        if (await _reasonRepository.ExistsAsync(w => w.Description.Trim().Equals(request.Description.Trim()), cancellationToken))
            return Errors.Reasons.DescriptionExistent;

        Reason reason = new(request.Type, request.Description, request.Color, request.UserId);

        await _reasonRepository.CreateAsync(reason, cancellationToken);
        await _reasonRepository.CommitAsync(cancellationToken);
        
        return reason.Id;
    }
}