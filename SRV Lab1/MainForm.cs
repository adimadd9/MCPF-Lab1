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

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void lblStep_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void lblEquation_Click(object sender, EventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // 1. Citim si validam input-ul
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
            if (xEnd <= x0)
            {
                MessageBox.Show("xEnd trebuie sa fie mai mare decat x0.");
                return;
            }

            // 2. Construim obiectul problemei
            var problem = new CauchyProblem
            {
                EquationText = txtEquation.Text,
                X0 = x0,
                U0 = u0,
                XEnd = xEnd,
                Step = step,
                AnalyticSolutionText = txtAnalytic.Text
            };

            // 3. Alegem metoda (deocamdata doar Euler, hardcodat)
            INumericMethod method = new EulerMethod();

            // 4. Calculam
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

            // 5. Completam solutia analitica si eroarea, daca exista
            if (problem.HasAnalyticSolution)
            {
                foreach (var point in results)
                {
                    double exact = ExpressionEvaluator.Evaluate(problem.AnalyticSolutionText!, point.X, 0);
                    point.ExactValue = exact;
                    point.Error = Math.Abs(exact - point.ApproxValue);
                }
            }

            // 6. Afisam in tabel si grafic (le facem la pasii urmatori)
            PopulateGrid(results, problem.HasAnalyticSolution);
            PopulateChart(results, problem.HasAnalyticSolution);
        }

        private void PopulateGrid(List<ResultPoint> results, bool hasAnalytic)
        {
            // Curatam tabelul complet (coloane vechi + randuri vechi)
            dgvResults.Columns.Clear();
            dgvResults.Rows.Clear();

            // Definim coloanele
            dgvResults.Columns.Add("colX", "x");
            dgvResults.Columns.Add("colApprox", "u aproximativ");

            if (hasAnalytic)
            {
                dgvResults.Columns.Add("colExact", "u exact");
                dgvResults.Columns.Add("colError", "Eroare");
            }

            // Populam randurile
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

            foreach (var point in results)
            {
                approxSeries.Points.AddXY(point.X, point.ApproxValue);
            }

            chartResults.Series.Add(approxSeries);

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
