using FluentValidation;

namespace Identity.Api.Requests;

public record RegisterUserRequest(string Name, string Email, string Password, string ConfirmationPassword);

public class RegisterUserRequestValidation : AbstractValidator<RegisterUserRequest>
{
    public RegisterUserRequestValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome precisa ser informado")
            .MaximumLength(255).WithMessage("Nome pode ter no máximo 255 caracteres")
            .MinimumLength(3).WithMessage("Nome deve ter no mínimo 3 caracteres")
            .WithName("Nome");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("E-mail precisa ser informada")
            .MaximumLength(320).WithMessage("E-mail pode ter no máximo 255 caracteres")
            .EmailAddress().WithMessage("E-mail não é válido")
            .WithName("E-mail");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Senha precisa ser informada")
            .MinimumLength(8).WithMessage("Senha deve ter no mínimo 8 caracteres")
            .WithName("Senha");
        

        RuleFor(x => x.ConfirmationPassword)
            .NotEmpty().WithMessage("Confirmação de senha precisa ser informada")
            .MinimumLength(8).WithMessage("Confirmação de senha deve ter no mínimo 8 caracteres")
            .Equal(x => x.Password).WithMessage("As senhas devem ser iguais")
            .WithName("Confirmação de senha");

    }
}