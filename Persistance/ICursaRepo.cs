using Model.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public interface ICursaRepo : ICRUDRepository<int, Cursa>
    {
        Cursa returnCursaByCapacitate(string capacitate);
        int getNumberOfParticipants(int idCursa);
    }
}
