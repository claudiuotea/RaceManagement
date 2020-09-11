using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.model
{
    public class Cursa : IEntity<int>
    {
        private string capacitateCilindrica;
        private int idCursa;
        private int numarParticipanti;

        public Cursa(string capacitateCilindrica, int idCursa, int numarParticipanti)
        {
            this.capacitateCilindrica = capacitateCilindrica;
            this.idCursa = idCursa;
            this.numarParticipanti = numarParticipanti;
        }

        public int Id
        {
            get { return idCursa; }
            set { idCursa = value; }
        }

        public int NumarParticipanti
        {
            get { return numarParticipanti; }
            set { numarParticipanti = value; }
        }

        public string CapacitateCilindrica
        {
            get { return capacitateCilindrica; }
            set { capacitateCilindrica = value; }
        }
        public override string ToString()
        {
            return capacitateCilindrica + " " + numarParticipanti;
        }
    }
}
