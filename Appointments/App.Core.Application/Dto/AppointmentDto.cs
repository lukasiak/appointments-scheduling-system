using System;

namespace App.Core.Application.Dto
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public DateTime Date { get; set; }
    }
}
