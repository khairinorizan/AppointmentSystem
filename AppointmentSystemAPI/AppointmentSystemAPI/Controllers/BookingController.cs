namespace AppointmentSystemAPI.Controllers
{
    using System;
    using System.Web;
    using Microsoft.AspNetCore.Mvc;

    public class BookingController: Controller
    {
        [HttpGet]
        public string Welcome()
        {
            return "TestWelcome";
        }
    }
}
