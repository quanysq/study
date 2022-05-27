using AutoMapper;
using AutoMapperExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMapperExample.AutoMapperConfig
{
    public class SampleProfile: Profile
    {
        public SampleProfile()
        {
            CreateMap<UserModel, UserViewModel>();
        }
    }
}