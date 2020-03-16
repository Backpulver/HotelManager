using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Reservation
    {
        [Key]
        public string Id { get; set; }
        public string RoomId { get; set; }
        public virtual Room Room { get; set; }
        public string ClientId { get; set; }
        public virtual Client Client { get; set; }
        public DateTime DateOfEntry { get; set; }
        public DateTime DateOfExpiry { get; set; }
        public bool Breakfast { get; set; }
        public bool AllIncusive { get; set; }
        public decimal Bill { get; set; }
    }
}
