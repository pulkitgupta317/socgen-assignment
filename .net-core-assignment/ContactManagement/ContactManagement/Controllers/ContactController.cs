using ContactManagement.Dtos;
using ContactManagement.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ContactManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _contactService.GetAll();
            return Ok(data);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _contactService.GetById(id);
            return Ok(data);
        }

        [HttpPut("UpdateContact")]
        public async Task<IActionResult> UpdateContact(ContactDto contactDto)
        {
            var data = await _contactService.Update(contactDto);
            return Ok(data);
        }

        [HttpPost("CreateContact")]
        public async Task<IActionResult> CreateContact(ContactDto contactDto)
        {
            var data = await _contactService.Create(contactDto);
            return Ok(data);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _contactService.Delete(id);
            return Ok(true);
        }
    }
}
