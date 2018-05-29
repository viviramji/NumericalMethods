using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MNproject.Models.Classes;

namespace MNproject.Models
{
    public class ModelFacade
    {
        public List<Simpson> GetSimpsonTable(Parameter _in)
        {
            return new SimpsonMethod().GetSimpsonTable(_in);
        }

        public double GetResultSimpson(Parameter _in)
        {
            return new SimpsonMethod().ResultSimpson(_in);
        }

    }
}