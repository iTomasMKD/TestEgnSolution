using EgnApp.Contract;
using EgnApp.Models;
using EgnApp.Validation;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EgnApp.Controllers
{
    public class EgnController : Controller
    {
        private readonly IEgnRepository _repo;
        private readonly EgnNumberValidation _validation;

        public EgnController(IEgnRepository repo)
        {
            _repo = repo;
            _validation = new EgnNumberValidation();
        }

        public IActionResult Index()
        {
            var egns = _repo.GetAll();
            return View(egns);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,EgnNumber,Age")] Egn egn)
        {
            if (!ModelState.IsValid)
            {
                return View(egn);
            }

            if (!_validation.IsValid(egn.EgnNumber))
            {
                ModelState.AddModelError("EgnNumber", " Number is invalid");
                return View(egn);
            }

            _repo.CreateEgn(egn);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
