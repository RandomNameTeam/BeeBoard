using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser
{
    internal class CreateUserCommandValidator: AbstractValidator<CreateUserCommand> 
    {
        public CreateUserCommandValidator()
        {
            RuleFor(createUserCommand =>
                createUserCommand.Email).NotEmpty().EmailAddress();
            RuleFor(createUserCommand =>
                createUserCommand.Name).NotEmpty().MaximumLength(255);
            RuleFor(createUserCommand =>
                createUserCommand.LastName).NotEmpty().MaximumLength(255);
            RuleFor(createUserCommand =>
                createUserCommand.TelephoneNumber).NotEmpty().MaximumLength(255);
        }
    }
}
