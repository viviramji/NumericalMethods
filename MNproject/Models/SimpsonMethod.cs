using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using org.mariuszgromada.math.mxparser;
using MNproject.Models.Classes; 

namespace MNproject.Models
{
    public class SimpsonMethod
    {
        public List<Simpson> GetSimpsonTable(Parameter _in)
        {
            List<Simpson> table = new List<Simpson>();
            int n = int.Parse(_in.n);
            double a = double.Parse(_in.a, CultureInfo.InvariantCulture);
            double b = double.Parse(_in.b, CultureInfo.InvariantCulture);
            double h = (b - a) / n;
            double[] fxi = new double[n + 1];
            double[] Xi = new double[n + 1];
            double[] SimpsonXi = new double[n + 1];
            Xi[0] = a;

            //double addXi = 0.0; double addSimpsonXi = 0.0;

            for (int i = 1; i <= n; i++)
            {
                //se crean los valore de Xi
                Xi[i] = Xi[i - 1] + h;
            }
            Argument x = new Argument("x");
            Expression e;
            //se crean los valores de F(xi) para cada Xi
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
                table.Add(new Simpson { n = i, x = Xi[i], fx = fxi[i], simpsonXi = SimpsonXi[i] });            
            }            
            return table;
        }

        public double ResultSimpson(Parameter _in)
        {
            List<Simpson> table = GetSimpsonTable(_in);
            int n = int.Parse(_in.n);
            double a = double.Parse(_in.a, CultureInfo.InvariantCulture);
            double b = double.Parse(_in.b, CultureInfo.InvariantCulture);
            double h = (b - a) / n;
            double c = h / 3; double addSimpsonXi = 0.0;
            foreach (var s in table)
            {
                addSimpsonXi += s.simpsonXi;
            }
            return c*addSimpsonXi;
        }
    }
}