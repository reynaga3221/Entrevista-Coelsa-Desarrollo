using System;
using System.Collections.Generic;
using System.Text;
using CoelsaEntrevista.Interfaces.Services;
using CoelsaEntrevista.Interfaces.Repositories;
using CoelsaEntrevista.Entities;

namespace CoelsaEntrevista.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;
        public ContactService(IContactRepository contactRepository)
        {
            _repository = contactRepository;
        }

        public IEnumerable<Contact> GetAll()
        {
            return _repository.GetAll();
        }
        public IEnumerable<Contact> GetAllPagination(int skip, int take)
        {
            return _repository.GetAllPagination(skip, take);
        }
    }
}
