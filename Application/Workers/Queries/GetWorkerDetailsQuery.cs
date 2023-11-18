using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Workers.Queries
{
    internal class GetWorkerDetailsQuery: IRequest<WorkerDetailsVm>
    {
        public string UserId { get; set; }
    }
}
