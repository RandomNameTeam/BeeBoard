using Application.Common.Expetions;
using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler: IRequestHandler<UpdateOrderCommand, Guid>
    {
        public IUserDbContext _dbContext;

        public UpdateOrderCommandHandler(IUserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _dbContext.Orders.Find(request.Id);

            if (order == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }

            if (request.Title != null)
            {
                order.Title = request.Title;
            }

            if (request.Description != null)
            {
                order.Description = request.Description;
            }

            order.Price = request.Price == null ? order.Price : (int)request.Price;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
