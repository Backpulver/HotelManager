using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Room
    {
        [Key]
        public string Id { get; set; }
        public int Capacity { get; set; }
        public string Type { get; set; }
        public bool IsOccupied { get; set; }
        public decimal PriceForAdult { get; set; }
        public decimal PriceForChild { get; set; }
        public int RoomNumber { get; set; }
    }
}
