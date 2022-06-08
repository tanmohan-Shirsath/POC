using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using VirtualTrading.Model;

namespace VirtualTrading.DAL.Models
{
    public class UserProfile : Profile
    {
        public UserProfile() =>
            this.CreateMap<AspNetUser, UserModel>();
    }
}
