namespace ApteanEdgeBank
{
    partial class BankManagerDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BankManagerDashboard));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listCustomersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByCustomerIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCustomerProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readCustomerAccountListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.accountDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reOpenAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.depositToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.withDrawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liabilityAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.readAccDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loanRepaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ledgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readAccountActivityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateAccountBalanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerToolStripMenuItem,
            this.customerManagementToolStripMenuItem,
            this.accountToolStripMenuItem,
            this.liabilityAccountToolStripMenuItem,
            this.ledgerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(858, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.updateToolStripMenuItem});
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.customerToolStripMenuItem.Text = "Customer";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.updateToolStripMenuItem.Text = "Update Customer Profile";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // customerManagementToolStripMenuItem
            // 
            this.customerManagementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listCustomersToolStripMenuItem,
            this.viewCustomerProfileToolStripMenuItem,
            this.readCustomerAccountListToolStripMenuItem});
            this.customerManagementToolStripMenuItem.Name = "customerManagementToolStripMenuItem";
            this.customerManagementToolStripMenuItem.Size = new System.Drawing.Size(145, 20);
            this.customerManagementToolStripMenuItem.Text = "Customer Management";
            // 
            // listCustomersToolStripMenuItem
            // 
            this.listCustomersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortByNameToolStripMenuItem,
            this.sortByCustomerIDToolStripMenuItem});
            this.listCustomersToolStripMenuItem.Name = "listCustomersToolStripMenuItem";
            this.listCustomersToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.listCustomersToolStripMenuItem.Text = "List Customers";
            this.listCustomersToolStripMenuItem.Click += new System.EventHandler(this.listCustomersToolStripMenuItem_Click);
            // 
            // sortByNameToolStripMenuItem
            // 
            this.sortByNameToolStripMenuItem.Name = "sortByNameToolStripMenuItem";
            this.sortByNameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sortByNameToolStripMenuItem.Text = "Sort by Name";
            this.sortByNameToolStripMenuItem.Click += new System.EventHandler(this.sortByNameToolStripMenuItem_Click);
            // 
            // sortByCustomerIDToolStripMenuItem
            // 
            this.sortByCustomerIDToolStripMenuItem.Name = "sortByCustomerIDToolStripMenuItem";
            this.sortByCustomerIDToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sortByCustomerIDToolStripMenuItem.Text = "Sort by Customer ID";
            this.sortByCustomerIDToolStripMenuItem.Click += new System.EventHandler(this.sortByCustomerIDToolStripMenuItem_Click);
            // 
            // viewCustomerProfileToolStripMenuItem
            // 
            this.viewCustomerProfileToolStripMenuItem.Name = "viewCustomerProfileToolStripMenuItem";
            this.viewCustomerProfileToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.viewCustomerProfileToolStripMenuItem.Text = "View Customer Profile";
            this.viewCustomerProfileToolStripMenuItem.Click += new System.EventHandler(this.viewCustomerProfileToolStripMenuItem_Click);
            // 
            // readCustomerAccountListToolStripMenuItem
            // 
            this.readCustomerAccountListToolStripMenuItem.Name = "readCustomerAccountListToolStripMenuItem";
            this.readCustomerAccountListToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.readCustomerAccountListToolStripMenuItem.Text = "Read Customer Account List";
            this.readCustomerAccountListToolStripMenuItem.Click += new System.EventHandler(this.readCustomerAccountListToolStripMenuItem_Click);
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem1,
            this.accountDetailsToolStripMenuItem,
            this.closeAccountToolStripMenuItem,
            this.reOpenAccountToolStripMenuItem,
            this.depositToolStripMenuItem,
            this.withDrawToolStripMenuItem});
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.accountToolStripMenuItem.Text = "Account";
            // 
            // newToolStripMenuItem1
            // 
            this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            this.newToolStripMenuItem1.Size = new System.Drawing.Size(178, 22);
            this.newToolStripMenuItem1.Text = "New";
            this.newToolStripMenuItem1.Click += new System.EventHandler(this.newToolStripMenuItem1_Click);
            // 
            // accountDetailsToolStripMenuItem
            // 
            this.accountDetailsToolStripMenuItem.Name = "accountDetailsToolStripMenuItem";
            this.accountDetailsToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.accountDetailsToolStripMenuItem.Text = "List Account Details";
            this.accountDetailsToolStripMenuItem.Click += new System.EventHandler(this.accountDetailsToolStripMenuItem_Click);
            // 
            // closeAccountToolStripMenuItem
            // 
            this.closeAccountToolStripMenuItem.Name = "closeAccountToolStripMenuItem";
            this.closeAccountToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.closeAccountToolStripMenuItem.Text = "Close Account";
            this.closeAccountToolStripMenuItem.Click += new System.EventHandler(this.closeAccountToolStripMenuItem_Click);
            // 
            // reOpenAccountToolStripMenuItem
            // 
            this.reOpenAccountToolStripMenuItem.Name = "reOpenAccountToolStripMenuItem";
            this.reOpenAccountToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.reOpenAccountToolStripMenuItem.Text = "Re-Open Account";
            this.reOpenAccountToolStripMenuItem.Click += new System.EventHandler(this.reOpenAccountToolStripMenuItem_Click);
            // 
            // depositToolStripMenuItem
            // 
            this.depositToolStripMenuItem.Name = "depositToolStripMenuItem";
            this.depositToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.depositToolStripMenuItem.Text = "Deposit";
            this.depositToolStripMenuItem.Click += new System.EventHandler(this.depositToolStripMenuItem_Click);
            // 
            // withDrawToolStripMenuItem
            // 
            this.withDrawToolStripMenuItem.Name = "withDrawToolStripMenuItem";
            this.withDrawToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.withDrawToolStripMenuItem.Text = "WithDraw";
            this.withDrawToolStripMenuItem.Click += new System.EventHandler(this.withDrawToolStripMenuItem_Click);
            // 
            // liabilityAccountToolStripMenuItem
            // 
            this.liabilityAccountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem2,
            this.readAccDetailsToolStripMenuItem,
            this.iToolStripMenuItem,
            this.loanRepaymentToolStripMenuItem});
            this.liabilityAccountToolStripMenuItem.Name = "liabilityAccountToolStripMenuItem";
            this.liabilityAccountToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.liabilityAccountToolStripMenuItem.Text = "Liability Account";
            // 
            // newToolStripMenuItem2
            // 
            this.newToolStripMenuItem2.Name = "newToolStripMenuItem2";
            this.newToolStripMenuItem2.Size = new System.Drawing.Size(164, 22);
            this.newToolStripMenuItem2.Text = "New";
            // 
            // readAccDetailsToolStripMenuItem
            // 
            this.readAccDetailsToolStripMenuItem.Name = "readAccDetailsToolStripMenuItem";
            this.readAccDetailsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.readAccDetailsToolStripMenuItem.Text = "Read Acc. Details";
            // 
            // iToolStripMenuItem
            // 
            this.iToolStripMenuItem.Name = "iToolStripMenuItem";
            this.iToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.iToolStripMenuItem.Text = "Issue Loan";
            // 
            // loanRepaymentToolStripMenuItem
            // 
            this.loanRepaymentToolStripMenuItem.Name = "loanRepaymentToolStripMenuItem";
            this.loanRepaymentToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.loanRepaymentToolStripMenuItem.Text = "Loan Repayment";
            // 
            // ledgerToolStripMenuItem
            // 
            this.ledgerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readAccountActivityToolStripMenuItem,
            this.calculateAccountBalanceToolStripMenuItem});
            this.ledgerToolStripMenuItem.Name = "ledgerToolStripMenuItem";
            this.ledgerToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.ledgerToolStripMenuItem.Text = "Ledger";
            // 
            // readAccountActivityToolStripMenuItem
            // 
            this.readAccountActivityToolStripMenuItem.Name = "readAccountActivityToolStripMenuItem";
            this.readAccountActivityToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.readAccountActivityToolStripMenuItem.Text = "Read Account Activity";
            // 
            // calculateAccountBalanceToolStripMenuItem
            // 
            this.calculateAccountBalanceToolStripMenuItem.Name = "calculateAccountBalanceToolStripMenuItem";
            this.calculateAccountBalanceToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.calculateAccountBalanceToolStripMenuItem.Text = "Calculate Account Balance";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Finance-Insurance-Graphics-300x210.png");
            this.imageList1.Images.SetKeyName(1, "Fotolia_32116767_Subscription_XXL.jpg");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::ApteanEdgeBank.Properties.Resources.Fotolia_32116767_Subscription_XXL;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(858, 443);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Algerian", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome To Aptean Edge Bank";
            // 
            // BankManagerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 467);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "BankManagerDashboard";
            this.Text = "Bank Manager : Customer Management";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listCustomersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortByNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortByCustomerIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewCustomerProfileToolStripMenuItem;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStripMenuItem readCustomerAccountListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem accountDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reOpenAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem depositToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem withDrawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liabilityAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem readAccDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loanRepaymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ledgerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readAccountActivityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculateAccountBalanceToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}