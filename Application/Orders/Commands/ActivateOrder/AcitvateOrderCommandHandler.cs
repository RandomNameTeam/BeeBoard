using Application.Common.Expetions;
using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Commands.ActivateOrder
{
    public class AcitvateOrderCommandHandler : IRequestHandler<ActivateOrderCommand, Guid>
    {
        public IUserDbContext _dbContext;

        public AcitvateOrderCommandHandler(IUserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(ActivateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _dbContext.Orders.Find(request.Id);
            if (order == null)
            {
                throw new  NotFoundException(nameof(Order), request.Id);
            }

            var customer = _dbContext.Users.Find(request.CustomerId);
            if(customer == null)
            {
                throw new NotFoundException(nameof(User), request.CustomerId);
            }

            var worker = _dbContext.Workers.Find(request.WorkderId);
            if (worker == null)
            {
                throw new NotFoundException(nameof(Worker), request.WorkderId);
            }

            customer.Balance -= order.Price;
            order.Customer = customer;
            order.Worker = worker;
            order.State = "In process";

            await _dbContext.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
