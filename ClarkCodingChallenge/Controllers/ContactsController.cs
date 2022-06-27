using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClarkCodingChallenge.Models;
using ClarkCodingChallenge.DataAccess;

namespace ClarkCodingChallenge.Controllers
{
    public class ContactsController : Controller
    {
        private IContactsRepository contactRepo;

        public ContactsController(IContactsRepository ContactRepo)
        {
            this.contactRepo = ContactRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexWithJS()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Add(Contact Contact)
        {
            contactRepo.AddContact(Contact);
            return Success();
        }

        public IActionResult Success()
        {
            return View("Success");
        }

        [HttpGet] // using get for easy testing...
        public JsonResult Get(string LastName = "", bool OrderDesc = false)
        {
            var contacts = contactRepo.QueryByLastName(LastName, OrderDesc);
            return Json(contacts);
        }
    }
}
