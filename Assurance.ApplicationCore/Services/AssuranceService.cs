using Assurance.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assurance.ApplicationCore.Entites;
using Assurance.ApplicationCore.DTO;

namespace Assurance.ApplicationCore.Services
{
    public class AssuranceService : IAssuranceService
    {

        private readonly IAsyncRepository<AssuranceTardi> _repository;

        public AssuranceService(IAsyncRepository<AssuranceTardi> repository)
        {
            _repository = repository;
        }

        public Task<AssuranceTardi> ObtenirSelonId(string id)
        {
            return _repository.GetByIdAsync(id);
        }
        public Task Ajouter(AssuranceTardi item)
        {
             return _repository.AddAsync(item);
        }

        public Task Modifier(AssuranceTardi item)
        {
           return _repository.EditAsync(item);
        }

        public Task<IEnumerable<AssuranceTardi>> ObtenirSelonPartenaire(string codePartenaire)
        {
            return _repository.ListAsync(assurance => assurance.CodePartenaire == codePartenaire);  
        }

        public async Task<IEnumerable<AssuranceTardiDTO>> ListeContract()
        {
            var assuranceClients = await _repository.ListAsync();
            
            List<AssuranceTardiDTO> assuranceDTO = new List<AssuranceTardiDTO>();

            foreach (var assurance in assuranceClients) { 
                double coefficient = CalculeCoefficient(assurance);
                double primeAnnuelle = Math.Round( assurance.Solde/10.0*coefficient, 2);

                primeAnnuelle = primeAnnuelle*(1 - (int)assurance.CodeRabais / 100.0);

                assuranceDTO.Add(new AssuranceTardiDTO()
                {
                    ID = assurance.ID,
                    NomClient = assurance.NomClient,
                    PrenomClient = assurance.PrenomClient,
                    Statut = assurance.Statut,
                    Montant = assurance.Solde,
                    Prime = primeAnnuelle,
                });
            }

            return assuranceDTO;
        }

        public Task Supprimer(AssuranceTardi item)
        {
             return _repository.DeleteAsync(item);
        }

        public IEnumerable<InteretResponseDTO> CalculInteret(IEnumerable<InteretRequestDTO> items)
        {

            // Formule interet composée : A = P(1+r/t)^nt

            List<InteretResponseDTO> interetsGagnes = new List<InteretResponseDTO>();

            int compositionParAn = 12;

            foreach(var dossier in items){
                double differenceEnAnnees = (dossier.DateFin - dossier.DateDebutCalcul).TotalDays / 365.0;
                double tauxInteretEnPourcentage = dossier.TauxInteret / 100.0;

                double montantFinal = dossier.Montant * Math.Pow(1 + (tauxInteretEnPourcentage / compositionParAn), 
                    compositionParAn * differenceEnAnnees);

                // Arrondi l'interet à 2 decimal après la virgules
                double interet = Math.Round(montantFinal - dossier.Montant, 2);

                // Add to response
                interetsGagnes.Add(new InteretResponseDTO()
                {
                    ClientID = dossier.ClientID,
                    CompteType = dossier.CompteType,
                    Interet = interet
                });
            }

            return interetsGagnes;
        }


        private double CalculeCoefficient(AssuranceTardi assurance) {
            int ageClient = DateTime.Now.Year - assurance.DateDeNaissance.Year;
            double coefficient = 0.01;

            if (ageClient >= 20) { 
                double trancheAge = (ageClient - 20)/10;
                coefficient += trancheAge * 0.01 + 0.01;
            }

            // Client masculin
            if(assurance.Sexe == Sexe.masculin)
            {
                coefficient += 0.01;
            }

            // Client fumeur
            if (assurance.EstFumeur)
            {
                coefficient += 0.02;
            }

            if(assurance.EstDiabetique || assurance.EstHypertendu)
            {
                coefficient += 0.01;
            }

            if (assurance.PratiqueActivitePhysique && ageClient >= 30) {
                coefficient -= 0.01;
            }

            return coefficient;
        }
    }
}
