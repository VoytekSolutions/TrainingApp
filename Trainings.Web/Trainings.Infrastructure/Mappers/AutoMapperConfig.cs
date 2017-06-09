using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Trainings.Core.Domain;
using Trainings.Infrastructure.DTO;

namespace Trainings.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<User, UserDTO>();
                    cfg.CreateMap<Gym, GymDTO>();
                }).CreateMapper();
    }
}
