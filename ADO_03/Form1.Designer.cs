namespace ADO_03
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCa = new System.Windows.Forms.ComboBox();
            this.comboBoxNews = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category";
            // 
            // comboBoxCa
            // 
            this.comboBoxCa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCa.FormattingEnabled = true;
            this.comboBoxCa.Location = new System.Drawing.Point(253, 116);
            this.comboBoxCa.Name = "comboBoxCa";
            this.comboBoxCa.Size = new System.Drawing.Size(213, 23);
            this.comboBoxCa.TabIndex = 1;
            this.comboBoxCa.SelectedIndexChanged += new System.EventHandler(this.comboBoxCa_SelectedIndexChanged);
            // 
            // comboBoxNews
            // 
            this.comboBoxNews.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNews.FormattingEnabled = true;
            this.comboBoxNews.Location = new System.Drawing.Point(253, 233);
            this.comboBoxNews.Name = "comboBoxNews";
            this.comboBoxNews.Size = new System.Drawing.Size(213, 23);
            this.comboBoxNews.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "News";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(309, 341);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxNews);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxCa);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "级联";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCa;
        private System.Windows.Forms.ComboBox comboBoxNews;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}

