using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Workers.Commands.UpdateWorker
{
    internal class UpdateWorkerCommand: IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}
