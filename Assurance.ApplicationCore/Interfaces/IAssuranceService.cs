
using Assurance.ApplicationCore.DTO;
using Assurance.ApplicationCore.Entites;

namespace Assurance.ApplicationCore.Interfaces
{
    public interface IAssuranceService
    {
        public Task Ajouter(Entites.AssuranceTardi item);
        public Task<IEnumerable<AssuranceTardi>> ObtenirSelonPartenaire(string codePartenaire);
        public Task<AssuranceTardi> ObtenirSelonId(string id);
        public Task<IEnumerable<AssuranceTardiDTO>> ListeContract();
        public Task Modifier(AssuranceTardi item);
        public Task Supprimer(AssuranceTardi item);
        public IEnumerable<InteretResponseDTO> CalculInteret(IEnumerable<InteretRequestDTO> items);

    }
}
