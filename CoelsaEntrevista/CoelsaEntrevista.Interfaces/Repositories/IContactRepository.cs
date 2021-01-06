using CoelsaEntrevista.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoelsaEntrevista.Interfaces.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAll(int skip, int take);
        Task Update(Contact domain);
        Task Save(Contact domain);
        Task Delete(Guid id);
    }
}
