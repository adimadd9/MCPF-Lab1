namespace SRV_Lab1
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            lblEquation = new Label();
            txtEquation = new TextBox();
            lblX0 = new Label();
            txtX0 = new TextBox();
            lblU0 = new Label();
            txtU0 = new TextBox();
            lblXEnd = new Label();
            txtXEnd = new TextBox();
            lblStep = new Label();
            txtStep = new TextBox();
            txtAnalytic = new TextBox();
            lblAnalytic = new Label();
            lblMethod = new Label();
            cmbMethod = new ComboBox();
            btnCalculate = new Button();
            dgvResults = new DataGridView();
            chartResults = new System.Windows.Forms.DataVisualization.Charting.Chart();
            grpInput = new GroupBox();
            splitResults = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartResults).BeginInit();
            grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitResults).BeginInit();
            splitResults.Panel1.SuspendLayout();
            splitResults.Panel2.SuspendLayout();
            splitResults.SuspendLayout();
            SuspendLayout();
            // 
            // lblEquation
            // 
            lblEquation.AutoSize = true;
            lblEquation.Location = new Point(15, 25);
            lblEquation.Name = "lblEquation";
            lblEquation.Size = new Size(106, 20);
            lblEquation.TabIndex = 0;
            lblEquation.Text = "du/dx = f(u, x):";
            lblEquation.Click += lblEquation_Click;
            // 
            // txtEquation
            // 
            txtEquation.Location = new Point(130, 22);
            txtEquation.Name = "txtEquation";
            txtEquation.Size = new Size(400, 27);
            txtEquation.TabIndex = 1;
            // 
            // lblX0
            // 
            lblX0.AutoSize = true;
            lblX0.Location = new Point(32, 60);
            lblX0.Name = "lblX0";
            lblX0.Size = new Size(27, 20);
            lblX0.TabIndex = 2;
            lblX0.Text = "x0:";
            lblX0.Click += label1_Click;
            // 
            // txtX0
            // 
            txtX0.Location = new Point(70, 57);
            txtX0.Name = "txtX0";
            txtX0.Size = new Size(80, 27);
            txtX0.TabIndex = 3;
            // 
            // lblU0
            // 
            lblU0.AutoSize = true;
            lblU0.Location = new Point(172, 60);
            lblU0.Name = "lblU0";
            lblU0.Size = new Size(28, 20);
            lblU0.TabIndex = 4;
            lblU0.Text = "u0:";
            // 
            // txtU0
            // 
            txtU0.Location = new Point(210, 57);
            txtU0.Name = "txtU0";
            txtU0.Size = new Size(80, 27);
            txtU0.TabIndex = 5;
            // 
            // lblXEnd
            // 
            lblXEnd.AutoSize = true;
            lblXEnd.Location = new Point(15, 95);
            lblXEnd.Name = "lblXEnd";
            lblXEnd.Size = new Size(44, 20);
            lblXEnd.TabIndex = 6;
            lblXEnd.Text = "xEnd:";
            lblXEnd.Click += label1_Click_1;
            // 
            // txtXEnd
            // 
            txtXEnd.Location = new Point(70, 92);
            txtXEnd.Name = "txtXEnd";
            txtXEnd.Size = new Size(80, 27);
            txtXEnd.TabIndex = 7;
            // 
            // lblStep
            // 
            lblStep.AutoSize = true;
            lblStep.Location = new Point(180, 95);
            lblStep.Name = "lblStep";
            lblStep.Size = new Size(20, 20);
            lblStep.TabIndex = 8;
            lblStep.Text = "h:";
            lblStep.Click += lblStep_Click;
            // 
            // txtStep
            // 
            txtStep.Location = new Point(210, 92);
            txtStep.Name = "txtStep";
            txtStep.Size = new Size(80, 27);
            txtStep.TabIndex = 9;
            // 
            // txtAnalytic
            // 
            txtAnalytic.Location = new Point(230, 127);
            txtAnalytic.Name = "txtAnalytic";
            txtAnalytic.Size = new Size(290, 27);
            txtAnalytic.TabIndex = 10;
            txtAnalytic.TextChanged += textBox1_TextChanged;
            // 
            // lblAnalytic
            // 
            lblAnalytic.AutoSize = true;
            lblAnalytic.Location = new Point(15, 130);
            lblAnalytic.Name = "lblAnalytic";
            lblAnalytic.Size = new Size(188, 20);
            lblAnalytic.TabIndex = 11;
            lblAnalytic.Text = "Solutia analitica (optional):";
            // 
            // lblMethod
            // 
            lblMethod.AutoSize = true;
            lblMethod.Location = new Point(15, 168);
            lblMethod.Name = "lblMethod";
            lblMethod.Size = new Size(129, 20);
            lblMethod.TabIndex = 12;
            lblMethod.Text = "Metoda numerica:";
            lblMethod.Click += label1_Click_2;
            // 
            // cmbMethod
            // 
            cmbMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMethod.FormattingEnabled = true;
            cmbMethod.Items.AddRange(new object[] { "Metoda Euler", "Metoda Euler modificata", "Metoda Runge-Kutta de ordinul 4" });
            cmbMethod.Location = new Point(150, 165);
            cmbMethod.Name = "cmbMethod";
            cmbMethod.Size = new Size(220, 28);
            cmbMethod.TabIndex = 13;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(400, 165);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(120, 29);
            btnCalculate.TabIndex = 14;
            btnCalculate.Text = "Calculeaza";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // dgvResults
            // 
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AllowUserToDeleteRows = false;
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Dock = DockStyle.Fill;
            dgvResults.Location = new Point(0, 0);
            dgvResults.Name = "dgvResults";
            dgvResults.ReadOnly = true;
            dgvResults.RowHeadersWidth = 51;
            dgvResults.Size = new Size(453, 443);
            dgvResults.TabIndex = 15;
            // 
            // chartResults
            // 
            chartArea1.Name = "MainArea";
            chartResults.ChartAreas.Add(chartArea1);
            chartResults.Dock = DockStyle.Fill;
            legend1.Name = "Legend";
            chartResults.Legends.Add(legend1);
            chartResults.Location = new Point(0, 0);
            chartResults.Name = "chartResults";
            series1.ChartArea = "MainArea";
            series1.Legend = "Legend";
            series1.Name = "Series1";
            chartResults.Series.Add(series1);
            chartResults.Size = new Size(525, 443);
            chartResults.TabIndex = 16;
            chartResults.Text = "chart1";
            // 
            // grpInput
            // 
            grpInput.Controls.Add(lblEquation);
            grpInput.Controls.Add(txtEquation);
            grpInput.Controls.Add(lblX0);
            grpInput.Controls.Add(btnCalculate);
            grpInput.Controls.Add(txtX0);
            grpInput.Controls.Add(cmbMethod);
            grpInput.Controls.Add(txtU0);
            grpInput.Controls.Add(lblMethod);
            grpInput.Controls.Add(lblU0);
            grpInput.Controls.Add(lblAnalytic);
            grpInput.Controls.Add(lblXEnd);
            grpInput.Controls.Add(txtAnalytic);
            grpInput.Controls.Add(txtStep);
            grpInput.Controls.Add(txtXEnd);
            grpInput.Controls.Add(lblStep);
            grpInput.Dock = DockStyle.Top;
            grpInput.Location = new Point(0, 0);
            grpInput.Name = "grpInput";
            grpInput.Size = new Size(982, 210);
            grpInput.TabIndex = 17;
            grpInput.TabStop = false;
            grpInput.Text = "Date de intrare";
            // 
            // splitResults
            // 
            splitResults.Dock = DockStyle.Fill;
            splitResults.Location = new Point(0, 210);
            splitResults.Name = "splitResults";
            // 
            // splitResults.Panel1
            // 
            splitResults.Panel1.Controls.Add(dgvResults);
            // 
            // splitResults.Panel2
            // 
            splitResults.Panel2.Controls.Add(chartResults);
            splitResults.Size = new Size(982, 443);
            splitResults.SplitterDistance = 453;
            splitResults.TabIndex = 18;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 653);
            Controls.Add(splitResults);
            Controls.Add(grpInput);
            Name = "MainForm";
            Text = "Doncila Denis Lab1";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartResults).EndInit();
            grpInput.ResumeLayout(false);
            grpInput.PerformLayout();
            splitResults.Panel1.ResumeLayout(false);
            splitResults.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitResults).EndInit();
            splitResults.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblEquation;
        private TextBox txtEquation;
        private Label lblX0;
        private TextBox txtX0;
        private Label lblU0;
        private TextBox txtU0;
        private Label lblXEnd;
        private TextBox txtXEnd;
        private Label lblStep;
        private TextBox txtStep;
        private TextBox txtAnalytic;
        private Label lblAnalytic;
        private Label lblMethod;
        private ComboBox cmbMethod;
        private Button btnCalculate;
        private DataGridView dgvResults;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartResults;
        private GroupBox grpInput;
        private SplitContainer splitResults;
    }
}
