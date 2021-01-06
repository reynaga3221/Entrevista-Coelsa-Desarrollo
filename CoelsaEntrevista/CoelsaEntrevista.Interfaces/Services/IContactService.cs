using CoelsaEntrevista.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoelsaEntrevista.Interfaces.Services
{
    public interface IContactService
    {
        IEnumerable<Contact> GetAll();
    }
}
