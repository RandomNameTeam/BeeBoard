using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserList
{
    internal class GetUserListQueryHandler
        : IRequestHandler<GetUserListQuery, UserLIstVm>
    {
        private readonly IUserDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserListQueryHandler(IUserDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }   

        public async Task<UserLIstVm> Handle(GetUserListQuery request,
            CancellationToken cancellationToken)
        {
            var usersQuery = await _dbContext.Users
                .ProjectTo<UserLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new UserLIstVm { Users = usersQuery };
        }
    }
}
