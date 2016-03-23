namespace change
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.startBtn = new System.Windows.Forms.Button();
            this.novelText = new System.Windows.Forms.RichTextBox();
            this.pasteBtn = new System.Windows.Forms.Button();
            this.cutBtn = new System.Windows.Forms.Button();
            this.autoBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startBtn
            // 
            resources.ApplyResources(this.startBtn, "startBtn");
            this.startBtn.Name = "startBtn";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // novelText
            // 
            resources.ApplyResources(this.novelText, "novelText");
            this.novelText.Name = "novelText";
            // 
            // pasteBtn
            // 
            resources.ApplyResources(this.pasteBtn, "pasteBtn");
            this.pasteBtn.Name = "pasteBtn";
            this.pasteBtn.UseVisualStyleBackColor = true;
            this.pasteBtn.Click += new System.EventHandler(this.pasteBtn_Click);
            // 
            // cutBtn
            // 
            resources.ApplyResources(this.cutBtn, "cutBtn");
            this.cutBtn.Name = "cutBtn";
            this.cutBtn.UseVisualStyleBackColor = true;
            this.cutBtn.Click += new System.EventHandler(this.cutBtn_Click);
            // 
            // autoBtn
            // 
            resources.ApplyResources(this.autoBtn, "autoBtn");
            this.autoBtn.Name = "autoBtn";
            this.autoBtn.UseVisualStyleBackColor = true;
            this.autoBtn.Click += new System.EventHandler(this.autoBtn_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.autoBtn);
            this.Controls.Add(this.cutBtn);
            this.Controls.Add(this.pasteBtn);
            this.Controls.Add(this.novelText);
            this.Controls.Add(this.startBtn);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.RichTextBox novelText;
        private System.Windows.Forms.Button pasteBtn;
        private System.Windows.Forms.Button cutBtn;
        private System.Windows.Forms.Button autoBtn;
    }
}

