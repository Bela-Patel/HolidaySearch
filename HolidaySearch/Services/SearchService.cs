using HolidaySearch.DataModels;
using HolidaySearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Services
{
    public class SearchService : ISearchService
    {
        private readonly List<Flight> _flights;
        private readonly List<Hotel> _hotels;

        public SearchService(List<Flight> flights, List<Hotel> hotels)
        {
            _flights = flights;
            _hotels = hotels;
        }
        public Result Search(SearchVM search)
        {
            var holidays = new List<Result>();

            var matchingFlights = _flights.Where(f => (f.From == search.DepartingFrom || string.IsNullOrEmpty(search.DepartingFrom)) && (f.To == search.TravelingTo || string.IsNullOrEmpty(search.TravelingTo)) && (f.DepartureDate == search.DepartureDate || search.DepartureDate == null)).ToList();

            var matchingHotels = _hotels.Where(h => h.LocalAirports.Contains(search.TravelingTo) && h.ArrivalDate <= search.DepartureDate && h.NoOfNights >= search.Duration).ToList();


            foreach (var flight in matchingFlights)
            {
                foreach (var hotel in matchingHotels)
                {
                    holidays.Add(new Result(hotel, flight));
                }
            }
            if (holidays.Count == 0)
                return new Result("Sorry, we couldn't find the holiday you're looking for.");
            return holidays.OrderBy(h => h.Flight.Price + (h.Hotel.PricePerNight * h.Hotel.NoOfNights)).ToList().First();
        }
    }
}
