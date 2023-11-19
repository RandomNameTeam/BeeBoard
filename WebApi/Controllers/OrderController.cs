using Application.Categories.Queries.GetCategoryList;
using Application.Orders.Queries.GetOrder;
using Application.Orders.Queries.GetOrderdList;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class OrderController: BaseController
    {
        private readonly IMapper _mapper;

        public OrderController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("category")]
        public async Task<ActionResult<OrderListVm>> GetAll(string category)
        {
            var query = new GetOrderListQuery();
            query.CategoryName = category;
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet]
        public async Task<ActionResult<OrderListVm>> GetAll()
        {
            var query = new GetOrderListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("Id")]
        public async Task<ActionResult<OrderDetailsVm>> GetOrder(Guid id)
        {
            var query = new GetOrderDetailsQuery()
            {
                Id = id,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


    }
}
