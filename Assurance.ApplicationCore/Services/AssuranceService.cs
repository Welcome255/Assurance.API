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

        private readonly IAsyncRepository<AssuranceClient> _repository;

        public Task Ajouter(AssuranceClient item)
        {
            throw new NotImplementedException();
        }

        public Task Modifier(AssuranceClient item)
        {
            throw new NotImplementedException();
        }

        public Task<AssuranceClient> ObtenirSelonId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AssuranceClient>> ObtenirTout()
        {
            throw new NotImplementedException();
        }

        public Task Supprimer(AssuranceClient item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<InteretResponseDTO>> CalculInteret(IEnumerable<InteretRequestDTO> items)
        {
            throw new NotImplementedException();
        }
    }
}
