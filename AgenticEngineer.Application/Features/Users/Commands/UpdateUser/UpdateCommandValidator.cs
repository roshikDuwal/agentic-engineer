using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgenticEngineer.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateCommandValidator:AbstractValidator<UpdateUserCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");


            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email is not vaild.")
                .MaximumLength(255).WithMessage("Email must not exceed 255 characters. ");
        }
    }
}
