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
        }
    }
}
