using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assurance.ApplicationCore.Entites
{
    public class AssuranceClient : BaseEntity
    {
        public string ClientID { get; set; }
        public string Solde {  get; set; }
        public string Sexe { get; set; }
        public bool EstFumeur { get; set; }
        public bool EstDiabetique { get; set; }
        public bool EstHypertendu { get; set; }
        public bool PratiqueActivitePhysique { get; set; }

    }
}
