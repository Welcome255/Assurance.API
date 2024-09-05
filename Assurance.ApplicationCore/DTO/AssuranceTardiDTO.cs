using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assurance.ApplicationCore.DTO
{
    public class AssuranceTardiDTO
    {
        public string ID { get; set; }
        public string NomClient { get; set; }
        public string PrenomClient { get; set; }
        public double Prime {  get; set; }
        public double Montant { get; set; }
        public bool Statut { get; set; } = false;
    }
}
