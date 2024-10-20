using FluentValidation;

namespace Finance.Application.Commands.CategoryAggregate.CreateCategory;
public class CreateCategoryValidation : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("O nome precisa ser preenchido.")
                            .MaximumLength(20).WithMessage("O nome não pode ter mais que 20 caracteres.");

        RuleFor(x => x.Color).NotEmpty().WithMessage("A cor precisa ser preenchido.")
                            .MaximumLength(20).WithMessage("Cor com tamanho errado.");
    }
}
