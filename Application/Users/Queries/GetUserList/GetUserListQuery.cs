﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserList
{
    public class GetUserListQuery: IRequest<UserLIstVm>
    {
        public Guid UserId { get; set; }

    }
}
