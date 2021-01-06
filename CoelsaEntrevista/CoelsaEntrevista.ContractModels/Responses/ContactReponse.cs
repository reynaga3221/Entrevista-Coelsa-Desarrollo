using System;
using System.Collections.Generic;
using System.Text;

namespace CoelsaEntrevista.ContractModels.Responses
{
    public class ContactReponse
    {
        public Guid IdContact { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public CompanyResponse Company { get; set; }
    }
}
