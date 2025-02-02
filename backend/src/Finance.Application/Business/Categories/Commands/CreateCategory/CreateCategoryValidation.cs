using Common.Application.Validations;
using FluentValidation;
using Result;

namespace Finance.Application.Business.Categories.Commands.CreateCategory;

public class CreateCategoryValidation : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidation()
    {
        RuleFor(r => r.Type)
            .IsInEnum().WithResultError("Tipo de categoria inválido", "O tipo da categoria é inválido.");
        
        RuleFor(r => r.Description)
            .NotEmpty().WithResultError("Descrição", "A descrição deve ser preenchida");

        RuleFor(r => r.Color)
            .NotEmpty().WithResultError("Cor", "A cor deve ser preenchida")
            .Must(x => x.Contains("#")).WithResultError("Cor", "Cor informada não é válida");

        RuleFor(r => r.UserId)
            .NotEmpty().WithResultError("Usuário", "Usuário não identificado");
    }
}