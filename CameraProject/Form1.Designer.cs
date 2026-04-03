namespace CameraProject
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
            this.buttonConnect = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonDiscConnect = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonColse = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(24, 384);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(158, 38);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "连接相机";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(89, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(580, 320);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // buttonDiscConnect
            // 
            this.buttonDiscConnect.Location = new System.Drawing.Point(228, 384);
            this.buttonDiscConnect.Name = "buttonDiscConnect";
            this.buttonDiscConnect.Size = new System.Drawing.Size(158, 38);
            this.buttonDiscConnect.TabIndex = 2;
            this.buttonDiscConnect.Text = "关闭相机";
            this.buttonDiscConnect.UseVisualStyleBackColor = true;
            this.buttonDiscConnect.Click += new System.EventHandler(this.buttonDiscConnect_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(436, 384);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(158, 38);
            this.buttonOpen.TabIndex = 3;
            this.buttonOpen.Text = "开启画面";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonColse
            // 
            this.buttonColse.Location = new System.Drawing.Point(630, 384);
            this.buttonColse.Name = "buttonColse";
            this.buttonColse.Size = new System.Drawing.Size(158, 38);
            this.buttonColse.TabIndex = 4;
            this.buttonColse.Text = "关闭画面";
            this.buttonColse.UseVisualStyleBackColor = true;
            this.buttonColse.Click += new System.EventHandler(this.buttonColse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonColse);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonDiscConnect);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonConnect);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonDiscConnect;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonColse;
    }
}

