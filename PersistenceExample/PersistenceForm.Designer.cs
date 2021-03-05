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
            this.nameBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.createBTN = new System.Windows.Forms.Button();
            this.getNamesBTN = new System.Windows.Forms.Button();
            this.rejectBTN = new System.Windows.Forms.Button();
            this.acceptBTN = new System.Windows.Forms.Button();
            this.loadBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Button();
            this.guidBox = new System.Windows.Forms.ComboBox();
            this.unloadBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameBox
            // 
            this.nameBox.FormattingEnabled = true;
            this.nameBox.Location = new System.Drawing.Point(102, 59);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(196, 20);
            this.nameBox.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "书签名：";
            // 
            // createBTN
            // 
            this.createBTN.Location = new System.Drawing.Point(86, 99);
            this.createBTN.Name = "createBTN";
            this.createBTN.Size = new System.Drawing.Size(75, 23);
            this.createBTN.TabIndex = 9;
            this.createBTN.Text = "创建流程";
            this.createBTN.UseVisualStyleBackColor = true;
            this.createBTN.Click += new System.EventHandler(this.createBTN_Click);
            // 
            // getNamesBTN
            // 
            this.getNamesBTN.Location = new System.Drawing.Point(223, 138);
            this.getNamesBTN.Name = "getNamesBTN";
            this.getNamesBTN.Size = new System.Drawing.Size(75, 23);
            this.getNamesBTN.TabIndex = 5;
            this.getNamesBTN.Text = "指定会签";
            this.getNamesBTN.UseVisualStyleBackColor = true;
            this.getNamesBTN.Click += new System.EventHandler(this.getNamesBTN_Click);
            // 
            // rejectBTN
            // 
            this.rejectBTN.Location = new System.Drawing.Point(133, 138);
            this.rejectBTN.Name = "rejectBTN";
            this.rejectBTN.Size = new System.Drawing.Size(75, 23);
            this.rejectBTN.TabIndex = 6;
            this.rejectBTN.Text = "流程否决";
            this.rejectBTN.UseVisualStyleBackColor = true;
            this.rejectBTN.Click += new System.EventHandler(this.rejectBTN_Click);
            // 
            // acceptBTN
            // 
            this.acceptBTN.Location = new System.Drawing.Point(45, 138);
            this.acceptBTN.Name = "acceptBTN";
            this.acceptBTN.Size = new System.Drawing.Size(75, 23);
            this.acceptBTN.TabIndex = 7;
            this.acceptBTN.Text = "流程通过";
            this.acceptBTN.UseVisualStyleBackColor = true;
            this.acceptBTN.Click += new System.EventHandler(this.acceptBTN_Click);
            // 
            // loadBTN
            // 
            this.loadBTN.Location = new System.Drawing.Point(183, 99);
            this.loadBTN.Name = "loadBTN";
            this.loadBTN.Size = new System.Drawing.Size(75, 23);
            this.loadBTN.TabIndex = 8;
            this.loadBTN.Text = "加载流程";
            this.loadBTN.UseVisualStyleBackColor = true;
            this.loadBTN.Click += new System.EventHandler(this.loadBTN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "持久化Id：";
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(183, 179);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 13;
            this.cancel.Text = "取消流程";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // guidBox
            // 
            this.guidBox.FormattingEnabled = true;
            this.guidBox.Location = new System.Drawing.Point(102, 29);
            this.guidBox.Name = "guidBox";
            this.guidBox.Size = new System.Drawing.Size(196, 20);
            this.guidBox.TabIndex = 14;
            // 
            // unloadBTN
            // 
            this.unloadBTN.Location = new System.Drawing.Point(86, 179);
            this.unloadBTN.Name = "unloadBTN";
            this.unloadBTN.Size = new System.Drawing.Size(75, 23);
            this.unloadBTN.TabIndex = 13;
            this.unloadBTN.Text = "卸载流程";
            this.unloadBTN.UseVisualStyleBackColor = true;
            this.unloadBTN.Click += new System.EventHandler(this.unloadBTN_Click);
            // 
            // PersistenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 229);
            this.Controls.Add(this.guidBox);
            this.Controls.Add(this.unloadBTN);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createBTN);
            this.Controls.Add(this.getNamesBTN);
            this.Controls.Add(this.rejectBTN);
            this.Controls.Add(this.acceptBTN);
            this.Controls.Add(this.loadBTN);
            this.Name = "PersistenceForm";
            this.Text = "持久化示例";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PersistenceForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox nameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button createBTN;
        private System.Windows.Forms.Button getNamesBTN;
        private System.Windows.Forms.Button rejectBTN;
        private System.Windows.Forms.Button acceptBTN;
        private System.Windows.Forms.Button loadBTN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.ComboBox guidBox;
        private System.Windows.Forms.Button unloadBTN;
    }
}

