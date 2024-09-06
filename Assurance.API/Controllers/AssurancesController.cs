using Assurance.ApplicationCore.DTO;
using Assurance.ApplicationCore.Entites;
using Assurance.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assurance.API.Controllers
{
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
        [HttpGet]
        public Task<IEnumerable<AssuranceTardiDTO>> Get()
        {
            return _assuranceService.ListeContract();
        }

        // GET api/<AssurancesController>/5
        [HttpGet("{id}")]
        public Task<AssuranceTardi> Get(string id)
        {
            return _assuranceService.ObtenirSelonId(id);
        }

        [HttpGet("[action]/{id}")]
        public Task<IEnumerable<AssuranceTardi>> AssuranceParCodePartenaire(string id)
        {
            return _assuranceService.ObtenirSelonPartenaire(id);
        }

        // GET: api/<AssurancesController>
        [HttpPost("[action]")]
        public IEnumerable<InteretResponseDTO> CalculInteret(IEnumerable<InteretRequestDTO> comptes)
        {
            return _assuranceService.CalculInteret(comptes);
        }

        // POST api/<AssurancesController>
        [HttpPost("[action]")]
        public  Task Creation([FromBody] AssuranceTardi assurance)
        {
            return _assuranceService.Ajouter(assurance);
        }

        [HttpPost("[action]")]
        public Task Modifier([FromBody] AssuranceTardi assurance)
        {
            return _assuranceService.Modifier(assurance);
        }

        // PUT api/<AssurancesController>/5
        [HttpPut("[action]/{id}")]
        public void Confirmer(string id)
        {
            _assuranceService.Confirmer(id);
        }

        // DELETE api/<AssurancesController>/5
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
