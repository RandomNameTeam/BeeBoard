using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Commands.ActivateOrder
{
    public class ActivateOrderCommand: IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid WorkderId { get; set; }

    }
}
