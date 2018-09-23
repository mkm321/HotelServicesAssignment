using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelApiService.Models;
using HotelApiService.DataAccessLayer;
using HotelApiService.Attribute;

namespace HotelApiService.Controllers
{
    public class RoomController : Controller
    {
        [Logger]
        public IActionResult ShowRooms(string Book)
        {
            try
            {
                string[] values = Book.Split(",");
                ViewBag.name = values[1];
                List<Room> rooms = new List<Room>();
                HttpClient httpClient = new HttpClient();
                string query = "http://localhost:51675/HotelDetailsService.svc/Rooms/" + values[0];
                var response = httpClient.GetAsync(query).Result;
                rooms = response.Content.ReadAsAsync<List<Room>>().Result;
                LoggerAttribute.request = "Show Rooms";
                LoggerAttribute.response = "Ok";
                LoggerAttribute.exception = "No Exception";
                LoggerAttribute.comment = "Rooms successfully fetched!";
                return View(rooms);
            }
            catch(Exception e)
            {
                LoggerAttribute.request = "Show Rooms";
                LoggerAttribute.response = "Bad Request";
                LoggerAttribute.exception = e.Message;
                LoggerAttribute.comment = e.StackTrace;
                return BadRequest();
            }
        }
        [Logger]
        public IActionResult BookHotel(string ShowRooms)
        {
            try
            {
                string[] values = ShowRooms.Split(",");
                Database database = new Database();
                database.PostBookingRequest(values[4], values[1], values[2]);
                HttpClient httpClient = new HttpClient();
                string query = "http://localhost:51675/HotelDetailsService.svc/Hotel/" + values[3] + "/" + values[0];
                var content = new StringContent(values[3]);
                httpClient.PutAsync(query, content);
                LoggerAttribute.request = "Book hotel";
                LoggerAttribute.response = "Ok";
                LoggerAttribute.exception = "No Exception";
                LoggerAttribute.comment = "Hotel Successfully booked!";
                return View();
            }
            catch(Exception e)
            {
                LoggerAttribute.request = "Book hotel";
                LoggerAttribute.response = "Bad Request";
                LoggerAttribute.exception = e.Message;
                LoggerAttribute.comment = e.StackTrace;
                return BadRequest();
            }
        }
    }
}