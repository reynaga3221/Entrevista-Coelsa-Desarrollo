using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoelsaEntrevista.Interfaces.Services;
using CoelsaEntrevista.ContractModels.Requests;
using CoelsaEntrevista.Entities;
using CoelsaEntrevista.ContractModels.Responses;

namespace CoelsaEntrevista.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IContactService _contactService;

        public ContactController(IMapper mapper, IContactService contactService)
        {
            _mapper = mapper;
            _contactService = contactService;
        }

        [HttpGet("{skip}/{take}")]
        public async Task <IActionResult> Get( int skip = 0, int take = 10)
        {            
            var response = _mapper.Map<IEnumerable<ContactReponse>>( await _contactService.GetAll(skip, take));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContactRequest contactRequest)
        {       
                var domain = _mapper.Map<Contact>(contactRequest);
                await _contactService.Create(domain);
                return Created("/Loan/" + domain.IdContact, contactRequest);          
        }

        [HttpPut]     
        public async Task<IActionResult> Put([FromBody] ContactRequest contactRequest)
        {
            var domainUser = _mapper.Map<Contact>(contactRequest);
            await _contactService.Update(domainUser);
            return Ok(contactRequest);
        }

        [HttpDelete("{id}")]       
        public async Task<IActionResult> Delete(string id)
        {
            await _contactService.Delete(Guid.Parse(id));
            return Ok();
        }
    }
}
