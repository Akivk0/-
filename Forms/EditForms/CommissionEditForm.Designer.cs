namespace DataBase.Forms.EditForms
{
    partial class CommissionEditForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxWeapon = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.maskedTextBoxDate = new System.Windows.Forms.MaskedTextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxPatronymic = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.NumericUpDown();
            this.textBoxPassport = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxPassport)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Отчество";
            // 
            // buttonAddNameFabricator
            // 
            this.buttonAddNameFabricator.Location = new System.Drawing.Point(148, 206);
            this.buttonAddNameFabricator.Name = "buttonAddNameFabricator";
            this.buttonAddNameFabricator.Size = new System.Drawing.Size(75, 23);
            this.buttonAddNameFabricator.TabIndex = 2;
            this.buttonAddNameFabricator.Text = "Изменить";
            this.buttonAddNameFabricator.UseVisualStyleBackColor = true;
            this.buttonAddNameFabricator.Click += new System.EventHandler(this.buttonAddNameFabricator_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Номер паспорта";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Имя";
            // 
            // textBoxWeapon
            // 
            this.textBoxWeapon.Location = new System.Drawing.Point(148, 19);
            this.textBoxWeapon.Name = "textBoxWeapon";
            this.textBoxWeapon.Size = new System.Drawing.Size(121, 20);
            this.textBoxWeapon.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Номер оружия";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Когда приняли";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Стоимость покупки";
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Location = new System.Drawing.Point(148, 97);
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(121, 20);
            this.textBoxSurname.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Фамилия";
            // 
            // maskedTextBoxDate
            // 
            this.maskedTextBoxDate.Location = new System.Drawing.Point(148, 45);
            this.maskedTextBoxDate.Mask = "00/00/0000";
            this.maskedTextBoxDate.Name = "maskedTextBoxDate";
            this.maskedTextBoxDate.Size = new System.Drawing.Size(121, 20);
            this.maskedTextBoxDate.TabIndex = 24;
            this.maskedTextBoxDate.ValidatingType = typeof(System.DateTime);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(148, 124);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(121, 20);
            this.textBoxName.TabIndex = 25;
            // 
            // textBoxPatronymic
            // 
            this.textBoxPatronymic.Location = new System.Drawing.Point(148, 150);
            this.textBoxPatronymic.Name = "textBoxPatronymic";
            this.textBoxPatronymic.Size = new System.Drawing.Size(121, 20);
            this.textBoxPatronymic.TabIndex = 26;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.textBoxPrice.Location = new System.Drawing.Point(148, 73);
            this.textBoxPrice.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(120, 20);
            this.textBoxPrice.TabIndex = 36;
            // 
            // textBoxPassport
            // 
            this.textBoxPassport.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.textBoxPassport.Location = new System.Drawing.Point(149, 180);
            this.textBoxPassport.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.textBoxPassport.Name = "textBoxPassport";
            this.textBoxPassport.Size = new System.Drawing.Size(120, 20);
            this.textBoxPassport.TabIndex = 37;
            // 
            // CommissionEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 239);
            this.Controls.Add(this.textBoxPassport);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.textBoxPatronymic);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.maskedTextBoxDate);
            this.Controls.Add(this.textBoxSurname);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxWeapon);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonAddNameFabricator);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CommissionEditForm";
            this.Text = "Изменение комиссионного оружия";
            this.Load += new System.EventHandler(this.CommissionAddForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textBoxPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxPassport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddNameFabricator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxWeapon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxDate;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPatronymic;
        private System.Windows.Forms.NumericUpDown textBoxPrice;
        private System.Windows.Forms.NumericUpDown textBoxPassport;
    }
}