using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace StarWarsAPI.Models
{
    public class StarWarsApiDal
    {
        public StarWarsApiDal()
        {
        }
        public HttpClient GetClient()
        {
            string uri = $"https://swapi.dev/api/";
            var client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            return client;
        }
        public async Task<Person> GetPerson(int personId)
        {
            try
            {
                var client = GetClient();
                var response = await client.GetAsync($"people/{personId}/");
                //var response = await client.GetAsync(new Uri($"https://swapi.dev/api/people/3"));
                string personJSON = await response.Content.ReadAsStringAsync();
                Person person = JsonSerializer.Deserialize<Person>(personJSON);
                return person;
            }
            catch
            {
                return null;
            }
        }
        public async Task<Person> GetPersonByName(string name)
        {
            try
            {
                var client = GetClient();
                var response = await client.GetAsync($"people/?search={name}");
                string personJSON = await response.Content.ReadAsStringAsync();
                PersonRootobject peopleRoot = JsonSerializer.Deserialize<PersonRootobject>(personJSON);
                List<Person> people = peopleRoot.results.ToList<Person>();
                return people[0];
            }
            catch
            {
                return null;
            }
        }
        public async Task<List<Person>> GetPeople()
        {
            var client = GetClient();
            var response = await client.GetAsync("people/");
            string personJSON = await response.Content.ReadAsStringAsync();
            PersonRootobject peopleRoot = JsonSerializer.Deserialize<PersonRootobject>(personJSON);
            List<Person> people = peopleRoot.results.ToList<Person>();
            return people;
        }
        public async Task<Planet> GetPlanet(int planetId)
        {
            try
            {
                var client = GetClient();
                var response = await client.GetAsync($"planets/{planetId}/");
                string planetJSON = await response.Content.ReadAsStringAsync();
                Planet planet = JsonSerializer.Deserialize<Planet>(planetJSON);
                return planet;
            }
            catch
            {
                return null;
            }
        }
        public async Task<List<Planet>> GetPlanets()
        {
            var client = GetClient();
            var response = await client.GetAsync($"planets/");
            string planetJSON = await response.Content.ReadAsStringAsync();
            PlanetRootobject planetRoot = JsonSerializer.Deserialize<PlanetRootobject>(planetJSON);
            List<Planet> planets = planetRoot.results.ToList<Planet>();
            return planets;
        }
    }
}
