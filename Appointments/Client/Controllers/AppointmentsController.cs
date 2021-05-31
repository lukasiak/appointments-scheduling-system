using System;
using System.Collections.Generic;
using System.Linq;
using App.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App
{
    public class AppointmentsController : ControllerBase
    {
        public AppointmentsController()
        {

        }

        public IEnumerable<Appointment> Get()
        {
            var list = new List<Appointment>();

            list.Add(new Appointment
            {
                Id = 1,
                Name = "Gunnar",
                Email = "ds@dfd.se",
                PhoneNumber = "+4670051541514",
                StartTime = DateTime.Now.AddHours(1),
                EndTime = DateTime.Now.AddHours(2),
                Date = DateTime.Now.AddHours(1)
            });

            list.Add(new Appointment
            {
                Id = 2,
                Name = "Test",
                Email = "hej@hej.se",
                PhoneNumber = "saknas",
                StartTime = DateTime.Now.AddHours(3),
                EndTime = DateTime.Now.AddHours(4),
                Date = DateTime.Now.AddHours(3)
            });

            return list.OrderBy(a => a.StartTime);
        }
    }
}
