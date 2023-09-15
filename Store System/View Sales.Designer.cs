
namespace Store_System
{
    partial class View_Sales
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_billNo2 = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_findBill = new Guna.UI2.WinForms.Guna2Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 33);
            this.label1.TabIndex = 84;
            this.label1.Text = "Print Bill";
            // 
            // txt_billNo2
            // 
            this.txt_billNo2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_billNo2.BorderRadius = 18;
            this.txt_billNo2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_billNo2.DefaultText = "";
            this.txt_billNo2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_billNo2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_billNo2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_billNo2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_billNo2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_billNo2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_billNo2.ForeColor = System.Drawing.Color.Black;
            this.txt_billNo2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_billNo2.Location = new System.Drawing.Point(97, 67);
            this.txt_billNo2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_billNo2.Name = "txt_billNo2";
            this.txt_billNo2.PasswordChar = '\0';
            this.txt_billNo2.PlaceholderText = "";
            this.txt_billNo2.SelectedText = "";
            this.txt_billNo2.Size = new System.Drawing.Size(142, 36);
            this.txt_billNo2.TabIndex = 86;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 85;
            this.label3.Text = "Bill No";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_findBill
            // 
            this.btn_findBill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_findBill.BorderColor = System.Drawing.Color.Teal;
            this.btn_findBill.BorderRadius = 18;
            this.btn_findBill.BorderThickness = 1;
            this.btn_findBill.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_findBill.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_findBill.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_findBill.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_findBill.FillColor = System.Drawing.Color.Teal;
            this.btn_findBill.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_findBill.ForeColor = System.Drawing.Color.White;
            this.btn_findBill.HoverState.BorderColor = System.Drawing.Color.Teal;
            this.btn_findBill.HoverState.FillColor = System.Drawing.Color.White;
            this.btn_findBill.HoverState.ForeColor = System.Drawing.Color.Teal;
            this.btn_findBill.Location = new System.Drawing.Point(246, 67);
            this.btn_findBill.Name = "btn_findBill";
            this.btn_findBill.Size = new System.Drawing.Size(113, 36);
            this.btn_findBill.TabIndex = 88;
            this.btn_findBill.Text = "Find";
            this.btn_findBill.Click += new System.EventHandler(this.btn_findBill_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.Location = new System.Drawing.Point(41, 128);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(999, 543);
            this.reportViewer1.TabIndex = 89;
            // 
            // View_Sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1080, 708);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btn_findBill);
            this.Controls.Add(this.txt_billNo2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "View_Sales";
            this.Text = "View_Sales";
            this.Load += new System.EventHandler(this.View_Sales_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txt_billNo2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button btn_findBill;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}