using FluentValidation;

namespace Finance.Application.Business.CategoryAggregate.Commands.CreateCategory;
public class CreateCategoryValidation : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("O nome precisa ser preenchido.")
                            .MaximumLength(20).WithMessage("O nome não pode ter mais que 20 caracteres.");

        RuleFor(x => x.Color).NotEmpty().WithMessage("A cor precisa ser preenchido.")
                             .MinimumLength(3).WithMessage("O tamanho mínimo para o hexadecimal da cor é 3")
                             .MaximumLength(6).WithMessage("O tamanho máximo para o hexadecimal da cor é 6");
    }
}
