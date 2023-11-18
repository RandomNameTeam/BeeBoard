using Application.Users.Queries.GetUserList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Queries.GetCategoryList
{
    public class CategoryListVm
    {
        public IList<CategoryLookupDto> Categories { get; set; }
    }
}
