using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using org.mariuszgromada.math.mxparser;
using MNproject.Models.Classes;

namespace MNproject.Models
{
    public class BisectionMethod
    {
        public List<Table> Table(Parameter _in)
        {
            //esto es _in =>
                double a = 0;
                double n = 10;
                double b = 2;
                double h = (b + a) / n; //ancho para Xi
                string fx = "x^2";  


            List<Table> table = new List<Table>();
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
            double tol = 0.01;
            string fx = "x^2";
            int[] indexes = new int[1];
            for (int i = 1; i < table.Count; i++)
            {
                //aplica cuando f(xi)*f(x(i+1)) < 0) quiere decir que los valores entre esos dos valores f(x) cambia de signo
                if (table[i].fx * table[i-1].fx < 0) 
                {
                    //a = i - 1;
                    //b = i;
                    indexes[0] = i - 1;
                    indexes[1] = i;
                    //break;
                }
                else
                {
                    //return "la funcion ingresada no tiene raices";
                }
            }
            //a y b tomaran los valores donde se puede aplicar el metodo de biseccion
            var a = table[indexes[0]].x; 
            var b = table[indexes[1]].x;
            //List<Bisection> bisections = new List<Bisection>();

            double xr; //punto medio

            while (true)
            {
                xr = (a + b) / 2.0;
                if(Math.Abs(F(fx,xr)) <= tol)
                {
                    return ("Para una tolerancia de "+ tol +" la raiz de f es "+xr);
                }
                else
                {
                    if(F(fx, xr)*F(fx, a) > 0)
                    {
                        a = xr;
                    }else if(F(fx, xr)*F(fx, b) > 0)
                    {
                        b = xr;
                    } 
                }
            }
        }

        //F(x)
        public static double F(string fx, double _x)
        {
            Argument x = new Argument("x");
            x.setArgumentValue(_x);
            Expression e = new Expression(fx, x);
            double test = e.calculate();
            return e.calculate();
        }
        
    }
}