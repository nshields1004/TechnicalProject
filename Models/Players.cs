using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StatSportsTechnicalProject.Models
{
    public class Players
    {
            [Key]
            public int id { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string avatarImg { get; set; }
            public DateTime dateOfBirth { get; set; }
            public string playerPosition { get; set; }
    }
}
