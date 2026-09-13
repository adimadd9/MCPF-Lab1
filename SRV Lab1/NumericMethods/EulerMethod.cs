using SRV_Lab1.Models;
using SRV_Lab1.Utils;

namespace SRV_Lab1.NumericMethods
{
    public class EulerMethod : INumericMethod
    {
        public string Name => "Metoda Euler";

        public List<ResultPoint> Solve(CauchyProblem problem)
        {
            var results = new List<ResultPoint>();
            
            double x = problem.X0;
            double u = problem.U0;

            results.Add(new ResultPoint(x, u));

            while (x < problem.XEnd)
            {
                double f = ExpressionEvaluator.Evaluate(problem.EquationText, x, u);

                u = u + problem.Step * f;
                x = x + problem.Step;

                results.Add(new ResultPoint(x, u));
            }

            return results;
        }
    }
}
