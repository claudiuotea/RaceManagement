using Model.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IAppObserver
    {
        void updateCurse(int idCursa);
    }
}
