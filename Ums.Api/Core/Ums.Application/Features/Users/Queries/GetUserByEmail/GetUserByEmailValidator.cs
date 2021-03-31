using FluentValidation;

namespace Ums.Application.Features.Users.Queries.GetUserByEmail
{
    public class GetUserByEmailValidator : AbstractValidator<GetUserByEmailQuery>
    {
        public GetUserByEmailValidator()
        {
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("Email is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("Email must not exceed 100 characters.")
                .EmailAddress().WithMessage("Email must be correct format.");
        }
    }
}