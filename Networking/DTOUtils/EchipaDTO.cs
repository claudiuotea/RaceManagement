using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.model
{
    [Serializable]
    public class EchipaDTO
    {
        private int idEchipa;
        private string numeEchipa;

        public EchipaDTO(int idEchipa, string numeEchipa)
        {
            this.idEchipa = idEchipa;
            this.numeEchipa = numeEchipa;
        }

        public int Id
        {
            get { return idEchipa; }

        }

        public string NumeEchipa
        {
            get { return numeEchipa; }

        }
        public override string ToString()
        {
            return idEchipa + " " + numeEchipa;
        }
    }
}
