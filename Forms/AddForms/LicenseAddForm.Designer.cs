namespace DataBase.Forms.AddForms
{
    partial class LicenseAddForm
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
            this.buttonAddNameFabricator = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.textBoxPatronymic = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.maskedTextBoxDateOfIssue = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.maskedTextBoxExpiration = new System.Windows.Forms.MaskedTextBox();
            this.textBoxPassport = new System.Windows.Forms.NumericUpDown();
            this.textBoxLicenseNumber = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxPassport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxLicenseNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Номер лицензии";
            // 
            // buttonAddNameFabricator
            // 
            this.buttonAddNameFabricator.Location = new System.Drawing.Point(149, 219);
            this.buttonAddNameFabricator.Name = "buttonAddNameFabricator";
            this.buttonAddNameFabricator.Size = new System.Drawing.Size(75, 23);
            this.buttonAddNameFabricator.TabIndex = 2;
            this.buttonAddNameFabricator.Text = "Добавить";
            this.buttonAddNameFabricator.UseVisualStyleBackColor = true;
            this.buttonAddNameFabricator.Click += new System.EventHandler(this.buttonAddNameFabricator_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Фамилия";
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Location = new System.Drawing.Point(149, 60);
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(120, 20);
            this.textBoxSurname.TabIndex = 4;
            // 
            // textBoxPatronymic
            // 
            this.textBoxPatronymic.Location = new System.Drawing.Point(149, 115);
            this.textBoxPatronymic.Name = "textBoxPatronymic";
            this.textBoxPatronymic.Size = new System.Drawing.Size(120, 20);
            this.textBoxPatronymic.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Отчество";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(149, 86);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(120, 20);
            this.textBoxName.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Имя";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Номер паспорта";
            // 
            // maskedTextBoxDateOfIssue
            // 
            this.maskedTextBoxDateOfIssue.Location = new System.Drawing.Point(149, 167);
            this.maskedTextBoxDateOfIssue.Mask = "00/00/0000";
            this.maskedTextBoxDateOfIssue.Name = "maskedTextBoxDateOfIssue";
            this.maskedTextBoxDateOfIssue.Size = new System.Drawing.Size(120, 20);
            this.maskedTextBoxDateOfIssue.TabIndex = 11;
            this.maskedTextBoxDateOfIssue.ValidatingType = typeof(System.DateTime);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Дата выдачи";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Дата окончания";
            // 
            // maskedTextBoxExpiration
            // 
            this.maskedTextBoxExpiration.Location = new System.Drawing.Point(149, 193);
            this.maskedTextBoxExpiration.Mask = "00/00/0000";
            this.maskedTextBoxExpiration.Name = "maskedTextBoxExpiration";
            this.maskedTextBoxExpiration.Size = new System.Drawing.Size(120, 20);
            this.maskedTextBoxExpiration.TabIndex = 13;
            this.maskedTextBoxExpiration.ValidatingType = typeof(System.DateTime);
            // 
            // textBoxPassport
            // 
            this.textBoxPassport.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.textBoxPassport.Location = new System.Drawing.Point(149, 141);
            this.textBoxPassport.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.textBoxPassport.Name = "textBoxPassport";
            this.textBoxPassport.Size = new System.Drawing.Size(120, 20);
            this.textBoxPassport.TabIndex = 29;
            // 
            // textBoxLicenseNumber
            // 
            this.textBoxLicenseNumber.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.textBoxLicenseNumber.Location = new System.Drawing.Point(149, 32);
            this.textBoxLicenseNumber.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.textBoxLicenseNumber.Name = "textBoxLicenseNumber";
            this.textBoxLicenseNumber.Size = new System.Drawing.Size(120, 20);
            this.textBoxLicenseNumber.TabIndex = 30;
            // 
            // LicenseAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 270);
            this.Controls.Add(this.textBoxLicenseNumber);
            this.Controls.Add(this.textBoxPassport);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.maskedTextBoxExpiration);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.maskedTextBoxDateOfIssue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxPatronymic);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxSurname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonAddNameFabricator);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LicenseAddForm";
            this.Text = "Добавление названия поставщика";
            ((System.ComponentModel.ISupportInitialize)(this.textBoxPassport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxLicenseNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddNameFabricator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.TextBox textBoxPatronymic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxDateOfIssue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxExpiration;
        private System.Windows.Forms.NumericUpDown textBoxPassport;
        private System.Windows.Forms.NumericUpDown textBoxLicenseNumber;
    }
}