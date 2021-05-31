using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Domain.Entities
{
    public class Appointment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime Date { get; set; }
    }
}
