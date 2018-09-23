using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApiService.Models
{
    public class HotelContentDetails
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Address { get; set; }
        public string Policy { get; set; }
        public string[] Amenities { get; set; }
    }
}
