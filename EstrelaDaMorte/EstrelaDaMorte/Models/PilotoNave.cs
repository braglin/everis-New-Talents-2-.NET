using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EstrelaDaMorte.Models
{
    public class PilotoNave
    {
        [Key]
        [Column(Order = 0)]
        public int IdPiloto { get; set; }
        [Key]
        [Column(Order = 1)]
        public int IdNave { get; set; }
        public bool FlagAutorizado { get; set; }
    }
}
