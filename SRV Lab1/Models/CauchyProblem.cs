namespace SRV_Lab1.Models
{
    /// <summary>
    /// Represents all input data required to define and solve a Cauchy (initial value)
    /// problem for a first-order ordinary differential equation of the form:
    ///
    /// du/dx = f(x, u), with u(x0) = u0
    ///
    /// over the interval [x0, xEnd] using the specified numerical integration step.
    ///
    /// The class stores the differential equation as a text expression, the initial
    /// conditions, the boundaries of the integration interval, and the numerical step
    /// size. An optional analytical solution can also be provided, which may be used
    /// for comparison with the numerical solution and for calculating the approximation
    /// error.
    /// </summary>
    public class CauchyProblem
    {
        /// <summary>
        /// Gets or sets the differential equation f(x, u) represented as a text expression.
        /// This expression defines the right-hand side of the differential equation
        /// du/dx = f(x, u).
        /// </summary>
        public string EquationText { get; set; }
        /// <summary>
        /// Gets or sets the initial value x0, which represents the starting point
        /// of the integration interval and the point at which the initial condition
        /// u(x0) = u0 is specified.
        /// </summary>
        public double X0 { get; set; }
        /// <summary>
        /// Gets or sets the initial value u0 of the unknown function.
        /// It represents the value of u at the initial point x0, i.e. u(x0) = u0.
        /// </summary>
        public double U0 { get; set; }
        /// <summary>
        /// Gets or sets the right endpoint xEnd of the integration interval.
        /// The numerical method computes an approximation of the solution from x0
        /// to this endpoint.
        /// </summary>
        public double XEnd { get; set; }
        /// <summary>
        /// Gets or sets the numerical integration step size h.
        /// The step determines the distance between consecutive points at which
        /// the numerical solution is computed.
        /// </summary>
        public double Step { get; set; }
        /// <summary>
        /// Gets or sets the optional analytical (exact) solution of the differential equation.
        /// It may be null or an empty/whitespace string if no analytical solution was provided.
        /// When available, it can be used to compare the numerical approximation with the
        /// exact solution and evaluate the accuracy of the numerical method.
        /// </summary>
        public string? AnalyticSolutionText { get; set; }
        /// <summary>
        /// Gets a value indicating whether an analytical solution has been provided.
        /// Returns true when AnalyticSolutionText contains a non-empty, non-whitespace value;
        /// otherwise, returns false.
        /// </summary>
        public bool HasAnalyticSolution => !string.IsNullOrWhiteSpace(AnalyticSolutionText);
    }
}

