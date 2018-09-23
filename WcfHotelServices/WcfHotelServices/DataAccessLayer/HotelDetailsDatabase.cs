using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfHotelServices.Model;

namespace WcfHotelServices.DataAccessLayer
{
    public class HotelDetailsDatabase
    {
        public List<Hotel> GetHotels()
        {
            List<Hotel> hotels = new List<Hotel>();
            Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            ISession session = cluster.Connect("hotels");
            string query = "select * from hotel";
            RowSet result = session.Execute(query);
            foreach (Row row in result)
            {
                Hotel hotel = new Hotel();
                hotel.Id = int.Parse(row[0].ToString());
                hotel.Name = row[1].ToString();
                hotel.StartingPrice = int.Parse(row[2].ToString());
                hotel.NumberOfRooms = int.Parse(row[3].ToString());
                hotel.Type = row[4].ToString();
                hotels.Add(hotel);
            }
            return hotels;
        }
        public List<Room> GetRooms(int id)
        {
            try
            {
                List<Room> rooms = new List<Room>();
                Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
                ISession session = cluster.Connect("hotels");
                string query = "select * from room";
                RowSet rowSet = session.Execute(query);
                foreach (Row row in rowSet)
                {
                    Room room = new Room();
                    int Id = int.Parse(row[3].ToString());
                    if (id != Id)
                    {
                        continue;
                    }
                    else
                    {
                        if (row[2].ToString().Equals("false"))
                        {
                            room.Id = int.Parse(row[0].ToString());
                            room.Beds = int.Parse(row[1].ToString());
                            room.Booked = row[2].ToString();
                            room.HotelId = Id;
                            room.Price = int.Parse(row[4].ToString());
                            room.Type = row[5].ToString();
                            rooms.Add(room);
                        }
                    }
                }
                return rooms;
            }
            catch (Exception e)
            {
                //LogAttribute.response = "Failue";
                //LogAttribute.exception = e.Message;
                throw new Exception(e.Message);
            }
        }
        public void PutHotelDetails(int id,int roomid)
        {
            Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            ISession session = cluster.Connect("hotels");
            string query = "select rooms from hotel where id=" + id;
            RowSet rooms = session.Execute(query);
            int room = 0;
            foreach(Row row in rooms)
            {
                room = int.Parse(row[0].ToString());
            }
            room = room -1;
            query = "update hotel set rooms = " + room + " where id = " + id;
            session.Execute(query);
            query = "update room set booked = 'True' where id = " + roomid;
            session.Execute(query);
        }
    }
}