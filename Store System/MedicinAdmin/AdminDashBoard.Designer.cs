
namespace Store_System.MedicinAdmin
{
    partial class frm_adminDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.All_Medicines = new Guna.Charts.WinForms.GunaAreaDataset();
            this.Valid_Medicine = new Guna.Charts.WinForms.GunaAreaDataset();
            this.Expire_Soon_Medicines = new Guna.Charts.WinForms.GunaAreaDataset();
            this.Expired_Medicine = new Guna.Charts.WinForms.GunaAreaDataset();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(38, 72);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.LightSkyBlue;
            series1.Legend = "Legend1";
            series1.Name = "All Medicines";
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.DarkCyan;
            series2.Legend = "Legend1";
            series2.Name = "Valid Medicine";
            series3.ChartArea = "ChartArea1";
            series3.Color = System.Drawing.Color.DarkSalmon;
            series3.Legend = "Legend1";
            series3.Name = "Expire Soon Medicines";
            series4.ChartArea = "ChartArea1";
            series4.Color = System.Drawing.Color.Firebrick;
            series4.Legend = "Legend1";
            series4.Name = "Expired Medicine";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(1006, 618);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 40);
            this.label1.TabIndex = 6;
            this.label1.Text = "Dashbord";
            // 
            // All_Medicines
            // 
            this.All_Medicines.BorderColor = System.Drawing.Color.Empty;
            this.All_Medicines.FillColor = System.Drawing.Color.SkyBlue;
            this.All_Medicines.Label = "All Medicines";
            // 
            // Valid_Medicine
            // 
            this.Valid_Medicine.BorderColor = System.Drawing.Color.Empty;
            this.Valid_Medicine.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Valid_Medicine.Label = "Area2";
            // 
            // Expire_Soon_Medicines
            // 
            this.Expire_Soon_Medicines.BorderColor = System.Drawing.Color.Empty;
            this.Expire_Soon_Medicines.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Expire_Soon_Medicines.Label = "Area3";
            // 
            // Expired_Medicine
            // 
            this.Expired_Medicine.BorderColor = System.Drawing.Color.Empty;
            this.Expired_Medicine.FillColor = System.Drawing.Color.Red;
            this.Expired_Medicine.Label = "Area4";
            // 
            // frm_adminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1080, 708);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label1);
            this.Name = "frm_adminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminDashBoard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_adminDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;
        private Guna.Charts.WinForms.GunaAreaDataset All_Medicines;
        private Guna.Charts.WinForms.GunaAreaDataset Valid_Medicine;
        private Guna.Charts.WinForms.GunaAreaDataset Expire_Soon_Medicines;
        private Guna.Charts.WinForms.GunaAreaDataset Expired_Medicine;
    }
}