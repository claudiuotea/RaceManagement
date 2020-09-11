using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.model
{
    public class Echipa : IEntity<int>
    {
        private int idEchipa;
        private string numeEchipa;
        
        public Echipa(int idEchipa, string numeEchipa)
        {
            this.idEchipa = idEchipa;
            this.numeEchipa = numeEchipa;
        }

        public int Id
        {
            get { return idEchipa; }
            //sau get => idEchipa;
            //set{ id = value; }
            set { idEchipa = value; }
        }

        public string NumeEchipa
        {
            get { return numeEchipa; }
            set { numeEchipa = value; }
        }
        public override string ToString()
        {
            return idEchipa + " " + numeEchipa;
        }
    }
}
