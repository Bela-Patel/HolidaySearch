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

            var matchingFlights = _flights.Where(f => (f.From == search.DepartingFrom || search.DepartingFrom == String.Empty) && f.To == search.TravelingTo && f.DepartureDate == search.DepartureDate).ToList();

            var matchingHotels = _hotels.Where(h => h.LocalAirports.Contains(search.TravelingTo) && h.ArrivalDate <= search.DepartureDate && h.NoOfNights >= search.Duration).ToList();

            var holidays = new List<Result>();

            foreach (var flight in matchingFlights)
            {
                foreach (var hotel in matchingHotels)
                {
                    holidays.Add(new Result(hotel, flight));
                }
            }

            return holidays.OrderBy(h => h.Flight.Price + (h.Hotel.PricePerNight * h.Hotel.NoOfNights)).ToList().First();
        }
    }
}
