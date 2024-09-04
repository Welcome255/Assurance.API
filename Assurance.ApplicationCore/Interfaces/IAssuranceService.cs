
namespace Assurance.ApplicationCore.Interfaces
{
    public interface IAssuranceService
    {
        public Task Ajouter(Entites.AssuranceClient item);
        public Task<Entites.AssuranceClient> ObtenirSelonId(int id);
        public Task<IEnumerable<Entites.AssuranceClient>> ObtenirTout();
        public Task Modifier(Entites.AssuranceClient item);
        public Task Supprimer(Entites.AssuranceClient item);

    }
}
