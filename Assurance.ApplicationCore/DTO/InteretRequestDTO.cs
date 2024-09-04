using Assurance.ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assurance.ApplicationCore.DTO
{
    public class InteretRequestDTO
    {
        public string ClientID { get; set; }
        public CompteType CompteType { get; set; }
        public double Montant {  get; set; }
        public DateTime DateDebutCalcul {  get; set; } 
        public DateTime DateFin {  get; set; }
        public int TauxInteret { get; set; }
    }
}
