using SRV_Lab1.Models;
using SRV_Lab1.Utils;

namespace SRV_Lab1.NumericMethods
{
    /// <summary>
    /// Implements the explicit Euler numerical method for solving
    /// first-order Cauchy (initial value) problems.
    ///
    /// The Euler method approximates the solution of a differential equation
    /// of the form du/dx = f(x, u) starting from the given initial condition
    /// u(x0) = u0. At each step, the derivative is evaluated at the current
    /// point and used to calculate the solution at the next point.
    ///
    /// The numerical approximation is computed according to the formula:
    ///
    /// u_(n+1) = u_n + h * f(x_n, u_n)
    ///
    /// where h is the numerical step size.
    /// </summary>
    public class EulerMethod : INumericMethod
    {
        /// <summary>
        /// Gets the display name of the numerical method.
        /// </summary>
        public string Name => "Metoda Euler";
        
        /// <summary>
        /// Solves the specified Cauchy problem using the explicit Euler method.
        /// 
        /// The algorithm starts from the initial point (x0, u0) and repeatedly
        /// advances by the specified step size. At every iteration, the value
        /// of the differential equation f(x, u) is evaluated at the current
        /// numerical point, after which the next approximation of the solution
        /// is calculated.
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
        /// of the numerical solution computed by the Euler method.
        /// </returns>
        public List<ResultPoint> Solve(CauchyProblem problem)
        {
            var results = new List<ResultPoint>();
            
            double x = problem.X0;
            double u = problem.U0;

            results.Add(new ResultPoint(x, u));

            while (x < problem.XEnd)
            {
                x = x + problem.Step;

                double f = ExpressionEvaluator.Evaluate(problem.EquationText, x, u);

                u = u + problem.Step * f;

                results.Add(new ResultPoint(x, u));
            }

            return results;
        }
    }
}
