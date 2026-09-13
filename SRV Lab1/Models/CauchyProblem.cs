using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_Lab1.Models
{
    /// <summary>
    /// Contine toate datele de intrare ale problemei Cauchy:
    /// du/dx = f(x, u), cu u(x0) = u0, pe intervalul [x0, xEnd], cu pasul h.
    /// </summary>
    internal class CauchyProblem
    {
        public string EquationText { get; set; }
        public double X0 { get; set; }
        public double U0 { get; set; }
        public double XEnd { get; set; }
        public double Step { get; set; }

        // optional - poate fi null sau string gol daca userul nu a completat-o
        public string? AnalyticSolutionText { get; set; }

        public bool HasAnalyticSolution => !string.IsNullOrWhiteSpace(AnalyticSolutionText);
    }
}

