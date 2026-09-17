using SRV_Lab1.Models;
using SRV_Lab1.NumericMethods;
using SRV_Lab1.Utils;
using System.Windows.Forms.DataVisualization.Charting;

namespace SRV_Lab1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  The procedure for reading the data and solving the Cauchy problem using the chosen method.
        /// </summary>
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Read and validate the input
            if (!double.TryParse(txtX0.Text, out double x0))
            {
                MessageBox.Show("x0 invalid.");
                return;
            }
            if (!double.TryParse(txtU0.Text, out double u0))
            {
                MessageBox.Show("u0 invalid.");
                return;
            }
            if (!double.TryParse(txtXEnd.Text, out double xEnd))
            {
                MessageBox.Show("xEnd invalid.");
                return;
            }
            if (!double.TryParse(txtStep.Text, out double step) || step <= 0)
            {
                MessageBox.Show("Pasul h trebuie sa fie un numar pozitiv.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtEquation.Text))
            {
                MessageBox.Show("Introduceti ecuatia diferentiala.");
                return;
            }
            if (cmbMethod.SelectedIndex < 0)
            {
                MessageBox.Show("Alegeti metoda");
                return;
            }
            if (xEnd <= x0)
            {
                MessageBox.Show("xEnd trebuie sa fie mai mare decat x0.");
                return;
            }

            // Define the problem object
            var problem = new CauchyProblem
            {
                EquationText = txtEquation.Text,
                X0 = x0,
                U0 = u0,
                XEnd = xEnd,
                Step = step,
                AnalyticSolutionText = txtAnalytic.Text
            };

            //0 - Metoda Euler
            //1 - Metoda Euler modificata
            //2 - Metoda Runge - Kutta de ordinul 4

            INumericMethod method = cmbMethod.SelectedIndex switch
            {
                0 => new EulerMethod(),
                1 => new EulerModifiedMethod(),
                2 => new RungeKutta4Method(),
                _ => throw new InvalidOperationException("Undefined method")
            };

            // Solving
            List<ResultPoint> results;
            try
            {
                results = method.Solve(problem);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la evaluarea ecuatiei: {ex.Message}");
                return;
            }

            // Complet analytical solution if exist
            if (problem.HasAnalyticSolution)
            {
                foreach (var point in results)
                {
                    double exact = ExpressionEvaluator.Evaluate(problem.AnalyticSolutionText!, point.X, 0);
                    point.ExactValue = exact;
                    point.Error = Math.Abs(exact - point.ApproxValue);
                }
            }

            // Display grid with results and chart
            PopulateGrid(results, problem.HasAnalyticSolution);
            PopulateChart(results, problem.HasAnalyticSolution);
        }

        private void PopulateGrid(List<ResultPoint> results, bool hasAnalytic)
        {
            dgvResults.Columns.Clear();
            dgvResults.Rows.Clear();

            dgvResults.Columns.Add("colX", "x");
            dgvResults.Columns.Add("colApprox", "u aproximativ");

            if (hasAnalytic)
            {
                dgvResults.Columns.Add("colExact", "u exact");
                dgvResults.Columns.Add("colError", "Eroare");
            }

            // Populate lines
            foreach (var point in results)
            {
                if (hasAnalytic)
                {
                    dgvResults.Rows.Add(
                        point.X.ToString("F4"),
                        point.ApproxValue.ToString("F6"),
                        point.ExactValue?.ToString("F6"),
                        point.Error?.ToString("F6")
                    );
                }
                else
                {
                    dgvResults.Rows.Add(
                        point.X.ToString("F4"),
                        point.ApproxValue.ToString("F6")
                    );
                }
            }
        }

        private void PopulateChart(List<ResultPoint> results, bool hasAnalytic)
        {
            chartResults.Series.Clear();

            var approxSeries = new Series("Numeric (Euler)")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.Double
            };

            // Put numerical method results on chart
            foreach (var point in results)
            {
                approxSeries.Points.AddXY(point.X, point.ApproxValue);
            }

            chartResults.Series.Add(approxSeries);

            // Analytical results
            if (hasAnalytic)
            {
                var exactSeries = new Series("Analitic")
                {
                    ChartType = SeriesChartType.Line,
                    XValueType = ChartValueType.Double
                };

                foreach (var point in results)
                {
                    if (point.ExactValue.HasValue)
                        exactSeries.Points.AddXY(point.X, point.ExactValue.Value);
                }

                chartResults.Series.Add(exactSeries);
            }
        }
    }
}
