using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.DataModels
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonProperty("arrival_date")]
        public DateTime ArrivalDate { get; set; }
        [JsonProperty("price_per_night")]
        public decimal PricePerNight { get; set; }
        [JsonProperty("local_airports")]
        public string[] LocalAirports { get; set; }
        [JsonProperty("nights")]
        public int NoOfNights { get; set; }
    }
}
