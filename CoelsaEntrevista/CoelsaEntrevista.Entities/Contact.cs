﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CoelsaEntrevista.Entities
{
    public class Contact
    {
        public Guid IdContact { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public Company Company { get; set; }
    }
}
