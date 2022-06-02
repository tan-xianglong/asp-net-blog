using Blog.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactServices _contactServices;

        public ContactController(IContactServices contactServices)
        {
            _contactServices = contactServices;
        }

        [HttpGet("list/{searchString}")]
        [HttpGet("list")]
        public async Task<ActionResult<ContactListViewModel>> GetList(string searchString = null)
        {
            try
            {
                var contacts = await _contactServices.GetContactListAsync(searchString);

                if(contacts == null) return NotFound();
                return Ok(contacts);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}
