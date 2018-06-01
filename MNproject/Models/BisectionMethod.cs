using System;
using System.Collections.Generic;
using System.Globalization;
using org.mariuszgromada.math.mxparser;
using MNproject.Models.Classes;

namespace MNproject.Models
{
    public class BisectionMethod
    {
        public List<Table> Table(Parameter _in)
        {
            //esto es _in =>
            List<Table> table = new List<Table>();
            int n = int.Parse(_in.n);
            double a = double.Parse(_in.a, CultureInfo.InvariantCulture);
            double b = double.Parse(_in.b, CultureInfo.InvariantCulture);
            double h = (b - a) / n;
            string fx = _in.fx;
            for (int i = 0; i < n; i++)
            {
                table.Add(new Table { x = a, fx = F(fx, a) });
                a += h;
            }           
            return table;
        }

        public string getBisectionResult(Parameter _in)
        {
            //tomamos la tabla donde de valores xi vs F(xi) buscamos donde F(xi) cambia de signo
            List<Table> table = Table(_in);
            bool valida = false;
            double tol = double.Parse(_in.t, CultureInfo.InvariantCulture);
            string fx = _in.fx;
            int[] indexes = new int[2];
            for (int i = 1; i < table.Count; i++)
            {
                //aplica cuando f(xi)*f(x(i+1)) < 0) quiere decir para los valores entre f(x) cambia de signo
                if (table[i].fx * table[i-1].fx < 0) 
                {
                    indexes[0] = i - 1;
                    indexes[1] = i;
                    valida = true;
                }                
            }
            if (valida)
            {
                //a y b tomaran los valores donde se puede aplicar el metodo de biseccion
                double a = table[indexes[0]].x;
                double b = table[indexes[1]].x;
                //List<Bisection> bisections = new List<Bisection>();

                double xr; //punto medio

                while (true)
                {
                    xr = (a + b) / 2.0;
                    if (Math.Abs(F(fx, xr)) <= tol)
                    {
                        return "Para una tolerancia de " + tol + " la raiz de f(x) es " + xr + " entre los intervalos "+ a + " y " + b;
                    }
                    else
                    {
                        if (F(fx, xr) * F(fx, a) > 0)
                        {
                            a = xr;
                        }
                        else if (F(fx, xr) * F(fx, b) > 0)
                        {
                            b = xr;
                        }
                    }
                }
            }
            else
            {
                return "La ecuacion o los intervalos seleccionados no tienen raiz";
            }            
        }

        //F(x)
        public double F(string fx, double _x)
        {
            Argument x = new Argument("x");
            x.setArgumentValue(_x);
            Expression e = new Expression(fx, x);
            double test = e.calculate();
            return e.calculate();
        }
        
    }
}