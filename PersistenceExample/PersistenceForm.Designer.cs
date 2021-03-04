namespace PersistenceExample
{
    partial class PersistenceForm
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
            this.createBTN = new System.Windows.Forms.Button();
            this.instanceIdTXT = new System.Windows.Forms.TextBox();
            this.runBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createBTN
            // 
            this.createBTN.Location = new System.Drawing.Point(42, 115);
            this.createBTN.Name = "createBTN";
            this.createBTN.Size = new System.Drawing.Size(75, 23);
            this.createBTN.TabIndex = 0;
            this.createBTN.Text = "创建流程";
            this.createBTN.UseVisualStyleBackColor = true;
            this.createBTN.Click += new System.EventHandler(this.createBTN_Click);
            // 
            // instanceIdTXT
            // 
            this.instanceIdTXT.Location = new System.Drawing.Point(42, 63);
            this.instanceIdTXT.Name = "instanceIdTXT";
            this.instanceIdTXT.Size = new System.Drawing.Size(174, 21);
            this.instanceIdTXT.TabIndex = 1;
            // 
            // runBTN
            // 
            this.runBTN.Location = new System.Drawing.Point(141, 115);
            this.runBTN.Name = "runBTN";
            this.runBTN.Size = new System.Drawing.Size(75, 23);
            this.runBTN.TabIndex = 2;
            this.runBTN.Text = "运行流程";
            this.runBTN.UseVisualStyleBackColor = true;
            this.runBTN.Click += new System.EventHandler(this.runBTN_Click);
            // 
            // PersistenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 195);
            this.Controls.Add(this.runBTN);
            this.Controls.Add(this.instanceIdTXT);
            this.Controls.Add(this.createBTN);
            this.Name = "PersistenceForm";
            this.Text = "持久化示例";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createBTN;
        private System.Windows.Forms.TextBox instanceIdTXT;
        private System.Windows.Forms.Button runBTN;
    }
}

