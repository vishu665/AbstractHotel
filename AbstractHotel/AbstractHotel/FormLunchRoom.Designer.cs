namespace AbstractHotel
{
    partial class FormLunchRoom
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.comboBoxLunch = new System.Windows.Forms.ComboBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelBlank = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(314, 102);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(136, 28);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(141, 102);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(136, 28);
            this.buttonSave.TabIndex = 16;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(120, 63);
            this.textBoxCount.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(329, 22);
            this.textBoxCount.TabIndex = 15;
            this.textBoxCount.TextChanged += new System.EventHandler(this.textBoxCount_TextChanged);
            // 
            // comboBoxLunch
            // 
            this.comboBoxLunch.FormattingEnabled = true;
            this.comboBoxLunch.Location = new System.Drawing.Point(120, 22);
            this.comboBoxLunch.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxLunch.Name = "comboBoxLunch";
            this.comboBoxLunch.Size = new System.Drawing.Size(329, 24);
            this.comboBoxLunch.TabIndex = 14;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(17, 66);
            this.labelCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(90, 17);
            this.labelCount.TabIndex = 13;
            this.labelCount.Text = "Количество:";
            // 
            // labelBlank
            // 
            this.labelBlank.AutoSize = true;
            this.labelBlank.Location = new System.Drawing.Point(17, 26);
            this.labelBlank.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBlank.Name = "labelBlank";
            this.labelBlank.Size = new System.Drawing.Size(57, 17);
            this.labelBlank.TabIndex = 12;
            this.labelBlank.Text = "Обеды:";
            // 
            // FormLunchRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 148);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.comboBoxLunch);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelBlank);
            this.Name = "FormLunchRoom";
            this.Text = "Номера";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.ComboBox comboBoxLunch;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelBlank;
    }
}