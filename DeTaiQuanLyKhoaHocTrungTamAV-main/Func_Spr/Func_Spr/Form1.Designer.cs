namespace Func_Spr
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtParFunc = new System.Windows.Forms.TextBox();
            this.txtParProc = new System.Windows.Forms.TextBox();
            this.btnHello = new System.Windows.Forms.Button();
            this.btnInfor = new System.Windows.Forms.Button();
            this.btnGoodNight = new System.Windows.Forms.Button();
            this.btnInfor_ID = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(351, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(437, 318);
            this.dataGridView1.TabIndex = 0;
            // 
            // txtParFunc
            // 
            this.txtParFunc.Location = new System.Drawing.Point(137, 134);
            this.txtParFunc.Name = "txtParFunc";
            this.txtParFunc.Size = new System.Drawing.Size(186, 22);
            this.txtParFunc.TabIndex = 1;
            // 
            // txtParProc
            // 
            this.txtParProc.Location = new System.Drawing.Point(137, 225);
            this.txtParProc.Name = "txtParProc";
            this.txtParProc.Size = new System.Drawing.Size(186, 22);
            this.txtParProc.TabIndex = 2;
            // 
            // btnHello
            // 
            this.btnHello.Location = new System.Drawing.Point(23, 12);
            this.btnHello.Name = "btnHello";
            this.btnHello.Size = new System.Drawing.Size(94, 61);
            this.btnHello.TabIndex = 3;
            this.btnHello.Text = "Func Hello";
            this.btnHello.UseVisualStyleBackColor = true;
            this.btnHello.Click += new System.EventHandler(this.btnHello_Click);
            // 
            // btnInfor
            // 
            this.btnInfor.Location = new System.Drawing.Point(194, 12);
            this.btnInfor.Name = "btnInfor";
            this.btnInfor.Size = new System.Drawing.Size(86, 61);
            this.btnInfor.TabIndex = 4;
            this.btnInfor.Text = "Proc Infor";
            this.btnInfor.UseVisualStyleBackColor = true;
            this.btnInfor.Click += new System.EventHandler(this.btnInfor_Click);
            // 
            // btnGoodNight
            // 
            this.btnGoodNight.Location = new System.Drawing.Point(23, 115);
            this.btnGoodNight.Name = "btnGoodNight";
            this.btnGoodNight.Size = new System.Drawing.Size(94, 61);
            this.btnGoodNight.TabIndex = 5;
            this.btnGoodNight.Text = "Func Goodnight";
            this.btnGoodNight.UseVisualStyleBackColor = true;
            this.btnGoodNight.Click += new System.EventHandler(this.btnGoodNight_Click);
            // 
            // btnInfor_ID
            // 
            this.btnInfor_ID.Location = new System.Drawing.Point(23, 206);
            this.btnInfor_ID.Name = "btnInfor_ID";
            this.btnInfor_ID.Size = new System.Drawing.Size(94, 61);
            this.btnInfor_ID.TabIndex = 6;
            this.btnInfor_ID.Text = "Proc Infor_ID";
            this.btnInfor_ID.UseVisualStyleBackColor = true;
            this.btnInfor_ID.Click += new System.EventHandler(this.btnInfor_ID_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 345);
            this.Controls.Add(this.btnInfor_ID);
            this.Controls.Add(this.btnGoodNight);
            this.Controls.Add(this.btnInfor);
            this.Controls.Add(this.btnHello);
            this.Controls.Add(this.txtParProc);
            this.Controls.Add(this.txtParFunc);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtParFunc;
        private System.Windows.Forms.TextBox txtParProc;
        private System.Windows.Forms.Button btnHello;
        private System.Windows.Forms.Button btnInfor;
        private System.Windows.Forms.Button btnGoodNight;
        private System.Windows.Forms.Button btnInfor_ID;
    }
}

