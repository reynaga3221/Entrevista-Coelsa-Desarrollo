using AutoMapper;
using CoelsaEntrevista.ContractModels.Responses;
using CoelsaEntrevista.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoelsaEntrevista.Mappers.DomainContract
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyResponse>();
        }
    }
}
