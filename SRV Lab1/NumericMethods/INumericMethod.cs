
using SRV_Lab1.Models;

namespace SRV_Lab1.NumericMethods
{
    /// <summary>
    /// Defines a common contract for numerical methods used to solve
    /// first-order Cauchy (initial value) problems.
    ///
    /// Any numerical method that implements this interface must provide
    /// a descriptive name and implement the Solve method. The Solve method
    /// receives a Cauchy problem as input and computes an approximate
    /// numerical solution over the specified integration interval.
    ///
    /// Using a common interface allows different numerical methods to be
    /// used interchangeably and makes it easier to compare their results,
    /// accuracy, and behavior for the same problem.
    /// </summary>
    public interface INumericMethod
    {
        /// <summary>
        /// Gets the name of the numerical method.
        /// This value can be used to identify the method when displaying
        /// results or comparing multiple numerical approaches.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Solves the specified Cauchy problem using the numerical method
        /// implemented by the current class.
        /// 
        /// The method returns a list of calculated result points. Each point
        /// contains the corresponding value of x and the approximate numerical
        /// value of the solution. If an analytical solution is available,
        /// the result points may also contain the exact value and the
        /// corresponding error.
        /// </summary>
        /// <param name="problem">
        /// The Cauchy problem containing the differential equation,
        /// initial condition, integration interval, and numerical step.
        /// </param>
        /// <returns>
        /// A list of <see cref="ResultPoint"/> objects representing the
        /// numerical solution at the calculated points of the integration interval.
        /// </returns>
        List<ResultPoint> Solve(CauchyProblem problem);
    }
}
