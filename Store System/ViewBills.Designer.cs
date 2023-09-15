
namespace Store_System
{
    partial class ViewBills
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.BillBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pharmacyDataSet = new Store_System.pharmacyDataSet();
            this.btn_Viewbills = new Guna.UI2.WinForms.Guna2Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.dt_from = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dt_to = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.BillTableAdapter = new Store_System.pharmacyDataSetTableAdapters.BillTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.BillBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pharmacyDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // BillBindingSource
            // 
            this.BillBindingSource.DataMember = "Bill";
            this.BillBindingSource.DataSource = this.pharmacyDataSet;
            // 
            // pharmacyDataSet
            // 
            this.pharmacyDataSet.DataSetName = "pharmacyDataSet";
            this.pharmacyDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btn_Viewbills
            // 
            this.btn_Viewbills.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Viewbills.BorderColor = System.Drawing.Color.Teal;
            this.btn_Viewbills.BorderRadius = 15;
            this.btn_Viewbills.BorderThickness = 1;
            this.btn_Viewbills.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Viewbills.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Viewbills.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Viewbills.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Viewbills.FillColor = System.Drawing.Color.Teal;
            this.btn_Viewbills.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Viewbills.ForeColor = System.Drawing.Color.White;
            this.btn_Viewbills.HoverState.BorderColor = System.Drawing.Color.Teal;
            this.btn_Viewbills.HoverState.FillColor = System.Drawing.Color.White;
            this.btn_Viewbills.HoverState.ForeColor = System.Drawing.Color.Teal;
            this.btn_Viewbills.Location = new System.Drawing.Point(713, 46);
            this.btn_Viewbills.Name = "btn_Viewbills";
            this.btn_Viewbills.Size = new System.Drawing.Size(111, 33);
            this.btn_Viewbills.TabIndex = 88;
            this.btn_Viewbills.Text = "View Bills";
            this.btn_Viewbills.Click += new System.EventHandler(this.btn_Viewbills_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.BackColor = System.Drawing.Color.LightGray;
            this.reportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.BillBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Store_System.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(39, 114);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1002, 558);
            this.reportViewer1.TabIndex = 90;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 91;
            this.label1.Text = "From";
            // 
            // dt_from
            // 
            this.dt_from.Checked = true;
            this.dt_from.FillColor = System.Drawing.Color.White;
            this.dt_from.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dt_from.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dt_from.Location = new System.Drawing.Point(286, 46);
            this.dt_from.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dt_from.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dt_from.Name = "dt_from";
            this.dt_from.Size = new System.Drawing.Size(189, 33);
            this.dt_from.TabIndex = 92;
            this.dt_from.Value = new System.DateTime(2022, 10, 9, 20, 22, 52, 95);
            // 
            // dt_to
            // 
            this.dt_to.Checked = true;
            this.dt_to.FillColor = System.Drawing.Color.White;
            this.dt_to.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dt_to.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dt_to.Location = new System.Drawing.Point(518, 46);
            this.dt_to.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dt_to.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dt_to.Name = "dt_to";
            this.dt_to.Size = new System.Drawing.Size(189, 33);
            this.dt_to.TabIndex = 94;
            this.dt_to.Value = new System.DateTime(2022, 10, 9, 20, 22, 52, 95);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(493, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 93;
            this.label2.Text = "To";
            // 
            // BillTableAdapter
            // 
            this.BillTableAdapter.ClearBeforeFill = true;
            // 
            // ViewBills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1080, 708);
            this.Controls.Add(this.dt_to);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dt_from);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btn_Viewbills);
            this.Name = "ViewBills";
            this.Text = "ViewBills";
            this.Load += new System.EventHandler(this.ViewBills_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BillBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pharmacyDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btn_Viewbills;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dt_from;
        private Guna.UI2.WinForms.Guna2DateTimePicker dt_to;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource BillBindingSource;
        private pharmacyDataSet pharmacyDataSet;
        private pharmacyDataSetTableAdapters.BillTableAdapter BillTableAdapter;
    }
}