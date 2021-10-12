using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EstrelaDaMorte.Models
{
    public class Piloto
    {
        [Key]
        public int IdPiloto { get; set; }
        public string Nome { get; set; }
        public string AnoNascimento { get; set; }
        public int IdPlaneta { get; set; }
    }
}
