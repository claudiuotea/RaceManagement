using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.model
{
    public class Participant : IEntity<int>
    {
        private int idParticipant;
        private int idCursa;
        private int? idEchipa;
        private string numeParticipant;
        string capCilindrica;
        private string numeEchipa;
        public Participant(int idCursa, int? idEchipa, string numeParticipant)
        {
            this.idCursa = idCursa;
            this.idEchipa = idEchipa;
            this.numeParticipant = numeParticipant;
        }

        public Participant(int idParticipant, int idCursa, int? idEchipa, string numeParticipant, string capCilindrica, string numeEchipa)
        {
            this.idParticipant = idParticipant;
            this.idCursa = idCursa;
            this.idEchipa = idEchipa;
            this.numeParticipant = numeParticipant;
            this.capCilindrica = capCilindrica;
            this.numeEchipa = numeEchipa;
        }

        public string NumeEchipa
        {
            get { return numeEchipa; }
            set { numeEchipa = value; }
        }
        public string CapCilindrica
        {
            get { return capCilindrica; }
            set { capCilindrica = value; }
        }
        public int Id
        {
            get { return idParticipant; }
            set { idParticipant = value; }
        }

        public int IdCursa { get { return idCursa; } }
        public int? IdEchipa { get { return idEchipa; } }


        public string NumeParticipant { get { return numeParticipant; } }

        public override string ToString()
        {
            return numeParticipant + " =====> " + capCilindrica;
        }
    }
}
