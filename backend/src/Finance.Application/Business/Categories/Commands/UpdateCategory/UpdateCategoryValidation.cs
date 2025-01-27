using Common.Application.Validations;
using FluentValidation;

namespace Finance.Application.Business.Categories.Commands.UpdateCategory;

public class UpdateCategoryValidation : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryValidation()
    {
        RuleFor(r => r.Description)
            .NotEmpty().WithResultError("Descrição", "A descrição deve ser preenchida");

        RuleFor(r => r.Color)
            .NotEmpty().WithResultError("Cor", "A cor deve ser preenchida")
            .Must(x => x.Contains("#")).WithResultError("Cor", "Cor informada não é válida");

        RuleFor(r => r.UserId)
            .NotEmpty().WithResultError("Usuário", "Usuário não identificado");
    }
}