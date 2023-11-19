using Application.Common.Expetions;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Queries.GetOrder
{
    public class GetOrderDetailsQueryHandler: IRequestHandler<GetOrderDetailsQuery, OrderDetailsVm>
    {
        private IUserDbContext _dbContext;
        private IMapper _mapper;

        public GetOrderDetailsQueryHandler(IUserDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<OrderDetailsVm> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders.FindAsync(request.Id);
            if (order == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }

            return _mapper.Map<OrderDetailsVm>(order);
        }
    }
}
