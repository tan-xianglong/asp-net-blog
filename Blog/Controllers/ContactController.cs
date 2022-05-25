using Blog.Models;
using Blog.Models.ViewModels.Contacts;
using Blog.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        private readonly IContactServices _contactServices;

        [TempData]
        public string Message { get; set; }

        public ContactController(IContactRepository contactRepository, IContactServices contactServices)
        {
            _contactRepository = contactRepository;
            _contactServices = contactServices;
        }

        public IActionResult Index()
        {
            return View(new ContactViewModel
            {
                TempMessage = Message
            });
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactViewModel newContact)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(newContact);
                }
                var msg = await _contactServices.SaveContactAsync(newContact);
                TempData["message"] = msg;
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to access database.");
            }            
        }

        [Authorize]
        public async Task<IActionResult> List(string searchString)
        {
            try
            {
                var contacts = await _contactServices.GetContactListAsync(searchString);
                contacts.TempMessage = Message;
                return View(contacts);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(int contactId)
        {
            try
            {
                var msg = await _contactServices.DeleteContactAsync(contactId);
                TempData["message"] = msg;
                return RedirectToAction("List");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

    }
}
