using Assurance.ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assurance.ApplicationCore.DTO
{
    public class InteretResponseDTO
    {
        public string ClientID { get; set; }
        public CompteType CompteType { get; set; }
        public double Interet { get; set; }
    }
}
