using Model.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public interface IParticipantRepo : ICRUDRepository<int, Participant>
    {
        IEnumerable<Participant> getParticipantsByTeam(int idEchipa);
    }
}
