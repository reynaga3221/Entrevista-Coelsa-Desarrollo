using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoelsaEntrevista.ContractModels.Requests;
using FluentValidation;

namespace CoelsaEntrevista.WebApi.Validators
{
    public class ContactRequestValidator: AbstractValidator<ContactRequest>
    {
        public ContactRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.FirstName)
             .NotEmpty()
             .NotNull();
        }
    }
}
