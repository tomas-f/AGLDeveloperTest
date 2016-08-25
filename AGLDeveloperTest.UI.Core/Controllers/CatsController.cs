using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using AGLDeveloperTest.UI.Core.Services;
using AGLDeveloperTest.UI.Core.Models.Entities;
using AGLDeveloperTest.UI.Core.ViewModels;


namespace AGLDeveloperTest.UI.Core.Controllers
{
    public class CatsController : Controller
    {
        IPersonService _service;

        public CatsController() 
        {
            _service = new PersonService();
        }

        //Dependecy injection contructor for unit tests
        public CatsController(IPersonService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {            
            IEnumerable<Person> people = _service.GetPeople();
            //return View(people.Where(p => p.Pets != null).GroupBy(p => p.Gender, (key, items) => new { Gender = key, CatNames = items.SelectMany(c => c.Pets.Where(p => p.Type == "Cat").Select(p => p.Name).OrderBy(p => p)) }).Select(c => new CatViewModel { Gender = c.Gender, CatNames = c.CatNames }).ToList());
            
            //var a =     people.Where(p => p.Pets != null).GroupBy(p => p.Gender, (key, items) => new { Gender = key, CatNames = items.SelectMany(c => c.Pets.Where(p => p.Type == "Cat").Select(p => p.Name)) }).Select(c => new CatViewModel { Gender = c.Gender, CatNames = c.CatNames.OrderBy(p => p.ElementAt(0)) }).ToList();
            return View(people.Where(p => p.Pets != null).GroupBy(p => p.Gender, (key, items) => new { Gender = key, CatNames = items.SelectMany(c => c.Pets.Where(p => p.Type == "Cat").Select(p => p.Name)) }).Select(c => new CatViewModel { Gender = c.Gender, CatNames = c.CatNames.OrderBy(p => p.ElementAt(0)) }).ToList());
        }
    }
}