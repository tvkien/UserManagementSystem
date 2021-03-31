using FluentValidation;

namespace Ums.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("FirstName is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("FirstName must not exceed 50 characters.");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("LastName is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("LastName must not exceed 50 characters.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("Email is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("Email must not exceed 100 characters.")
                .EmailAddress().WithMessage("Email must be correct format.");
        }
    }
}