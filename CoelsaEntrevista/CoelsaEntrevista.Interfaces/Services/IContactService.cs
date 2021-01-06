using CoelsaEntrevista.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoelsaEntrevista.Interfaces.Services
{
    public interface IContactService
    {        
        Task<IEnumerable<Contact>> GetAll(int skip, int take);
        Task Update(Contact domain);
        Task Create(Contact domain);
        Task Delete(Guid id);
    }
}
