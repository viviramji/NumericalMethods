using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetodosNumericosFinal.Models
{
    public class ModelFacade
    {
        public List<Simpson> getResult(element _in)
        {
            return new simpsonMethod().GetSimpsons(_in);
        }
    }
}