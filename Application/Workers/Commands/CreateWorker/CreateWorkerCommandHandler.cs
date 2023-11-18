using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Workers.Commands.CreateWorker
{
    internal class CreateWorkerCommandHandler : IRequestHandler<CreateWorkerCommand, Guid>
    {
        private readonly IWorkerDbContext _dbContext;
        private readonly IUserDbContext _userDbContext;

        public CreateWorkerCommandHandler(IWorkerDbContext dbContext) { _dbContext = dbContext; }

        public async Task<Guid> Handle(CreateWorkerCommand request, CancellationToken cancellationToken)
        {
            var user = await _userDbContext.Users
                .FirstAsync(user => user.Id == request.UserId, cancellationToken);

            var worker = new Worker
            {
                User = user,
                Description = request.Description
            };

            await _dbContext.Workers.AddAsync(worker, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return worker.Id;
        }
    }
}
