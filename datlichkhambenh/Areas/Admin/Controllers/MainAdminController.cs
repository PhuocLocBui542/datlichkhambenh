using datlichkhambenh.Models;
using datlichkhambenh.Services;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace datlichkhambenh.Areas.Admin.Controllers
{
	[Area("admin")]
	[Route("admin/mainadmin")]
	public class MainAdminController : Controller
	{
		private DepartmentService departmentService;
		private DoctorService doctorService;
        private ExaminationscheduleService examinationscheduleService;
        private PatientService patientService;

		public MainAdminController(DepartmentService _departmentService, DoctorService _doctorService, ExaminationscheduleService _examinationscheduleService, PatientService _patientService)
		{
			departmentService = _departmentService;
			doctorService = _doctorService;
            examinationscheduleService = _examinationscheduleService;
            patientService = _patientService;
		}

		[Route("index")]
		    [Route("")]/*
            [Route("~/")]*/
        public IActionResult Index()
		{
			ViewBag.khoas = departmentService.findAll();
			ViewBag.bacsis = doctorService.findAll();
			return View();
		}

		[HttpGet]
        [Route("addbs")]
        public IActionResult Addbs()
        {
			var khoa = new Khoa();
            return View("Addbs", khoa);
        }

        [HttpPost]
        [Route("addbs")]
        public IActionResult Addbs(Khoa khoa)
        {
            if (departmentService.Create(khoa))
            {
                TempData["Msg"] = "Success";
            }
            else
            {
                TempData["Msg"] = "Failed";
            }
            return RedirectToAction("index");
        }

        [Route("deletebs/{makhoa}")]
        public IActionResult Deletebs(int makhoa)
        {
            if (departmentService.Delete(makhoa))
            {
                TempData["Msg"] = "Success";
            }
            else
            {
                TempData["Msg"] = "Failed";
            }
            return RedirectToAction("index");
        }

        [HttpGet]
        [Route("editbs/{makhoa}")]
        public IActionResult Editbs(int makhoa)
        {
            var khoa = departmentService.findById(makhoa);
            return View("Editbs", khoa);
        }

        [HttpPost]
        [Route("editbs/{makhoa}")]
        public IActionResult Editbs(int makhoa, Khoa khoa)
        {
            if (departmentService.Update(khoa))
            {
                TempData["Msg"] = "Success";
            }
            else
            {
                TempData["Msg"] = "Failed";
            }
            return RedirectToAction("index");
        }



        [HttpGet]
        [Route("adddt")]
        public IActionResult Adddt()
        {
            var bacsi = new Bacsi();
            ViewBag.khoas = departmentService.findAll();
            return View("Adddt", bacsi);
        }

        [HttpPost]
        [Route("adddt")]
        public IActionResult Adddt(Bacsi bacsi)
        {
            if (doctorService.Create(bacsi))
            {
                TempData["Msg"] = "Success";
            }
            else
            {
                TempData["Msg"] = "Failed";
            }
            return RedirectToAction("index");
        }

        [Route("deletedt/{mabs}")]
        public IActionResult Deletedt(int mabs)
        {
            if (doctorService.Delete(mabs))
            {
                TempData["Msg"] = "Success";
            }
            else
            {
                TempData["Msg"] = "Failed";
            }
            return RedirectToAction("index");
        }
        [HttpGet]
        [Route("editdt/{mabs}")]
        public IActionResult Editdt(int mabs)
        {
            var bacsi = doctorService.findById(mabs);
            ViewBag.khoas = departmentService.findAll();
            return View("Editdt", bacsi);
        }

        [HttpPost]
        [Route("editdt/{mabs}")]
        public IActionResult Editdt(int mabs, Bacsi bacsi)
        {
            if (doctorService.Update(bacsi))
            {
                TempData["Msg"] = "Success";
            }
            else
            {
                TempData["Msg"] = "Failed";
            }
            return RedirectToAction("index");
        }

        [Route("details/{mabs}")]
        public IActionResult Details(int mabs)
        {
            ViewBag.bacsi = doctorService.findById(mabs);
            return View("DetailsH");
        }

        [Route("patient")]
        public IActionResult Patient()
        {
            ViewBag.benhnhans = patientService.findAll();
            return View("Patient");
        } 

        [Route("patienthis/{mabn}")]
        public IActionResult Patienthis(int mabn)
        {
            ViewBag.lichkhams = examinationscheduleService.findById(mabn);
            return View("Patienthis");
        }

        [Route("search")]
        public IActionResult Search(string from, string to)
        {
            ViewBag.lichkhams = examinationscheduleService.findAll();
            var start = DateTime.ParseExact(from, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var end = DateTime.ParseExact(to, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            ViewBag.lichkhams = examinationscheduleService.findByDate(start, end);
            ViewBag.from = from;
            ViewBag.to = to;
            return View("search");
        }
    }
}
