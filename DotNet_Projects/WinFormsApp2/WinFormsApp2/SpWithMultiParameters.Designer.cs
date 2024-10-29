namespace WinFormsApp2
{
    partial class SpWithMultiParameters
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
            textEmpName = new TextBox();
            lblEmpName = new Label();
            btnInsert = new Button();
            lblEmpId = new Label();
            txtEmpDesig = new TextBox();
            txtEmpDoj = new TextBox();
            txtEmpSal = new TextBox();
            txtEmpDeptNo = new TextBox();
            txtEmpId = new TextBox();
            lblEmpDesig = new Label();
            lblEmpDOJ = new Label();
            lblEmpSal = new Label();
            lblEmpDeptNo = new Label();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            btnfind = new Button();
            SuspendLayout();
            // 
            // textEmpName
            // 
            textEmpName.Location = new Point(276, 106);
            textEmpName.Name = "textEmpName";
            textEmpName.Size = new Size(150, 31);
            textEmpName.TabIndex = 0;
            // 
            // lblEmpName
            // 
            lblEmpName.AutoSize = true;
            lblEmpName.Location = new Point(60, 109);
            lblEmpName.Name = "lblEmpName";
            lblEmpName.Size = new Size(142, 25);
            lblEmpName.TabIndex = 1;
            lblEmpName.Text = "Employee Name";
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(129, 360);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(112, 34);
            btnInsert.TabIndex = 2;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // lblEmpId
            // 
            lblEmpId.AutoSize = true;
            lblEmpId.Location = new Point(60, 75);
            lblEmpId.Name = "lblEmpId";
            lblEmpId.Size = new Size(111, 25);
            lblEmpId.TabIndex = 3;
            lblEmpId.Text = "Employee Id";
            // 
            // txtEmpDesig
            // 
            txtEmpDesig.Location = new Point(276, 143);
            txtEmpDesig.Name = "txtEmpDesig";
            txtEmpDesig.Size = new Size(150, 31);
            txtEmpDesig.TabIndex = 4;
            // 
            // txtEmpDoj
            // 
            txtEmpDoj.Location = new Point(276, 189);
            txtEmpDoj.Name = "txtEmpDoj";
            txtEmpDoj.Size = new Size(150, 31);
            txtEmpDoj.TabIndex = 5;
            // 
            // txtEmpSal
            // 
            txtEmpSal.Location = new Point(276, 226);
            txtEmpSal.Name = "txtEmpSal";
            txtEmpSal.Size = new Size(150, 31);
            txtEmpSal.TabIndex = 6;
            // 
            // txtEmpDeptNo
            // 
            txtEmpDeptNo.Location = new Point(276, 263);
            txtEmpDeptNo.Name = "txtEmpDeptNo";
            txtEmpDeptNo.Size = new Size(150, 31);
            txtEmpDeptNo.TabIndex = 7;
            // 
            // txtEmpId
            // 
            txtEmpId.Location = new Point(276, 69);
            txtEmpId.Name = "txtEmpId";
            txtEmpId.Size = new Size(150, 31);
            txtEmpId.TabIndex = 8;
            // 
            // lblEmpDesig
            // 
            lblEmpDesig.AutoSize = true;
            lblEmpDesig.Location = new Point(60, 143);
            lblEmpDesig.Name = "lblEmpDesig";
            lblEmpDesig.Size = new Size(190, 25);
            lblEmpDesig.TabIndex = 9;
            lblEmpDesig.Text = "Employee Designation";
            // 
            // lblEmpDOJ
            // 
            lblEmpDOJ.AutoSize = true;
            lblEmpDOJ.Location = new Point(60, 189);
            lblEmpDOJ.Name = "lblEmpDOJ";
            lblEmpDOJ.Size = new Size(128, 25);
            lblEmpDOJ.TabIndex = 10;
            lblEmpDOJ.Text = "Employee DOJ";
            // 
            // lblEmpSal
            // 
            lblEmpSal.AutoSize = true;
            lblEmpSal.Location = new Point(62, 229);
            lblEmpSal.Name = "lblEmpSal";
            lblEmpSal.Size = new Size(142, 25);
            lblEmpSal.TabIndex = 11;
            lblEmpSal.Text = "Employee Salary";
            // 
            // lblEmpDeptNo
            // 
            lblEmpDeptNo.AutoSize = true;
            lblEmpDeptNo.Location = new Point(62, 269);
            lblEmpDeptNo.Name = "lblEmpDeptNo";
            lblEmpDeptNo.Size = new Size(158, 25);
            lblEmpDeptNo.TabIndex = 12;
            lblEmpDeptNo.Text = "Employee DeptNo";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(247, 360);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 34);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(129, 400);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 34);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(247, 404);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(112, 34);
            btnClear.TabIndex = 15;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnfind
            // 
            btnfind.Location = new Point(415, 368);
            btnfind.Name = "btnfind";
            btnfind.Size = new Size(112, 34);
            btnfind.TabIndex = 16;
            btnfind.Text = "Find";
            btnfind.UseVisualStyleBackColor = true;
            btnfind.Click += btnfind_Click;
            // 
            // SpWithMultiParameters
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnfind);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(lblEmpDeptNo);
            Controls.Add(lblEmpSal);
            Controls.Add(lblEmpDOJ);
            Controls.Add(lblEmpDesig);
            Controls.Add(txtEmpId);
            Controls.Add(txtEmpDeptNo);
            Controls.Add(txtEmpSal);
            Controls.Add(txtEmpDoj);
            Controls.Add(txtEmpDesig);
            Controls.Add(lblEmpId);
            Controls.Add(btnInsert);
            Controls.Add(lblEmpName);
            Controls.Add(textEmpName);
            Name = "SpWithMultiParameters";
            Text = "SpWithMultiParameters";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textEmpName;
        private Label lblEmpName;
        private Button btnInsert;
        private Label lblEmpId;
        private TextBox txtEmpDesig;
        private TextBox txtEmpDoj;
        private TextBox txtEmpSal;
        private TextBox txtEmpDeptNo;
        private TextBox txtEmpId;
        private Label lblEmpDesig;
        private Label lblEmpDOJ;
        private Label lblEmpSal;
        private Label lblEmpDeptNo;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Button btnfind;
    }
}