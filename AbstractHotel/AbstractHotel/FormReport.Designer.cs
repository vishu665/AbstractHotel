namespace AbstractHotel
{
    partial class FormReport
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
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.labelTo = new System.Windows.Forms.Label();
            this.labelFrom = new System.Windows.Forms.Label();
            this.buttonReport = new System.Windows.Forms.Button();
            this.buttonMake = new System.Windows.Forms.Button();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(251, 13);
            this.dateTimePickerTo.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(161, 22);
            this.dateTimePickerTo.TabIndex = 19;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(41, 13);
            this.dateTimePickerFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(165, 22);
            this.dateTimePickerFrom.TabIndex = 18;
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(214, 18);
            this.labelTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(29, 17);
            this.labelTo.TabIndex = 17;
            this.labelTo.Text = "ПО";
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Location = new System.Drawing.Point(16, 18);
            this.labelFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(17, 17);
            this.labelFrom.TabIndex = 16;
            this.labelFrom.Text = "C";
            // 
            // buttonReport
            // 
            this.buttonReport.Location = new System.Drawing.Point(155, 56);
            this.buttonReport.Margin = new System.Windows.Forms.Padding(4);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(160, 29);
            this.buttonReport.TabIndex = 21;
            this.buttonReport.Text = "Сформировать";
            this.buttonReport.UseVisualStyleBackColor = true;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // buttonMake
            // 
            this.buttonMake.Location = new System.Drawing.Point(689, 33);
            this.buttonMake.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMake.Name = "buttonMake";
            this.buttonMake.Size = new System.Drawing.Size(223, 52);
            this.buttonMake.TabIndex = 20;
            this.buttonMake.Text = "Отправить на почту";
            this.buttonMake.UseVisualStyleBackColor = true;
            this.buttonMake.Click += new System.EventHandler(this.buttonMake_Click);
            // 
            // reportViewer
            // 
            this.reportViewer.LocalReport.ReportEmbeddedResource = "AbstractHotel.Report.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(13, 110);
            this.reportViewer.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(899, 327);
            this.reportViewer.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(437, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 34);
            this.label1.TabIndex = 28;
            this.label1.Text = "Введите почту для \r\nотправки на нее отчета";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(440, 46);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(231, 22);
            this.textBoxEmail.TabIndex = 27;
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.buttonReport);
            this.Controls.Add(this.buttonMake);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.labelTo);
            this.Controls.Add(this.labelFrom);
            this.Name = "FormReport";
            this.Text = "Отчет";
            this.Load += new System.EventHandler(this.FormReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.Button buttonMake;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxEmail;
    }
}