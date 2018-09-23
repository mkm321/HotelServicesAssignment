using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfHotelServices.DataAccessLayer;
using WcfHotelServices.Model;

namespace WcfHotelServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HotelDetailsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HotelDetailsService.svc or HotelDetailsService.svc.cs at the Solution Explorer and start debugging.
    public class HotelDetailsService : IHotelDetailsService
    {
        HotelDetailsDatabase hotelDetailsDatabase = new HotelDetailsDatabase();
        public List<Hotel> GetHotelDetails()
        {
            return hotelDetailsDatabase.GetHotels();
        }

        public List<Room> GetRoomsByHotelId(string id)
        {
            return hotelDetailsDatabase.GetRooms(int.Parse(id));
        }

        public void PutHotelRequest(string id,string roomid)
        {
            hotelDetailsDatabase.PutHotelDetails(int.Parse(id),int.Parse(roomid));
        }
    }
}
