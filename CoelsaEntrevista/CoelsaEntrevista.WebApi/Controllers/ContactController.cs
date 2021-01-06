using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoelsaEntrevista.Interfaces.Services;
using CoelsaEntrevista.ContractModels.Requests;
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
        public IActionResult Get( int skip = 0, int take = 10)
        {
            var pepe = _contactService.GetAll().ToList();
            var response = _mapper.Map<IEnumerable<ContactReponse>>(_contactService.GetAllPagination(skip, take));
            return Ok(response);
        }
    }
}
