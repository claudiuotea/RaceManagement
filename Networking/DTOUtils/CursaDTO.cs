using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.model
{
    [Serializable]
    public class CursaDTO
    {
        private string capacitateCilindrica;
        private int idCursa;
        private int numarParticipanti;

        public CursaDTO(string capacitateCilindrica, int idCursa, int numarParticipanti)
        {
            this.capacitateCilindrica = capacitateCilindrica;
            this.idCursa = idCursa;
            this.numarParticipanti = numarParticipanti;
        }

        public int Id
        {
            get { return idCursa; }

        }

        public int NumarParticipanti
        {
            get { return numarParticipanti; }

        }

        public string CapacitateCilindrica
        {
            get { return capacitateCilindrica; }

        }
        public override string ToString()
        {
            return capacitateCilindrica + " " + numarParticipanti;
        }
    }
}
