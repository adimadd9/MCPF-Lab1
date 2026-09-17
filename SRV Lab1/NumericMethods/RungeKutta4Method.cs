using SRV_Lab1.Models;
using SRV_Lab1.Utils;

namespace SRV_Lab1.NumericMethods
{
    /// <summary>
    /// Implements the classic fourth-order Runge-Kutta (RK4) numerical method
    /// for solving first-order Cauchy (initial value) problems.
    ///
    /// The RK4 method improves accuracy over the Euler-based methods by
    /// evaluating the slope of the solution at four points within each step:
    /// at the start of the interval, twice near the midpoint (using successive
    /// refinements), and at the end of the interval. These four slopes are
    /// then combined using a weighted average to compute the next approximation.
    ///
    /// The numerical approximation is computed according to the formulas:
    ///
    /// k1 = f(x_n, u_n)
    /// k2 = f(x_n + h/2, u_n + h/2 * k1)
    /// k3 = f(x_n + h/2, u_n + h/2 * k2)
    /// k4 = f(x_n + h, u_n + h * k3)
    /// u_(n+1) = u_n + (h/6) * (k1 + 2*k2 + 2*k3 + k4)
    ///
    /// where h is the numerical step size.
    /// </summary>
    internal class RungeKutta4Method : INumericMethod
    {
        /// <summary>
        /// Gets the display name of the numerical method.
        /// </summary>
        public string Name => "Metoda Runge-Kutta de ordinul 4";
        
        /// <summary>
        /// Solves the specified Cauchy problem using the fourth-order Runge-Kutta method.
        /// 
        /// The algorithm starts from the initial point (x0, u0) and repeatedly
        /// advances by the specified step size. At every iteration, four slope
        /// estimates (k1, k2, k3, k4) are computed at different points within
        /// the current interval, and the next approximation of the solution is
        /// calculated using their weighted average.
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
        /// of the numerical solution computed by the Runge-Kutta 4 method.
        /// </returns>
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
