using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.model
{
    [Serializable]
    public class ParticipantDTO
    {
        private int idParticipant;
        private int idCursa;
        private int? idEchipa;
        private string numeParticipant;
        string capCilindrica;
        private string numeEchipa;

        public ParticipantDTO(int idParticipant, int idCursa, int? idEchipa, string numeParticipant, string capCilindrica, string numeEchipa)
        {
            this.idParticipant = idParticipant;
            this.idCursa = idCursa;
            this.idEchipa = idEchipa;
            this.numeParticipant = numeParticipant;
            this.capCilindrica = capCilindrica;
            this.numeEchipa = numeEchipa;
        }

        public ParticipantDTO(int idParticipant, int idCursa, int? idEchipa, string numeParticipant, string capCilindrica)
        {
            this.idParticipant = idParticipant;
            this.idCursa = idCursa;
            this.idEchipa = idEchipa;
            this.numeParticipant = numeParticipant;
            this.capCilindrica = capCilindrica;
        }

        public string NumeEchipa
        {
            get { return numeEchipa; }
        }

        public string CapCilindrica
        {
            get { return capCilindrica; }
        }
        public int Id
        {
            get { return idParticipant; }
        }

        public int IdCursa { get { return idCursa; } }
        public int? IdEchipa { get { return idEchipa; } }


        public string NumeParticipant { get { return numeParticipant; } }

    }
}
