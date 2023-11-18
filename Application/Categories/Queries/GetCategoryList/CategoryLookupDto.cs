using Application.Common.Mappings;
using Application.Users.Queries.GetUserList;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Queries.GetCategoryList
{
    public class CategoryLookupDto: IMapWith<Category>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryLookupDto>()
                .ForMember(categoryDto => categoryDto.Name,
                    otp => otp.MapFrom(category => category.Name));
        }
    }
}
