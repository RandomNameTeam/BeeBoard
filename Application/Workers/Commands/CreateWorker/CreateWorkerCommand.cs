using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Workers.Commands.CreateWorker
{
    internal class CreateWorkerCommand: IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Description { get; set; }
    }
}
