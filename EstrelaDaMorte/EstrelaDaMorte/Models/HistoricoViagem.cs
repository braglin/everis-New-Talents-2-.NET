using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EstrelaDaMorte.Models
{
    public class HistoricoViagem
    {
        [Key]
        public int Id { get; set; }
        public int IdNave { get; set; }
        public int IdPiloto { get; set; }
        [DisplayName("Data Saída")]
        public DateTime DtSaida { get; set; }
        [DisplayName("Data Chegada")]
        public DateTime DtChegada { get; set; }
    }
}
