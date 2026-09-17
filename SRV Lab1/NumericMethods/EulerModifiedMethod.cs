using SRV_Lab1.Models;
using SRV_Lab1.Utils;

namespace SRV_Lab1.NumericMethods
{
    /// <summary>
    /// Implements the modified Euler (Heun) numerical method for solving
    /// first-order Cauchy (initial value) problems.
    ///
    /// The modified Euler method improves on the explicit Euler method by
    /// using a predictor-corrector approach: it first estimates the solution
    /// at the next point using the standard Euler formula (predictor), then
    /// refines this estimate by averaging the slope at the current point
    /// with the slope at the predicted point (corrector).
    ///
    /// The numerical approximation is computed according to the formula:
    ///
    /// predictor: u~_(n+1) = u_n + h * f(x_n, u_n)
    /// corrector: u_(n+1) = u_n + (h/2) * (f(x_n, u_n) + f(x_(n+1), u~_(n+1)))
    ///
    /// where h is the numerical step size.
    /// </summary>
    internal class EulerModifiedMethod : INumericMethod
    {
        /// <summary>
        /// Gets the display name of the numerical method.
        /// </summary>
        public string Name => "Metoda Euler modificata";

        /// <summary>
        /// Solves the specified Cauchy problem using the modified Euler method.
        /// 
        /// The algorithm starts from the initial point (x0, u0) and repeatedly
        /// advances by the specified step size. At every iteration, the slope
        /// is first evaluated at the current point and used to predict the
        /// solution at the next point. The slope is then evaluated again at
        /// this predicted point, and the final approximation is calculated
        /// using the average of the two slopes.
        /// 
        /// The initial point is included in the returned list. Each subsequent
        /// point contains the new x-coordinate and the corresponding numerical
        /// approximation of u(x).
        /// </summary>
        /// <param name="problem">
        /// The Cauchy problem to be solved. It contains the differential
        /// equation, initial condition, integration interval, and step size.
        /// </param>
        /// <returns>
        /// A list of <see cref="ResultPoint"/> objects containing the points
        /// of the numerical solution computed by the modified Euler method.
        /// </returns>
        public List<ResultPoint> Solve(CauchyProblem problem)
        {
            var results = new List<ResultPoint>();

            double x = problem.X0;
            double u = problem.U0;

            results.Add(new ResultPoint(x, u));

            while (x < problem.XEnd)
            {
                double f1 = ExpressionEvaluator.Evaluate(problem.EquationText, x, u);

                // Predictor 
                double uPredict = u + problem.Step * f1;
                double xNext = x + problem.Step;

                // Corector
                double f2 = ExpressionEvaluator.Evaluate(problem.EquationText, xNext, uPredict);

                u = u + (problem.Step / 2.0) * (f1 + f2);
                x = xNext;

                results.Add(new ResultPoint(x, u));
            }

            return results;
        }
    }
}
