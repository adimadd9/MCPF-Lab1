using NCalc;

namespace SRV_Lab1.Utils
{
    /// <summary>
    /// Provides functionality for evaluating mathematical expressions
    /// used in the numerical solution of differential equations.
    ///
    /// The class uses the NCalc library to parse and evaluate an expression
    /// provided as a string. The variables "x" and "u" in the expression
    /// are replaced with the corresponding numerical values before the
    /// expression is evaluated.
    ///
    /// For example, an expression such as "x + u" can be evaluated by
    /// providing specific values for x and u. This allows numerical methods
    /// to work with equations entered dynamically as text rather than
    /// having the differential equation hard-coded in each numerical method.
    /// </summary>
    internal class ExpressionEvaluator
    {
        /// <summary>
        /// Evaluates the specified mathematical expression for the given
        /// values of x and u.
        ///
        /// The expression is parsed using NCalc, while the parameters "x"
        /// and "u" are assigned the values provided to this method.
        /// The evaluated result is then converted to a double so that it
        /// can be used in numerical calculations.
        /// </summary>
        ///
        /// <param name="expression">
        /// The mathematical expression representing the right-hand side
        /// of the differential equation, i.e. f(x, u).
        /// </param>
        ///
        /// <param name="x">
        ///     The current value of the independent variable x.
        /// </param>
        ///
        /// <param name="u">
        ///     The current numerical approximation of the dependent variable u.
        /// </param>
        ///
        /// <returns>
        ///     The numerical value obtained by evaluating f(x, u).
        /// </returns>
        public static double Evaluate(string expression, double x, double u)
        {
            // Create an NCalc expression from the mathematical expression
            // provided by the user.
            var expr = new Expression(expression);
            expr.Parameters["x"] = x;
            expr.Parameters["u"] = u;

            object result = expr.Evaluate();
            return Convert.ToDouble(result);
        }
    }
}
