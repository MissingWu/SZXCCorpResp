
namespace SZXCVision
{
	partial class ProjListRunForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjListRunForm));
            this.skinCaptionPanel1 = new CCWin.SkinControl.SkinCaptionPanel();
            this.skinListBox1 = new CCWin.SkinControl.SkinListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.等待完成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.无需等待ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.禁用ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skinCaptionPanel2 = new CCWin.SkinControl.SkinCaptionPanel();
            this.rtfRichTextBox1 = new CCWin.SkinControl.RtfRichTextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.skinCaptionPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_run
            // 
            this.button_run.Location = new System.Drawing.Point(10, 629);
            this.button_run.Click += new System.EventHandler(this.button_run_Click);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(117, 629);
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(239, 629);
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // skinCaptionPanel1
            // 
            this.skinCaptionPanel1.CaptionFont = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.skinCaptionPanel1.Location = new System.Drawing.Point(10, 41);
            this.skinCaptionPanel1.Name = "skinCaptionPanel1";
            this.skinCaptionPanel1.Size = new System.Drawing.Size(309, 31);
            this.skinCaptionPanel1.TabIndex = 13;
            this.skinCaptionPanel1.Text = "启动的流程集合";
            this.skinCaptionPanel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // skinListBox1
            // 
            this.skinListBox1.AllowDrop = true;
            this.skinListBox1.Back = null;
            this.skinListBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.skinListBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.skinListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinListBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinListBox1.FormattingEnabled = true;
            this.skinListBox1.ItemHeight = 20;
            this.skinListBox1.Location = new System.Drawing.Point(5, 69);
            this.skinListBox1.Name = "skinListBox1";
            this.skinListBox1.Size = new System.Drawing.Size(309, 544);
            this.skinListBox1.TabIndex = 12;
            this.skinListBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.skinListBox2_DrawItem);
            this.skinListBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.skinListBox1_DragDrop);
            this.skinListBox1.DragOver += new System.Windows.Forms.DragEventHandler(this.skinListBox1_DragOver);
            this.skinListBox1.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.skinListBox1_GiveFeedback);
            this.skinListBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.skinListBox1_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.等待完成ToolStripMenuItem,
            this.无需等待ToolStripMenuItem,
            this.禁用ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 70);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // 等待完成ToolStripMenuItem
            // 
            this.等待完成ToolStripMenuItem.Enabled = false;
            this.等待完成ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("等待完成ToolStripMenuItem.Image")));
            this.等待完成ToolStripMenuItem.Name = "等待完成ToolStripMenuItem";
            this.等待完成ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.等待完成ToolStripMenuItem.Text = "等待完成";
            this.等待完成ToolStripMenuItem.Visible = false;
            // 
            // 无需等待ToolStripMenuItem
            // 
            this.无需等待ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("无需等待ToolStripMenuItem.Image")));
            this.无需等待ToolStripMenuItem.Name = "无需等待ToolStripMenuItem";
            this.无需等待ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.无需等待ToolStripMenuItem.Text = "无需等待或禁用";
            // 
            // 禁用ToolStripMenuItem
            // 
            this.禁用ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("禁用ToolStripMenuItem.Image")));
            this.禁用ToolStripMenuItem.Name = "禁用ToolStripMenuItem";
            this.禁用ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.禁用ToolStripMenuItem.Text = "禁用";
            // 
            // skinCaptionPanel2
            // 
            this.skinCaptionPanel2.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.skinCaptionPanel2.Controls.Add(this.rtfRichTextBox1);
            this.skinCaptionPanel2.Location = new System.Drawing.Point(325, 41);
            this.skinCaptionPanel2.Name = "skinCaptionPanel2";
            this.skinCaptionPanel2.Size = new System.Drawing.Size(256, 618);
            this.skinCaptionPanel2.TabIndex = 34;
            this.skinCaptionPanel2.Text = "操作说明";
            this.skinCaptionPanel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtfRichTextBox1
            // 
            this.rtfRichTextBox1.BackColor = System.Drawing.SystemColors.Info;
            this.rtfRichTextBox1.HiglightColor = CCWin.SkinControl.RtfRichTextBox.RtfColor.White;
            this.rtfRichTextBox1.Location = new System.Drawing.Point(5, 28);
            this.rtfRichTextBox1.Name = "rtfRichTextBox1";
            this.rtfRichTextBox1.Size = new System.Drawing.Size(246, 577);
            this.rtfRichTextBox1.TabIndex = 0;
            this.rtfRichTextBox1.Text = "1.拖拽相应的流程排序，系统自动按照次顺序启动流程\n\n2.相应流程如果不启动可以按鼠标右键进行更改\n\n3.如果继续按执行，如果不执行请按下取消";
            this.rtfRichTextBox1.TextColor = CCWin.SkinControl.RtfRichTextBox.RtfColor.Black;
            // 
            // ProjListRunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 665);
            this.Controls.Add(this.skinCaptionPanel2);
            this.Controls.Add(this.skinCaptionPanel1);
            this.Controls.Add(this.skinListBox1);
            this.Name = "ProjListRunForm";
            this.Text = "ProjListRunForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProjListRunForm_FormClosing);
            this.Load += new System.EventHandler(this.ProjListRunForm_Load);
            this.Controls.SetChildIndex(this.button_cancel, 0);
            this.Controls.SetChildIndex(this.button_save, 0);
            this.Controls.SetChildIndex(this.button_run, 0);
            this.Controls.SetChildIndex(this.skinListBox1, 0);
            this.Controls.SetChildIndex(this.skinCaptionPanel1, 0);
            this.Controls.SetChildIndex(this.skinCaptionPanel2, 0);
            this.contextMenuStrip1.ResumeLayout(false);
            this.skinCaptionPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private CCWin.SkinControl.SkinCaptionPanel skinCaptionPanel1;
		private CCWin.SkinControl.SkinListBox skinListBox1;
		private CCWin.SkinControl.SkinCaptionPanel skinCaptionPanel2;
		private CCWin.SkinControl.RtfRichTextBox rtfRichTextBox1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 等待完成ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 无需等待ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 禁用ToolStripMenuItem;
	}
}