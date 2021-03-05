namespace StateMachineExample
{
    partial class WorkflowForm
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
            this.startBTN = new System.Windows.Forms.Button();
            this.acceptBTN = new System.Windows.Forms.Button();
            this.rejectBTN = new System.Windows.Forms.Button();
            this.getNamesBTN = new System.Windows.Forms.Button();
            this.restartBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // startBTN
            // 
            this.startBTN.Location = new System.Drawing.Point(22, 63);
            this.startBTN.Name = "startBTN";
            this.startBTN.Size = new System.Drawing.Size(75, 23);
            this.startBTN.TabIndex = 0;
            this.startBTN.Text = "启动流程";
            this.startBTN.UseVisualStyleBackColor = true;
            this.startBTN.Click += new System.EventHandler(this.startBTN_Click);
            // 
            // acceptBTN
            // 
            this.acceptBTN.Location = new System.Drawing.Point(22, 102);
            this.acceptBTN.Name = "acceptBTN";
            this.acceptBTN.Size = new System.Drawing.Size(75, 23);
            this.acceptBTN.TabIndex = 0;
            this.acceptBTN.Text = "流程通过";
            this.acceptBTN.UseVisualStyleBackColor = true;
            this.acceptBTN.Click += new System.EventHandler(this.acceptBTN_Click);
            // 
            // rejectBTN
            // 
            this.rejectBTN.Location = new System.Drawing.Point(118, 102);
            this.rejectBTN.Name = "rejectBTN";
            this.rejectBTN.Size = new System.Drawing.Size(75, 23);
            this.rejectBTN.TabIndex = 0;
            this.rejectBTN.Text = "流程否决";
            this.rejectBTN.UseVisualStyleBackColor = true;
            this.rejectBTN.Click += new System.EventHandler(this.rejectBTN_Click);
            // 
            // getNamesBTN
            // 
            this.getNamesBTN.Location = new System.Drawing.Point(118, 63);
            this.getNamesBTN.Name = "getNamesBTN";
            this.getNamesBTN.Size = new System.Drawing.Size(75, 23);
            this.getNamesBTN.TabIndex = 0;
            this.getNamesBTN.Text = "指定会签";
            this.getNamesBTN.UseVisualStyleBackColor = true;
            this.getNamesBTN.Click += new System.EventHandler(this.getNamesBTN_Click);
            // 
            // restartBTN
            // 
            this.restartBTN.Location = new System.Drawing.Point(118, 142);
            this.restartBTN.Name = "restartBTN";
            this.restartBTN.Size = new System.Drawing.Size(75, 23);
            this.restartBTN.TabIndex = 1;
            this.restartBTN.Text = "取消流程";
            this.restartBTN.UseVisualStyleBackColor = true;
            this.restartBTN.Click += new System.EventHandler(this.restartBTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "书签名：";
            // 
            // nameBox
            // 
            this.nameBox.FormattingEnabled = true;
            this.nameBox.Location = new System.Drawing.Point(79, 23);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(114, 20);
            this.nameBox.TabIndex = 4;
            // 
            // WorkflowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 193);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.restartBTN);
            this.Controls.Add(this.getNamesBTN);
            this.Controls.Add(this.rejectBTN);
            this.Controls.Add(this.acceptBTN);
            this.Controls.Add(this.startBTN);
            this.Name = "WorkflowForm";
            this.Text = "流程处理";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startBTN;
        private System.Windows.Forms.Button acceptBTN;
        private System.Windows.Forms.Button rejectBTN;
        private System.Windows.Forms.Button getNamesBTN;
        private System.Windows.Forms.Button restartBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox nameBox;
    }
}