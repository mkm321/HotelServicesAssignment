using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfHotelServices
{
    [DataContract]
    public class Hotel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int StartingPrice { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public int NumberOfRooms { get; set; }
    }
}