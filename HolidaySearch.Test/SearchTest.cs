using HolidaySearch.DataModels;
using HolidaySearch.Models;
using HolidaySearch.Services;
using Newtonsoft.Json;
using System.Reflection;

namespace HolidaySearch.Test
{
    [TestClass]
    public class SearchTest
    {
        private ISearchService _searchService;
        private List<Flight> _flights;
        private List<Hotel> _hotels;
        [TestInitialize]
        public void Init()
        {
           
            using (StreamReader r = new StreamReader(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"InputData\hotels.json")))
            {
                string json = r.ReadToEnd();
                _hotels = JsonConvert.DeserializeObject<List<Hotel>>(json);
            }
            using (StreamReader r = new StreamReader(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"InputData\flights.json")))
            {
                string json = r.ReadToEnd();
                _flights = JsonConvert.DeserializeObject<List<Flight>>(json);
            }
            _searchService = new SearchService(_flights, _hotels);
        }

        [TestMethod]
        public void ManchesterAirportToMalagaAirport()
        {
            var search = new SearchVM
            {
                DepartingFrom = "MAN",
                TravelingTo = "AGP",
                DepartureDate = Convert.ToDateTime("2023/07/01"),
                Duration = 7
            };
            var result = _searchService.Search(search);
            Assert.IsNotNull(result);                     
            Assert.AreEqual("Flight 2 and Hotel 9",String.Format("Flight {0} and Hotel {1}", result.Flight.Id, result.Hotel.Id));          
        }
        [TestMethod]
        public void AnyAirportToMallorcaAirport()
        {
            var search = new SearchVM
            {
                DepartingFrom = "",
                TravelingTo = "PMI",
                DepartureDate = Convert.ToDateTime("2023/06/15"),
                Duration = 10
            };
            var result = _searchService.Search(search);
            Assert.IsNotNull(result);           
            Assert.AreEqual("Flight 6 and Hotel 5", String.Format("Flight {0} and Hotel {1}", result.Flight.Id, result.Hotel.Id));
        }
        [TestMethod]
        public void AnyAirportToGranCanariaAirport()
        {
            var search = new SearchVM
            {
                DepartingFrom = "",
                TravelingTo = "LPA",
                DepartureDate = Convert.ToDateTime("2022/11/10"),
                Duration = 14
            };
            var result = _searchService.Search(search);
            Assert.IsNotNull(result);
            Assert.AreEqual("Flight 7 and Hotel 6", String.Format("Flight {0} and Hotel {1}", result.Flight.Id, result.Hotel.Id));
        }
    }
}