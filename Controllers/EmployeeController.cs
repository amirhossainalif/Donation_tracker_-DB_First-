using Donation_Tracker.EF;
using Donation_Tracker.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Security.Policy;
using System.Web.Helpers;
using System.Xml.Linq;

namespace Donation_Tracker.Controllers
{
    public class EmployeeController : Controller
    {
        Donation_TrackerEntities db = new Donation_TrackerEntities();

        // GET: Employee
        public ActionResult DeshBoard()
        {
            var data = db.Donor_Details.ToList();
            var converted = Convertt(data);
            return View(converted);
            //return View();
        }
        [HttpGet]
        public ActionResult Create_Donar() {
            return View();
        }
        [HttpPost]
        public ActionResult Create_Donar(DonorDTO D, EmployeeDTO e) {
            if (ModelState.IsValid)
            {
                var st = converte(D);
                db.Donors.Add(st);
                db.SaveChanges();
                return RedirectToAction("DeshBoard", "Employee");
            }
            return View(e);
        }

        public ActionResult Donar_list() 
        {
            var data = db.Donors.ToList();
            var converted = converte(data);
            return View(converted);
        }
        [HttpGet]
        public ActionResult Registration() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(EmployeeDTO e, LoginDTO l)
        {
            if (ModelState.IsValid)
            {
                var st = Converter(e);
                db.Employees.Add(st);
                var lo = convert(l);
                db.Logins.Add(lo);
                db.SaveChanges();
                return RedirectToAction("Login", "Home");
            }
            return View(e);
        }
        [HttpGet]
        public ActionResult Donate()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Donate(Donor_DetailsDTO e)
        {
            
            if (ModelState.IsValid)
            {
                var st = Convertt(e);
                db.Donor_Details.Add(st);
                db.SaveChanges();
                return RedirectToAction("DeshBoard", "Employee");
            }
            return View(e);
        }

        public static Donor_DetailsDTO Convertt(Donor_Details s)
        {
            return new Donor_DetailsDTO()
            {
                Id = s.Id,
                Name = s.Name,
                Amount = s.Amount,
                Date = s.Date,
                Donor_Id = s.Donor_Id
            };
        }
        public static Donor_Details Convertt(Donor_DetailsDTO s)
        {
            return new Donor_Details()
            {
                Id = s.Id,
                Name = s.Name,
                Amount = s.Amount,
                Date = s.Date,
                Donor_Id= s.Donor_Id
            };
        }
        public static List<Donor_DetailsDTO> Convertt(List<Donor_Details> donar)
        {
            var list = new List<Donor_DetailsDTO>();
            foreach (var s in donar)
            {
                var st = Convertt(s);
                list.Add(st);
            }
            return list;
        }

        public static LoginDTO convert(Login l)
        {
            return new LoginDTO()
            {
                Email = l.Email,
                Password = l.Password
            };
        }

        public static Login convert(LoginDTO l)
        {

            return new Login()
            {
                Email = l.Email,
                Password = l.Password
            };
        }

        public static List<LoginDTO> convert(List<Login> users)
        {
            var list = new List<LoginDTO>();
            foreach (var u in users)
            {
                var use = convert(u);
                list.Add(use);
            }
            return list;
        }

        public static DonorDTO converte(Donor l)
        {
            return new DonorDTO()
            {
                Id = l.Id,
                Name = l.Name,
                DOB = l.DOB,
                Email = l.Email,
                Phone = l.Phone,
                Address = l.Address
                
            };
        }

        public static Donor converte(DonorDTO l)
        {

            return new Donor()
            {
                Id = l.Id,
                Name = l.Name,
                DOB = l.DOB,
                Email = l.Email,
                Phone = l.Phone,
                Address = l.Address
            };
        }

        public static List<DonorDTO> converte(List<Donor> users)
        {
            var list = new List<DonorDTO>();
            foreach (var u in users)
            {
                var use = converte(u);
                list.Add(use);
            }
            return list;
        }

        public static EmployeeDTO Converter(Employee l)
        {
            return new EmployeeDTO()
            {
                Id = l.Id,
                Name = l.Name,
                Email = l.Email,
                Phone = l.Phone,
                Address = l.Address
            };
        }

        public static Employee Converter(EmployeeDTO l)
        {

            return new Employee()
            {
                Id = l.Id,
                Name = l.Name,
                Email = l.Email,
                Phone = l.Phone,
                Address = l.Address
            };
        }

        public static List<EmployeeDTO> Converter(List<Employee> users)
        {
            var list = new List<EmployeeDTO>();
            foreach (var u in users)
            {
                var use = Converter(u);
                list.Add(use);
            }
            return list;
        }
        [HttpGet]
        public ActionResult Edit_Donor(int id)
        {
            var exobj = db.Donors.Find(id);
            return View(converte(exobj));
        }

        [HttpPost]
        public ActionResult Edit_Donor(DonorDTO s)
        {
            var exobj = db.Donors.Find(s.Id);
            exobj.Name = s.Name;
            exobj.DOB = s.DOB;
            exobj.Email = s.Email;
            exobj.Phone = s.Phone;
            exobj.Address = s.Address;
            db.SaveChanges();

            return RedirectToAction("DeshBoard");
        }
        [HttpGet]
        public ActionResult Delete_Donor(int id)
        {
            var exobj = db.Donors.Find(id);
            return View(converte(exobj));

        }
        [HttpPost]
        public ActionResult Delete_Donor(DonorDTO s)
        {
            var exobj = db.Donors.Find(s.Id);
            db.Donors.Remove(exobj);
            db.SaveChanges();
            return RedirectToAction("DeshBoard");
        }

        public ActionResult Details_Donor(int id)
        {
            var exobj = db.Donors.Find(id);
            return View(converte(exobj));
        }

       
    }
}