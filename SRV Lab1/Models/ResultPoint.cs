namespace SRV_Lab1.Models
{
    /// <summary>
    /// Represents a single point of the numerical solution of the Cauchy problem.
    ///
    /// The class stores the value of the independent variable x together with
    /// the corresponding approximate (numerical) value of the unknown function.
    /// If an analytical solution is available, the exact value at the same point
    /// can also be stored. The difference between the numerical and exact values
    /// can be represented by the Error property and used to evaluate the accuracy
    /// of the numerical method.
    /// </summary>
    public class ResultPoint
    {
        /// <summary>
        /// Gets or sets the value of the independent variable x at which
        /// the solution is evaluated.
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// Gets or sets the approximate value of the unknown function u(x)
        /// obtained using a numerical method.
        /// </summary>
        public double ApproxValue { get; set; }
        /// <summary>
        /// (Optional)
        /// Gets or sets the exact (analytical) value of the solution u(x),
        /// if an analytical solution has been provided.
        /// 
        /// The value is nullable because an analytical solution may not be
        /// available for the given Cauchy problem.
        /// </summary>
        public double? ExactValue { get; set; }
        /// <summary>
        /// (Optional)
        /// Gets or sets the error between the approximate numerical value
        /// and the exact analytical value at the current point.
        /// 
        /// The value is nullable because the error cannot be calculated when
        /// an exact analytical solution is not available.
        /// </summary>
        public double? Error { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ResultPoint"/> class
        /// using the specified x-coordinate and approximate solution value.
        /// 
        /// The exact value and error are not initialized by the constructor
        /// and remain null until they are calculated or assigned later.
        /// </summary>
        /// <param name="x">
        /// The value of the independent variable x.
        /// </param>
        /// <param name="approxValue">
        /// The approximate numerical value of the solution at x.
        /// </param>
        public ResultPoint(double x, double approxValue)
        {
            X = x;
            ApproxValue = approxValue;
        }

    }
}
