using Application.Common.Expetions;
using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Workers.Commands.UpdateWorker
{
    internal class UpdateWorkerCommandHandler: IRequestHandler<UpdateWorkerCommand, Guid>
    {
        public IUserDbContext _dbContext;

        public UpdateWorkerCommandHandler(IUserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(UpdateWorkerCommand request, CancellationToken cancellationToken)
        {
            var worker = _dbContext.Workers.Find(request.Id);

            if (worker == null)
            {
                throw new NotFoundException(nameof(Worker), request.Id);
            }

            worker.Description = request.Description;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return worker.Id;
        }
    }
}
