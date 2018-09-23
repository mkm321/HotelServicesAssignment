using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApiService.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Beds { get; set; }
        public string Booked { get; set; }
        public int HotelId { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }
    }
}
