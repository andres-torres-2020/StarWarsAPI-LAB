using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsAPI.Models
{
    public class PersonPlanetViewModel
    {
        public Person person { get; set; }
        public Planet planet { get; set; }
        public List<string> PeopleNames { get; set; }
    }
}
