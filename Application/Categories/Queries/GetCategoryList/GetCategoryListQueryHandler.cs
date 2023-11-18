using Application.Interfaces;
using Application.Users.Queries.GetUserList;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, CategoryListVm>
    {
        private readonly ICategoryDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCategoryListQueryHandler(ICategoryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CategoryListVm> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categoriesQuery = await _dbContext.Categories
                .ProjectTo<CategoryLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new CategoryListVm { Categories = categoriesQuery };
        }
    }
}
