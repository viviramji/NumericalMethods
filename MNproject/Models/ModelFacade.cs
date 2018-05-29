using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MNproject.Models.Classes;

namespace MNproject.Models
{
    public class ModelFacade
    {
        public List<Simpson> getResult(Parameter _in)
        {
            return new SimpsonMethod().GetSimpsons(_in);
        }
    }
}