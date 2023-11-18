using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserDetails
{
    internal class GetUserDetailsQueryValidator: AbstractValidator<GetUserDetailsQuery>
    {

        public GetUserDetailsQueryValidator() 
        {
            RuleFor(user => user.Id).NotEqual(Guid.Empty);
        }
    }
}
