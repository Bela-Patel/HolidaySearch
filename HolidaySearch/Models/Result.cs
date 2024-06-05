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

        public Hotel Hotel { get; set; }
        public Flight Flight { get; set; }
    }
}
