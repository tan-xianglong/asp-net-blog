using Blog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;

        [TempData]
        public string message { get; set; }

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Message = message;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Contact newContact)
        {
            try
            {
                newContact.CreateDate = DateTime.Now;
                _contactRepository.Add(newContact);
                await _contactRepository.CommitAsync();
                TempData["message"] = "Your request to contact has been submitted.";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to access database.");
            }
            
            //TempData["message"] = "Your request to contact has been submitted.";
        }

        public async Task<IActionResult> List(string searchString)
        {
            try
            {
                var contacts = await _contactRepository.GetContactByNameAsync(searchString);
                ViewBag.Message = message;
                return View(contacts);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int contactId)
        {
            try
            {
                var contact = await _contactRepository.DeleteAsync(contactId);
                await _contactRepository.CommitAsync();
                if (contact == null) return NotFound();
                TempData["message"] = "Contact has been deleted.";
                return RedirectToAction("List");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

    }
}
