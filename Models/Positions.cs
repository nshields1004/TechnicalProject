using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StatSportsTechnicalProject.Models
{
    public class playerpositions
    {
        [Key]
        public int id { get; set; }
        public int playerId { get; set; }
        public int sessionId { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
    }
}
