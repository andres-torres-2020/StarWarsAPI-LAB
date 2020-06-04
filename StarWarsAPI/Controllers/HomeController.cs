/*
 * A.TORRES
 *
 * Star Wars API Lab
 *
 * See https://swapi.dev/documentation
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StarWarsAPI.Models;

namespace StarWarsAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly StarWarsApiDal _DAL;

        public HomeController()
        {
            _DAL = new StarWarsApiDal();
        }

        public async Task<IActionResult> Index()
        {
            PersonPlanetViewModel peopleNames = new PersonPlanetViewModel();
            List<Person> people = await _DAL.GetPeople();
            peopleNames.PeopleNames = people.Select(x => x.name).ToList();
            return View(peopleNames);
        }

        public async Task<IActionResult> GetPersonById(int id)
        {
            PersonPlanetViewModel personPlanetViewModel = new PersonPlanetViewModel();
            personPlanetViewModel.person = await _DAL.GetPerson(id);
            return View("Result", personPlanetViewModel);
        }
        public async Task<IActionResult> GetPersonByName(string? PersonName)
        {
            PersonPlanetViewModel personPlanetViewModel = new PersonPlanetViewModel();
            personPlanetViewModel.person = await _DAL.GetPersonByName(PersonName);
            return View("Result", personPlanetViewModel);
        }
        public async Task<IActionResult> GetPlanetById(int id)
        {
            PersonPlanetViewModel personPlanetViewModel = new PersonPlanetViewModel();
            personPlanetViewModel.planet = await _DAL.GetPlanet(id);
            return View("Result", personPlanetViewModel);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
