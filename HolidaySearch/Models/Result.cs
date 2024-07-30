using HolidaySearch.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Models
{
    public class Result
    {

        public Result(Hotel hotel, Flight flight)
        {
            Hotel = hotel;
            Flight = flight;
        }
        public Result(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public Hotel Hotel { get; set; }
        public Flight Flight { get; set; }

        public string? ErrorMessage { get; set; }
    }
}
