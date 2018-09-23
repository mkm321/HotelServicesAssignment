using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfHotelServices.Model;

namespace WcfHotelServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHotelDetailsService" in both code and config file together.
    [ServiceContract]
    public interface IHotelDetailsService
    {
        [OperationContract]
        [WebGet(UriTemplate = "HotelDetails", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Hotel> GetHotelDetails();
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json ,UriTemplate = "Rooms/{id}")]
        List<Room> GetRoomsByHotelId(string id);
        [OperationContract]
        [WebInvoke(UriTemplate = "Hotel/{id}/{roomid}", Method = "PUT", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void PutHotelRequest(string id,string roomid);
    }
}
