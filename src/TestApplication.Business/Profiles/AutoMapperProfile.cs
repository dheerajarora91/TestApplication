using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TestApplication.Business.Models;
using TestApplication.Data.Entities;

namespace TestApplication.Business.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PaymentRequest, Payment>();
            //CreateMap<Payment, PaymentRequest>().IncludeMembers(c=>c.PaymentState)
            //    .ForMember(c=>c.PaymentState,opt=>opt.MapFrom(c=>c.PaymentState.State));
        }
    }
}
