using Application.Common.Mappings;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserList
{
    public class UserLookupDto: IMapWith<User>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserLookupDto>()
                .ForMember(userDto => userDto.Id,
                    otp => otp.MapFrom(user => user.Id))
                .ForMember(userDto => userDto.Email,
                    otp => otp.MapFrom(user => user.Email))
                .ForMember(userDto => userDto.Name,
                    otp => otp.MapFrom(user => user.Name))
                .ForMember(userDto => userDto.LastName,
                    otp => otp.MapFrom(user => user.LastName));

        }
    }
}
