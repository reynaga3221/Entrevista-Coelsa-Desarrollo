using CoelsaEntrevista.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoelsaEntrevista.Interfaces.Repositories
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetAll();
    }
}
