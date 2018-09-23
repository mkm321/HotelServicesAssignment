using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApiService.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int StartingPrice { get; set; }
        public int NumberOfRooms { get; set; }
        public int Rating { get; set; }
        public string Address { get; set; }
        public string Policy { get; set; }
        public string[] Amenities { get; set; }
        //public string[] ImageUrls { get; set; }
    }
}
