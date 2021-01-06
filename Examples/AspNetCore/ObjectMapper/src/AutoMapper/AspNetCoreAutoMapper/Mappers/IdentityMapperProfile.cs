﻿using AspNetCoreAutoMapper.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreAutoMapper.Entities;

namespace AspNetCoreAutoMapper.Mappers
{
    public class IdentityMapperProfile : Profile
    {
        public IdentityMapperProfile()
        {
            // Entity to Model
            CreateMap<User, UserDto>(MemberList.Destination);

            // Model to Entity
            CreateMap<UserDto, User>(MemberList.Source);
        }
    }
}
