using System;
using System.Collections.Generic;
using System.Globalization;
using MNproject.Models.Classes;

namespace MNproject.Models
{
    public class ModelFacade
    {
        //IntegracionMethod
        public List<Simpson> GetSimpsonTable(Parameter _in)
        {
            return new SimpsonMethod().GetSimpsonTable(_in);
        }

        public double GetResultSimpson(Parameter _in)
        {
            return new SimpsonMethod().ResultSimpson(_in);
        }

        //bisectionMethod
        public List<Table> GetTable(Parameter _in)
        {
            return new BisectionMethod().Table(_in);
        }

        public string GetBisectionResult(Parameter _in)
        {
            return new BisectionMethod().getBisectionResult(_in);
        }

        public double GetEvaluacion(Parameter _in)
        {
            string fx = _in.fx;
            double x = double.Parse(_in.a, CultureInfo.InvariantCulture);
            return new BisectionMethod().F(fx, x);
        }

    }
}