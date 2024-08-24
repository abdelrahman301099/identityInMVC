using Microsoft.AspNetCore.Mvc;
using webapplicationday8.Context;
using webapplicationday8.Models;


namespace webapplicationday8.Controllers
{
    public class CompanyController : Controller
    {
       public static DrugContext DrugContext;
        public CompanyController(DrugContext drugContext)
        {
           DrugContext = drugContext;
        }
        public IActionResult Index()
        {
            return View(DrugContext.Companies.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Company d)
        {
            DrugContext.Companies.Add(d);
            DrugContext.SaveChanges();
            return RedirectToAction("Index");
    
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                RedirectToAction("Index");
            Company? company = DrugContext.Companies.Find(id);
            if (company != null)
                return View(company);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Company C)
        {
            Company? old = DrugContext.Companies.Find(C.ID);
            if(old != null)
            {
                old.Name = C.Name;
                DrugContext.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var drug = DrugContext.Companies.FirstOrDefault(d => d.ID == id);
            if (drug == null)
            {
                return RedirectToAction("index");
            }
            ViewData["Drug"] = drug;
            return View(drug);
        }
        [HttpPost]
        public IActionResult Delete(Company company)
        {
            var c = DrugContext.Companies.FirstOrDefault(d => d.ID == company.ID);
            if (c != null)
            {
                DrugContext.Companies.Remove(c);
                DrugContext.SaveChanges();

            }
            return RedirectToAction("index");
        }
    }
}

