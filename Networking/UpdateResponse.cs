using System;
using System.Collections.Generic;
using System.Text;

namespace Networking
{   
    [Serializable]
    class UpdateResponse : Response
    {
    }

    [Serializable]
    class ParticipantAdded:UpdateResponse
    {
        int idCursa;

        public ParticipantAdded(int idCursa)
        {
            this.idCursa = idCursa;
        }

        public int IdCursa
        {
            get { return idCursa; }
        }
    }
}
