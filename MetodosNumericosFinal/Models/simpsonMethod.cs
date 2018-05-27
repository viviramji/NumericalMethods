using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using org.mariuszgromada.math.mxparser;

namespace MetodosNumericosFinal.Models
{
    public class simpsonMethod
    {
        public List<Simpson> GetSimpsons(element _in)
        {
            List<Simpson> table = new List<Simpson>();
            int n = int.Parse(_in.n);
            double a = double.Parse(_in.a, CultureInfo.InvariantCulture);
            double b = double.Parse(_in.b, CultureInfo.InvariantCulture);
            double h = (b - a) / n;
            double sumSimpson = 0.0, sumFxi = 0.0;
            double[] fxi = new double[n + 1];
            double[] Xi = new double[n + 1];
            double[] SimpsonXi = new double[n + 1];
            Xi[0] = a;
            for (int i = 1; i <= n; i++)
            {
                //se rellena los valore de Xi
                Xi[i] = Xi[i - 1] + h;
            }
            Argument x = new Argument("x");
            Expression e;
            for (int i = 0; i <= n; i++)
            {
                x.setArgumentValue(Xi[i]);
                e = new Expression(_in.fx, x);
                fxi[i] = e.calculate();
            }
            //se asignan los valores de Simpson en la primera y ultima posicion del array
            x.setArgumentValue(Xi[0]);
            e = new Expression(_in.fx, x);
            SimpsonXi[0] = e.calculate();
            x.setArgumentValue(Xi[n]);
            e = new Expression(_in.fx, x);
            SimpsonXi[n] = e.calculate();

            //se asinga los valores de Simpson a las restantes posiciones teniendo en cuenta que las posiones pares se multiplican por 2 y las impares por 4
            for (int i = 1; i < n; i++)
            {
                x.setArgumentValue(Xi[i]);
                e = new Expression(_in.fx, x);
                if (i % 2 == 0)
                {
                    SimpsonXi[i] = 2 * e.calculate();
                }
                else
                {
                    SimpsonXi[i] = 4 * e.calculate();
                }

            }

            //se crean las instanacias de la clase simpson y automaticamente se ingresan a la lista a retornar, llamada table
            for (int i = 0; i <= n; i++)
            {
                table.Add(new Simpson { n = i, x = Xi[i], fx = fxi[i], resp = SimpsonXi[i] });
                sumSimpson += SimpsonXi[i];
                sumFxi += fxi[i];
            }
            return table;
        } 
        
    }
}