using Assurance.ApplicationCore.DTO;
using Assurance.ApplicationCore.Entites;
using Assurance.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assurance.API.Controllers
{
    /// <summary>
    /// Le controller Assurance gère toutes les opérations lié à la mise en place des assurance
    /// et le calcul des intérêts
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AssurancesController : ControllerBase
    {
        private readonly IAssuranceService _assuranceService;

        public AssurancesController(IAssuranceService assuranceService)
        {
            _assuranceService = assuranceService;
        }

        // GET: api/<AssurancesController>
        /// <summary>
        /// Retourne la liste de tous les contrats de la banque tardi
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<IEnumerable<AssuranceTardiDTO>> Get()
        {
            return _assuranceService.ListeContract();
        }


        // GET api/<AssurancesController>/5
        /// <summary>
        /// Recuperer un contrat en fournissant son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Task<AssuranceTardi> Get(string id)
        {
            return _assuranceService.ObtenirSelonId(id);
        }


        /// <summary>
        /// Rechercher les contrats selon le code partenaire
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("[action]/{id}")]
        public Task<IEnumerable<AssuranceTardi>> AssuranceParCodePartenaire(string id)
        {
            return _assuranceService.ObtenirSelonPartenaire(id);
        }

        // GET: api/<AssurancesController>
        /// <summary>
        /// Calcule les interet des clients
        /// </summary>
        /// <param name="comptes"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IEnumerable<InteretResponseDTO> CalculInteret(IEnumerable<InteretRequestDTO> comptes)
        {
            return _assuranceService.CalculInteret(comptes);
        }

        // POST api/<AssurancesController>
        /// <summary>
        /// Permet la création d'une assurance
        /// </summary>
        /// <param name="assurance"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public  Task Creation([FromBody] AssuranceTardi assurance)
        {
            return _assuranceService.Ajouter(assurance);
        }



        /// <summary>
        /// Permet la modification d'un contrat
        /// </summary>
        /// <param name="assurance"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public Task Modifier([FromBody] AssuranceTardi assurance)
        {
            return _assuranceService.Modifier(assurance);
        }

        // PUT api/<AssurancesController>/5
        /// <summary>
        /// Confirme la création d'un contrat
        /// </summary>
        /// <param name="id"></param>
        /// <param name="statut"></param>
        /// <returns></returns>
        [HttpPut("[action]/{id}")]
        public Task Confirmer(string id, [FromBody] bool statut)
        {
            return _assuranceService.Confirmer(id, statut);
        }

        // DELETE api/<AssurancesController>/5
        /// <summary>
        /// Supprime en contrat en spécifiant l'id du contrat
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult>  Delete(string id)
        {
            var assurance = await _assuranceService.ObtenirSelonId(id);
            if(assurance == null)
            {
                return NotFound();
            }
            await _assuranceService.Supprimer(assurance);
            return Ok();
        }
    }
}
