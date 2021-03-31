using AutoMapper;
using Ums.Application.Features.Users.Commands.CreateUser;
using Ums.Application.Features.Users.Queries.GetDataUsersToExport.Response;
using Ums.Domain.Entities;

namespace Ums.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<User, UserExport>();
        }
    }
}