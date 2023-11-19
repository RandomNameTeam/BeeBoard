using Application.Interfaces;
using Application.Users.Commands.CreateUser;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderDbContext _dbContext;
        private readonly IUserDbContext _userDbContext;
        private readonly IWorkerDbContext _workerDbContext;

        public CreateOrderCommandHandler(IOrderDbContext dbContext,
                                         IWorkerDbContext workerDbContext,
                                         IUserDbContext userDbContext)
        {
            _dbContext = dbContext;
            _userDbContext = userDbContext;
            _workerDbContext = workerDbContext;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var worker = _workerDbContext.Workers.Find(request.WorkerId);
            var customer = _userDbContext.Users.Find(request.CustomerId);

            if (worker == null && customer == null)
            {
                throw new Exception("Not Valid data for create order");
            }

            var Order = new Order
            {
                Worker = worker,
                Customer = customer,
                Title = request.Title,
                Description = request.Description,
                Price = request.Price,
                State = "Searching"
            };

            await _dbContext.Orders.AddAsync(Order, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Order.Id;
        }
    }
}
