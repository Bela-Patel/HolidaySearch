﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.DataModels
{
    public class Flight
    {
        public int Id { get; set; }
        public string Airline { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        [JsonProperty("departure_date")]
        public DateTime DepartureDate { get; set; }
        public decimal Price { get; set; }
    }
}
