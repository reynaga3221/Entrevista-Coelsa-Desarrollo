using System;
using System.Collections.Generic;
using System.Text;
using CoelsaEntrevista.Interfaces.Services;
using CoelsaEntrevista.Interfaces.Repositories;
using CoelsaEntrevista.Entities;
using System.Threading.Tasks;

namespace CoelsaEntrevista.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;
        public ContactService(IContactRepository contactRepository)
        {
            _repository = contactRepository;
        }

        public async Task<IEnumerable<Contact>> GetAll(int skip, int take)
        {
            return await _repository.GetAll(skip, take);
        }
        public async Task Create(Contact domain)
        {
            await _repository.Save(domain);
        }

        public async Task Update(Contact domain)
        {
            await _repository.Update(domain);
        }
        public async Task Delete(Guid id)
        {
            await _repository.Delete(id);
        }
    }
}
