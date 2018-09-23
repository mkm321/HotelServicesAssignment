using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApiService.Models
{
    public class HotelDetails
    {
        public int Id { get; set; }
        public int StartingPrice { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int NumberOfRooms { get; set; }
    }
}
