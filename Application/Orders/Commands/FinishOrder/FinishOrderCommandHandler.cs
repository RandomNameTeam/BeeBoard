using Application.Common.Expetions;
using Application.Interfaces;
using Application.Orders.Commands.CreateOrder;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Commands.FinishOrder
{
    public class FinishOrderCommandHandler : IRequestHandler<FinishOrderCommand, Guid>
    {
        public IUserDbContext _dbContext;

        public FinishOrderCommandHandler(IUserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(FinishOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _dbContext.Orders.Find(request.Id);
            if (order == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }

            if (order.State != "In Progress")
            {
                throw new Exception("Error order is not prepared for finished");
            }

            order.Worker.User.Balance += order.Price;
            order.State = "Sucsess";

            await _dbContext.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
