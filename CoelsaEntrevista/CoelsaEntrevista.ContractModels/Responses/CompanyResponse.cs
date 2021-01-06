using System;
using System.Collections.Generic;
using System.Text;

namespace CoelsaEntrevista.ContractModels.Responses
{
    public class CompanyResponse
    {
        public Guid IdCompany { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int PhoneCompany { get; set; }
    }
}
