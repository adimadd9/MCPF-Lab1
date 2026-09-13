using NCalc;

namespace SRV_Lab1.Utils
{
    internal class ExpressionEvaluator
    {
        public static double Evaluate(string expression, double x, double u)
        {
            var expr = new Expression(expression);
            expr.Parameters["x"] = x;
            expr.Parameters["u"] = u;

            object result = expr.Evaluate();
            return Convert.ToDouble(result);
        }
    }
}
