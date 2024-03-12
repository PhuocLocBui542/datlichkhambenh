using datlichkhambenh.Models;
using datlichkhambenh.Services;
using Microsoft.AspNetCore.Mvc;

namespace datlichkhambenh.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private DepartmentService departmentService;
        private PatientService patientService;
        private DoctorService doctorService;
        private ExaminationscheduleService examinationscheduleService;

        public HomeController(DepartmentService _departmentService, PatientService _patientService, DoctorService _doctorService, ExaminationscheduleService _examinationscheduleService)
        {
            patientService = _patientService;
            departmentService = _departmentService;
            doctorService = _doctorService;
            examinationscheduleService = _examinationscheduleService;
        }

        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.username = HttpContext.Session.GetString("username");
            ViewBag.khoas = departmentService.findAll();
            return View();
        }

        [Route("detailsid/{makhoa}")]
        public IActionResult Detailsid(int makhoa)
        {
            ViewBag.khoa = departmentService.findById(makhoa);
            return View("Details");
        }

        [Route("search")]
        public IActionResult Search()
        {
            ViewBag.benhnhans = patientService.findAll();
            return View("search");
        }
        
        [Route("searchbn")]
        public IActionResult Searchbn(int mabn)
        {
            ViewBag.benhnhans = patientService.findById(mabn);
            ViewBag.mabn = mabn;
            return View("searchbn");
        }

        [HttpPost]
        public IActionResult Search(int mabn)
        {
            var benhnhans = patientService.findById(mabn);
            if (benhnhans == null)
            {
                ViewBag.Message = "Không tìm thấy";
                return View("Index");
            }
            return View("Search", benhnhans);
        }

        [HttpGet]
        [Route("login")]
        [Route("")]
        [Route("~/")]
        public IActionResult Login()
        {
            return View("login");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string username, string password)
        {

            if (patientService.Login(username, password))
            {
                HttpContext.Session.SetString("username", username);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Msg"] = "Failed";
                return RedirectToAction("login");
            }
        }

        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            var benhnhan = new Benhnhan();
            return View("Register", benhnhan);
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(Benhnhan benhnhan)
        {
            /*account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);*/
            if (patientService.Create(benhnhan))
            {
                TempData["Msg"] = "Success";
                return RedirectToAction("login");
            }
            else
            {
                TempData["Msg"] = "Failed";
                return RedirectToAction("register");
            }
        }

        [Route("res")]
        public IActionResult Res()
        {
            ViewBag.username = HttpContext.Session.GetString("username");
			ViewBag.bacsis = doctorService.findAll();
            return View("Res");
        }

        [HttpPost]
		[Route("info")]
		public IActionResult Info()
		{
			ViewBag.username = HttpContext.Session.GetString("username");
			return View("Info");
		}
	}
}
