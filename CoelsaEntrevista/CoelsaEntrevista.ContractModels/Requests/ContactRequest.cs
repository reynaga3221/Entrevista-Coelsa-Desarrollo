using System;
using System.Collections.Generic;
using System.Text;

namespace CoelsaEntrevista.ContractModels.Requests
{
    public class ContactRequest
    {
        public string IdContact { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string IdCompany { get; set; }
    }
}
