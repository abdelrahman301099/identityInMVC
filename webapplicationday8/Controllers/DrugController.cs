using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using System.Xml.Linq;
using webapplicationday8.Context;
using webapplicationday8.Models;

namespace webapplicationday8.Controllers
{
    public class DrugController : Controller
    {
       


        public static DrugContext DrugContext;
        public DrugController(DrugContext drugContext)
        {
            DrugContext = drugContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ViewResult GetInfo()
        {


            return View(DrugContext.Drugs.Include(s => s.Company));
        }
        public ViewResult ViewDetails(int id)
        {
            
            Drug d =DrugContext.Drugs.FirstOrDefault(x => x.ID == id);
            ViewData["d"] = d;
            return View();
        }
        [HttpGet]
        public IActionResult EditForm(int? id)
        {
            if (id != null)

            { Drug d = DrugContext.Drugs.FirstOrDefault(x => x.ID == id); 
            if(d != null)
                {
                 
                    ViewBag.Companies=new SelectList(DrugContext.Companies, "ID", "Name");
                    return View(d);
                }

               
            }

            return RedirectToAction("GetInfo");
        }
        [HttpPost]
           public IActionResult EditForm(Drug drug)
        {
           
           
                    Drug d = DrugContext.Drugs.FirstOrDefault(x => x.ID == drug.ID);
            if (d != null)
            {
                d.Name = drug.Name;
                d.ExpirationDate = drug.ExpirationDate;
               
                d.ManufactureDate = drug.ManufactureDate;
                d.CompanyID= drug.CompanyID;
              DrugContext.SaveChanges();   
            }

            return RedirectToAction("GetInfo");
        }
        [HttpGet]
        public IActionResult create()
        {
            ViewBag.Drugs = new SelectList(DrugContext.Companies, "ID", "Name");
            return View();
         
        }
        [HttpPost]
        public  IActionResult create(Drug drug)
        {
            ModelState.Remove("Company");
            if (drug != null && ModelState.IsValid)
            {
                DrugContext.Drugs.Add(drug);
                DrugContext.SaveChanges();


                return RedirectToAction("GetInfo");
            }
            ModelState.AddModelError("", "All Field is Required");
         ViewBag.Drugs = new SelectList(DrugContext.Companies, "ID", "Name");
            return View();
        }
        [HttpGet]
        public IActionResult ConfirmDelete(int id)
        {
            var drug = DrugContext.Drugs.FirstOrDefault(d => d.ID == id);
            if (drug == null)
            {
                return RedirectToAction("GetInfo");
            }
            ViewData["Drug"] = drug;
            return View(drug);
        }
        [HttpPost]
        public IActionResult ConfirmDelete(Drug drug)
        {
            
            var d = DrugContext.Drugs.FirstOrDefault(d => d.ID == drug.ID);
            if (d != null)
            {
                DrugContext.Drugs.Remove(d);
                DrugContext.SaveChanges();

            }
            return RedirectToAction("GetInfo");
        }
    }

}
