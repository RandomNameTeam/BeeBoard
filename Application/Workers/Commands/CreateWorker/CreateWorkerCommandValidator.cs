using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Workers.Commands.CreateWorker
{
    internal class CreateWorkerCommandValidator: AbstractValidator<CreateWorkerCommand>
    {
        public CreateWorkerCommandValidator()
        {
           
        }
    }
}
