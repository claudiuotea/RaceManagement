using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.model
{
    interface IValidator<E>
    {
        void validate(E entity);
    }
}
