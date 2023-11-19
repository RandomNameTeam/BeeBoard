using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Queries.GetOrderdList
{
    public class GetOrderListQuery: IRequest<OrderListVm>
    {
        public string CategoryName { get; set; }
    }
}
