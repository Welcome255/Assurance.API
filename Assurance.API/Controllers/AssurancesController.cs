using Assurance.ApplicationCore.DTO;
using Assurance.ApplicationCore.Entites;
using Assurance.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        // GET: api/<AssurancesController>
        [HttpPost("[action]")]
        public IEnumerable<InteretResponseDTO> CalculInteret(IEnumerable<InteretRequestDTO> comptes)
        {
            return _assuranceService.CalculInteret(comptes);
        }

        // GET api/<AssurancesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AssurancesController>
        [HttpPost]
        public Task Post([FromBody] AssuranceTardi assurance)
        {
            var result = _assuranceService.Ajouter(assurance);
            return result;
        }

        // PUT api/<AssurancesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AssurancesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
