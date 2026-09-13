using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_Lab1.Models
{
    /// <summary>
    /// Reprezinta un singur punct calculat: valoarea lui x, 
    /// valoarea aproximativa (numerica), si optional valoarea exacta (analitica).
    /// </summary>
    public class ResultPoint
    {
        public double X { get; set; }
        public double ApproxValue { get; set; }
        public double? ExactValue { get; set; }

        public double? Error { get; set; }
        public ResultPoint(double x, double approxValue)
        {
            X = x;
            ApproxValue = approxValue;
        }

    }
}
