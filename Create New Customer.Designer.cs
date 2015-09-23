namespace ApteanEdgeBank
{
    partial class Create_New_Customer
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
            this.firstNameBox = new System.Windows.Forms.TextBox();
            this.lastNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.addTupleButton = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.dateOfBirthBox = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.contactNumberBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // firstNameBox
            // 
            this.firstNameBox.Location = new System.Drawing.Point(202, 38);
            this.firstNameBox.Name = "firstNameBox";
            this.firstNameBox.Size = new System.Drawing.Size(227, 20);
            this.firstNameBox.TabIndex = 0;
            // 
            // lastNameBox
            // 
            this.lastNameBox.Location = new System.Drawing.Point(202, 134);
            this.lastNameBox.Name = "lastNameBox";
            this.lastNameBox.Size = new System.Drawing.Size(227, 20);
            this.lastNameBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(99, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(83, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Last Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(83, 294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Date Of Birth";
            // 
            // addTupleButton
            // 
            this.addTupleButton.Location = new System.Drawing.Point(628, 465);
            this.addTupleButton.Name = "addTupleButton";
            this.addTupleButton.Size = new System.Drawing.Size(75, 23);
            this.addTupleButton.TabIndex = 8;
            this.addTupleButton.Text = "Add";
            this.addTupleButton.UseVisualStyleBackColor = true;
            this.addTupleButton.Click += new System.EventHandler(this.addTupleButton_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(202, 326);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 7;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // dateOfBirthBox
            // 
            this.dateOfBirthBox.Location = new System.Drawing.Point(202, 294);
            this.dateOfBirthBox.Name = "dateOfBirthBox";
            this.dateOfBirthBox.Size = new System.Drawing.Size(227, 20);
            this.dateOfBirthBox.TabIndex = 5;
            this.dateOfBirthBox.Click += new System.EventHandler(this.dateOfBirthBox_Click);
            this.dateOfBirthBox.CursorChanged += new System.EventHandler(this.dateOfBirthBox_CursorChanged);
            this.dateOfBirthBox.TabIndexChanged += new System.EventHandler(this.dateOfBirthBox_TabIndexChanged);
            this.dateOfBirthBox.TextChanged += new System.EventHandler(this.dateOfBirthBox_TextChanged);
            this.dateOfBirthBox.Enter += new System.EventHandler(this.dateOfBirthBox_Enter);
            this.dateOfBirthBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dateOfBirthBox_KeyPress);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(463, 298);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(52, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Minor";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // contactNumberBox
            // 
            this.contactNumberBox.Location = new System.Drawing.Point(202, 214);
            this.contactNumberBox.Name = "contactNumberBox";
            this.contactNumberBox.Size = new System.Drawing.Size(227, 20);
            this.contactNumberBox.TabIndex = 3;
            this.contactNumberBox.TextChanged += new System.EventHandler(this.contactNumberBox_TextChanged);
            this.contactNumberBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.contactNumberBox_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(60, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Contact Number";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(481, 214);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Add Another";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Create_New_Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 549);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.contactNumberBox);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.dateOfBirthBox);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.addTupleButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lastNameBox);
            this.Controls.Add(this.firstNameBox);
            this.Name = "Create_New_Customer";
            this.Text = "Create_New_Customer";
            this.Load += new System.EventHandler(this.Create_New_Customer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox firstNameBox;
        private System.Windows.Forms.TextBox lastNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addTupleButton;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.TextBox dateOfBirthBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox contactNumberBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}