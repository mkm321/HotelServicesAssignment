using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HotelApiService.Attribute;
using HotelApiService.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelApiService.Controllers
{
    public class HotelController : Controller
    {
        [Logger]
        public async Task<IActionResult> GetAllHotels()
        {
            try
            {
                List<Hotel> hotels = new List<Hotel>();
                List<HotelContentDetails> hotelContentDetails = new List<HotelContentDetails>();
                List<HotelDetails> hotelDetails = new List<HotelDetails>();
                Task<List<HotelDetails>> hotelDetailTask = GetHotelDetailsFromWcf();
                hotelDetails = await hotelDetailTask;
                hotelContentDetails = GetHotelDetailsFromJson();
                for (int index = 0; index < hotelDetails.Count; index++)
                {
                    Hotel hotel = new Hotel();
                    hotel.Id = hotelDetails[index].Id;
                    hotel.Name = hotelDetails[index].Name;
                    hotel.NumberOfRooms = hotelDetails[index].NumberOfRooms;
                    hotel.StartingPrice = hotelDetails[index].StartingPrice;
                    hotel.Type = hotelDetails[index].Type;
                    int id = hotelDetails[index].Id;
                    for (int contentIndex = 0; contentIndex < hotelContentDetails.Count; contentIndex++)
                    {
                        if (hotelContentDetails[contentIndex].Id == id)
                        {
                            hotel.Policy = hotelContentDetails[contentIndex].Policy;
                            hotel.Rating = hotelContentDetails[contentIndex].Rating;
                            hotel.Address = hotelContentDetails[contentIndex].Address;
                            hotel.Amenities = hotelContentDetails[contentIndex].Amenities;
                            break;
                        }
                    }
                    hotels.Add(hotel);
                }
                LoggerAttribute.request = "Get All Hotel Details";
                LoggerAttribute.response = "OK";
                LoggerAttribute.exception = "No Exception";
                LoggerAttribute.comment = "Data Successfully fetched";
                ViewBag.name = "Hotel";
                return View(hotels);
            }
            catch(Exception e)
            {
                LoggerAttribute.request = "Get All Hotel Details";
                LoggerAttribute.response = "Bad Request";
                LoggerAttribute.exception = e.Message;
                LoggerAttribute.comment = e.StackTrace;
                return BadRequest();
            }
        }
        public async Task<List<HotelDetails>> GetHotelDetailsFromWcf()
        {
            List<HotelDetails> hotelDetails = new List<HotelDetails>();
            await Task.Run(() =>
            {
                HttpClient httpClient = new HttpClient();
                var response = httpClient.GetAsync("http://localhost:51675/HotelDetailsService.svc/HotelDetails").Result;
                hotelDetails = response.Content.ReadAsAsync<List<HotelDetails>>().Result;
            });
            return hotelDetails;
        }
        public List<HotelContentDetails> GetHotelDetailsFromJson()
        {
            List<HotelContentDetails> hotelContentDetails = new List<HotelContentDetails>();
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            path = path + "/../../../DataAccessLayer/" + "hotelContent.json";
            using (StreamReader streamReader = new StreamReader(path))
            {
                var json = streamReader.ReadToEnd();
                hotelContentDetails = JsonConvert.DeserializeObject<List<HotelContentDetails>>(json);
            }
            return hotelContentDetails;
        }
    }
}