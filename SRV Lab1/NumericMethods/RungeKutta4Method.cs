using SRV_Lab1.Models;
using SRV_Lab1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_Lab1.NumericMethods
{
    internal class RungeKutta4Method : INumericMethod
    {
        public string Name => "Metoda Runge-Kutta de ordinul 4";

        public List<ResultPoint> Solve(CauchyProblem problem)
        {
            var results = new List<ResultPoint>();

            double x = problem.X0;
            double u = problem.U0;
            double h = problem.Step;

            results.Add(new ResultPoint(x, u));

            while (x < problem.XEnd)
            {
                double k1 = ExpressionEvaluator.Evaluate(problem.EquationText, x, u);
                double k2 = ExpressionEvaluator.Evaluate(problem.EquationText, x + h / 2.0, u + h / 2.0 * k1);
                double k3 = ExpressionEvaluator.Evaluate(problem.EquationText, x + h / 2.0, u + h / 2.0 * k2);
                double k4 = ExpressionEvaluator.Evaluate(problem.EquationText, x + h, u + h * k3);

                u = u + (h / 6.0) * (k1 + 2 * k2 + 2 * k3 + k4);
                x = x + h;

                results.Add(new ResultPoint(x, u));
            }

            return results;
        }
    }
}
