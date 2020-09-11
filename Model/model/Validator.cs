using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.model
{
    public class Validator : IValidator<Participant>
    {
        public void validate(Participant entity)
        {
            string errors = "";
            if (entity.IdEchipa < 0)
                errors += "Id echipa invalid\n";
            if (entity.IdCursa < 0 || entity.IdCursa == null)
                errors += "Id cursa invalid\n";
            if (entity.NumeParticipant == "" || entity.NumeParticipant == null)
                errors += "Nume participant invalid\n";

            if (errors.Length > 0)
                throw new Exception("Date invalide participant!" + errors);
        }
    }
}
