using Application.Categories.Queries.GetCategoryList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Queries.GetOrderdList
{
    public class OrderListVm
    {
        public IList<OrderLookupDto> Orders { get; set; }
    }
}
