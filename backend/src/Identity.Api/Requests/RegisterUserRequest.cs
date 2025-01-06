using FluentValidation;

namespace Identity.Api.Requests;

public record RegisterUserRequest(string Name, string Email, string Password, string ConfirmationPassword);

public class RegisterUserRequestValidation : AbstractValidator<RegisterUserRequest>
{
    public RegisterUserRequestValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name must be specified.")
            .MaximumLength(16).WithMessage("Name must have maximum 255 characters.")
            .MinimumLength(3).WithMessage("Name must have at least 3 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("E-mail must be specified.")
            .MaximumLength(320).WithMessage("E-mail must have maximum 320 characters.")
            .EmailAddress().WithMessage("Not a valid e-mail.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password must be specified.")
            .MinimumLength(8).WithMessage("Password must have at least 8 characters");
        

        RuleFor(x => x.ConfirmationPassword)
            .NotEmpty().WithMessage("Confirmation Password must be specified.")
            .MinimumLength(8).WithMessage("Confirmation Password must have at least 8 characters")
            .Equal(x => x.Password).WithMessage("Confirmation Password must be equals Password");

    }
}