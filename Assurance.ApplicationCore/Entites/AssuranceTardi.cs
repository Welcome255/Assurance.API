﻿using Assurance.ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assurance.ApplicationCore.Entites
{
    public class AssuranceTardi : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override string? ID { get; set; }
        public string ClientID { get; set; }
        public string NomClient { get; set; } 
        public string PrenomClient { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public string CodePartenaire { get; set; }
        public CodeRabais CodeRabais { get; set; }
        public double Solde {  get; set; }
        public Sexe Sexe { get; set; }
        public bool EstFumeur { get; set; }
        public bool EstDiabetique { get; set; }
        public bool EstHypertendu { get; set; }
        public bool PratiqueActivitePhysique { get; set; }
        public bool Statut { get; set; } = false;

    }
}
