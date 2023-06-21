
namespace SZXCVision
{
    partial class XCVisionForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XCVisionForm));
            this.MainPanel = new System.Windows.Forms.Panel();
            this.rtfRichTextBox1 = new CCWin.SkinControl.RtfRichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveProjectFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.process1 = new System.Diagnostics.Process();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.rtfRichTextBox1);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(4, 98);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1334, 682);
            this.MainPanel.TabIndex = 14;
            // 
            // rtfRichTextBox1
            // 
            this.rtfRichTextBox1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.rtfRichTextBox1.HiglightColor = CCWin.SkinControl.RtfRichTextBox.RtfColor.White;
            this.rtfRichTextBox1.Location = new System.Drawing.Point(3, 569);
            this.rtfRichTextBox1.Name = "rtfRichTextBox1";
            this.rtfRichTextBox1.Size = new System.Drawing.Size(1322, 110);
            this.rtfRichTextBox1.TabIndex = 4;
            this.rtfRichTextBox1.Text = "";
            this.rtfRichTextBox1.TextColor = CCWin.SkinControl.RtfRichTextBox.RtfColor.Black;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Blob分析");
            this.imageList1.Images.SetKeyName(1, "循环");
            this.imageList1.Images.SetKeyName(2, "如果");
            this.imageList1.Images.SetKeyName(3, "图像采集");
            this.imageList1.Images.SetKeyName(4, "否则");
            this.imageList1.Images.SetKeyName(5, "否则如果");
            this.imageList1.Images.SetKeyName(6, "禁用");
            this.imageList1.Images.SetKeyName(7, "文件夹");
            this.imageList1.Images.SetKeyName(8, "如果结束");
            this.imageList1.Images.SetKeyName(9, "保存图像");
            this.imageList1.Images.SetKeyName(10, "区域填充");
            this.imageList1.Images.SetKeyName(11, "相机IO输出");
            this.imageList1.Images.SetKeyName(12, "3D图像采集");
            this.imageList1.Images.SetKeyName(13, "图像脚本");
            this.imageList1.Images.SetKeyName(14, "C#程序脚本");
            this.imageList1.Images.SetKeyName(15, "循环结束");
            this.imageList1.Images.SetKeyName(16, "瑕疵检测");
            this.imageList1.Images.SetKeyName(17, "表面脏污检测");
            this.imageList1.Images.SetKeyName(18, "表面划痕检测");
            this.imageList1.Images.SetKeyName(19, "焊锡检测");
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // XCVisionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1342, 821);
            this.CloseBoxSize = new System.Drawing.Size(20, 20);
            this.Controls.Add(this.MainPanel);
            this.MaxSize = new System.Drawing.Size(20, 20);
            this.MiniSize = new System.Drawing.Size(20, 20);
            this.Name = "XCVisionForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.XCVisionForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.MainPanel, 0);
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private CCWin.SkinControl.RtfRichTextBox rtfRichTextBox1;
        private System.Windows.Forms.SaveFileDialog saveProjectFileDialog;
        private System.Windows.Forms.ImageList imageList1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
		private System.Diagnostics.Process process1;
	}
}

