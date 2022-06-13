using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAPI.Services;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactServicesWebApi _contactServices;

        public ContactController(IContactServicesWebApi contactServices)
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

        [HttpPost]
        public async Task<ActionResult<string>> Post(ContactViewModel newContact)
        {
            try
            {
                var msg = await _contactServices.SaveContactAsync(newContact);
                return Ok(msg);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpDelete("delete/{contactId}")]
        public async Task<ActionResult<string>> Delete(int contactId)
        {
            try
            {
                var msg = await _contactServices.DeleteContactAsync(contactId);
                return Ok(msg);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}
