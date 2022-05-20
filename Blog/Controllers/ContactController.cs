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
            //ViewBag.Message = message;
            return View();
        }

        /*[HttpPost]
        public async Task<IActionResult> Index(Contact newContact)
        {
            try
            {
                _contactRepository.Add(newContact);
                if (await _contactRepository.Commit())
                {
                    ViewBag.Message = "Your request to contact has been submitted.";
                    return View();

                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Unable to access database.");
            }
            return BadRequest();
            
            //TempData["message"] = "Your request to contact has been submitted.";
        }*/

    }
}
