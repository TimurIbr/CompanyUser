using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CompanyUser.Models;

namespace CompanyUser.Controllers
{
    public class HomeController : Controller
    {
        private CompanyContext db;
        public HomeController(CompanyContext context)
        {
            db = context;
        }

        public string Hello()
        {
            return "Hello!";
        }

        //[HttpPost]
        public JsonResult CreateUser(string userName = "", string  companyName = "")
        {
            if(userName == "" || companyName == "")
            {
                return Json(BadRequest("Request requiers userName and companyName to be defined"));
            }
            Company company = db.Companies.FirstOrDefault(p => p.Name == companyName);
            if (company != null)
            {
                /*var userId = 1 + db.Users.Max(p => p.Id);
                var newUser = new User { Name = userName, CompanyId = company.Id };*/
                var newUser = new User { Name = userName, CompanyId = company.Id };
                db.Users.Add(newUser);
                db.SaveChangesAsync();
                return Json(newUser);
            }
            return Json(NotFound("No such company"));
        }
        [HttpGet]
        public JsonResult GetUser(int? id)
        {
            if (id == null)
                return Json(BadRequest("Request requiers id to be defined"));
            var user = db.Users.FirstOrDefault(p => p.Id == id);
            if(user != null)
                return Json(user);
            return Json(NotFound("No such user"));
        }
        public JsonResult GetUserJson(int? id)
        {
            if (id == null)
                return Json(BadRequest("Request requiers id to be defined"));
            var user = db.Users.FirstOrDefault(p => p.Id == id);
            if (user == null)
                return Json(NotFound("No such user"));
            var company = db.Companies.FirstOrDefault(p => p.Id == user.CompanyId);
            if(company == null)
            {
                return Json(user);
            }
            var userJson = new UserJson{};
            userJson.Initialize(user, company);

            return Json(userJson);
        }

        [HttpGet]
        public JsonResult GetUsers()
        {
            var users = db.Users.ToList();
            return Json(users);
        }
        //[HttpPost]
        public JsonResult EditUser(string userName = "" , string newUserName = "")
        {
            if (userName == "" || newUserName == "")
                return Json(BadRequest("Request requiers userName and newUserName to be defined"));
            var user = db.Companies.FirstOrDefault(p => p.Name == userName);
            if (user == null)
                return Json(NotFound("No such users"));
            if (db.Companies.FirstOrDefault(p => p.Name == newUserName) != null)
            {
                return Json(BadRequest("Such user already exists"));
            }
            user.Name = newUserName;
            db.Companies.Update(user);
            db.SaveChangesAsync();
            return Json(user);
        }

        //[HttpPost]
        public JsonResult CreateCompany(string companyName = "")
        {
            if(companyName == "")
                return Json(BadRequest("Request requiers companyName to be defined"));
            var newCompany = new Company {Name = companyName };
            db.Companies.Add(newCompany);
            db.SaveChanges();
            return Json(newCompany);
        }
        //[HttpPost]
        public JsonResult EditCompany(string companyName = "", string newCompanyName = "")
        {
            if(companyName == "" || newCompanyName == "" )
                return Json(BadRequest("Request requiers companyName and newCompanyName to be defined"));
            var company = db.Companies.FirstOrDefault(p => p.Name == companyName);
            if (company == null)
                return Json( NotFound("No such companies"));
            if(db.Companies.FirstOrDefault(p => p.Name == newCompanyName) != null)
            {
                return Json(BadRequest("Such company already exists"));
            }
            company.Name = newCompanyName;
            db.Companies.Update(company);
            db.SaveChangesAsync();
            return Json(company);
        }

        [HttpGet]
        public JsonResult GetCompany(int? id, string companyName="")
        {
            if (id != null)
            {
                var company = db.Companies.FirstOrDefault(p => p.Id == id);
                if (company != null)
                    return Json(company);
                return Json(NotFound());
            }
            if (companyName != "")
            {
                var company = db.Companies.FirstOrDefault(p => p.Name == companyName);
                if (company != null)
                    return Json(company);
                return Json(NotFound());
            }
            return Json(BadRequest("Request requiers companyName or id"));
        }
        [HttpGet]
        public JsonResult GetCompanies()
        {
            var companies = db.Companies.ToList();
            return Json(companies);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
