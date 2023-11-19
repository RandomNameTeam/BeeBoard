using Application.Categories.Queries.GetCategoryList;
using Application.Common.Expetions;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Queries.GetOrderdList
{
    public class GetOrderListQueryHandler: IRequestHandler<GetOrderListQuery, OrderListVm>
    {
        private IOrderDbContext _dbContext;
        private ICategoryDbContext _categoryDbContext;
        private IMapper _mapper;
        
        public GetOrderListQueryHandler(IOrderDbContext dbContext, ICategoryDbContext categoryDbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _categoryDbContext = categoryDbContext;
            _mapper = mapper;
        }

        public async Task<OrderListVm> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var category = _categoryDbContext.Categories.Find(request.CategoryName);
            if (category == null)
            {
                throw new NotFoundException(nameof(Category), request.CategoryName);
            }

            var orders = await _dbContext.Orders.Where(order => order.categories.Contains(category))
                .ProjectTo<OrderLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if (request.CategoryName == null)
            {
                orders = await _dbContext.Orders
               .ProjectTo<OrderLookupDto>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
            }

            return new OrderListVm { Orders = orders };
        }
    }
}
