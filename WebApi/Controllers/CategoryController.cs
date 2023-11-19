using Application.Categories.Queries.GetCategoryList;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class CategoryController: BaseController
    {
        private readonly IMapper _mapper;

        public CategoryController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CategoryListVm>> GetAll()
        {
            var query = new GetCategoryListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
