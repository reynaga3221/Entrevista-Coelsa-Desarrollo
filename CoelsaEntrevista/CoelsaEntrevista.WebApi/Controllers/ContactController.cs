using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoelsaEntrevista.Interfaces.Services;

namespace CoelsaEntrevista.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }


        [HttpGet]       
        public IActionResult Get()
        {
            var response = _contactService.GetAll().ToList();
            return Ok(response);
        }
    }
}
