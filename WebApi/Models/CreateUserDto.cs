
using Application.Common.Mappings;
using Application.Users.Commands.CreateUser;
using AutoMapper;

namespace WebApi.Models
{
    public class CreateUserDto: IMapWith<CreateUserCommand>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserDto, CreateUserCommand>()
                .ForMember(userCommand => userCommand.Email,
                    opt => opt.MapFrom(userDto => userDto.Email))
                .ForMember(userCommand => userCommand.Password,
                    opt => opt.MapFrom(userDto => userDto.Password));
        }

    }
}
