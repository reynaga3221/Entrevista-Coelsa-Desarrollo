using System;
using System.Collections.Generic;
using System.Text;

namespace CoelsaEntrevista.Entities.Exceptions
{
    public class BusinessException : Exception
    {

        public string AditionalMessage { get; set; }

        public BusinessException(string msg) : base(msg) { }

        public BusinessException(string msg, string aditionalMessage) : base(msg)
        {
            this.AditionalMessage = aditionalMessage;
        }

    }
}
