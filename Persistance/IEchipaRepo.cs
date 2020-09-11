using Model.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public interface IEchipaRepo : ICRUDRepository<int, Echipa>
    {
        Echipa findTeamByName(string teamName);

    }
}
