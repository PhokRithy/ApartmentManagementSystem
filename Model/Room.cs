using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APARTMENT_MANAGEMENT_SYSTEM.Model
{
    public class Room
    {
        public int id { get; set; }
        public String room_no { get; set; }
        public int roomtypeid { get; set; }
        public decimal servicecharge { get; set; }
        public int floorid { get; set; }
        public String roomkey { get; set; }
        public decimal price { get; set; }
        public String status { get; set; }
        public String note { get; set; }
    }
}
