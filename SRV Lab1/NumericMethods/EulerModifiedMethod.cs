using SRV_Lab1.Models;
using SRV_Lab1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_Lab1.NumericMethods
{
    internal class EulerModifiedMethod : INumericMethod
    {
        public string Name => "Metoda Euler modificata";

        public List<ResultPoint> Solve(CauchyProblem problem)
        {
            var results = new List<ResultPoint>();

            double x = problem.X0;
            double u = problem.U0;

            results.Add(new ResultPoint(x, u));

            while (x < problem.XEnd)
            {
                double f1 = ExpressionEvaluator.Evaluate(problem.EquationText, x, u);

                // Predictor - estimare initiala (ca la Euler simplu)
                double uPredict = u + problem.Step * f1;
                double xNext = x + problem.Step;

                // Corector - panta in punctul estimat
                double f2 = ExpressionEvaluator.Evaluate(problem.EquationText, xNext, uPredict);

                // Media celor doua pante
                u = u + (problem.Step / 2.0) * (f1 + f2);
                x = xNext;

                results.Add(new ResultPoint(x, u));
            }

            return results;
        }
    }
}
