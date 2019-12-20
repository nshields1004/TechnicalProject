using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StatSportsTechnicalProject.Models
{
    public class Sessions
    {
        [Key]
        public int id { get; set; }
        public int playerId { get; set; }
        public double totalDistance { get; set; }
        public double maxSpeed { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
    }
}
