
using SRV_Lab1.Models;

namespace SRV_Lab1.NumericMethods
{
    /// <summary>
    /// Contract comun pentru orice metoda numerica de rezolvare a problemei Cauchy.
    /// Orice metoda primeste problema si intoarce lista de puncte calculate.
    /// </summary>
    public interface INumericMethod
    {
        string Name { get; }
        List<ResultPoint> Solve(CauchyProblem problem);
    }
}
