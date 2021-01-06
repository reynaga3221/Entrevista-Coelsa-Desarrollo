using AutoMapper;
using CoelsaEntrevista.Entities;
using CoelsaEntrevista.ContractModels.Responses;
using CoelsaEntrevista.ContractModels.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoelsaEntrevista.Mappers.DomainContract
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactReponse>();
            CreateMap<ContactRequest, Contact>()
            .ForMember(dest => dest.Company, opt =>
                opt.MapFrom(src => new Company
                    { 
                        IdCompany = Guid.Parse(src.IdCompany) 
                    }
                ))
            .ForMember(dest => dest.IdContact, opt =>
                opt.MapFrom(m => string.IsNullOrEmpty(m.IdContact) ? Guid.NewGuid() :  Guid.Parse(m.IdContact)));
        }
    }
}
