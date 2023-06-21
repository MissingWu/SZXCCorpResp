
namespace Plugin.Arithmetic
{
	partial class AlrithmeticModuleForm
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
            this.uiLabel1 = new Rex.UI.UILabel();
            this.uiLabel3 = new Rex.UI.UILabel();
            this.uiComboBox3 = new Rex.UI.UIComboBox();
            this.uiLabel5 = new Rex.UI.UILabel();
            this.uiTextBox3 = new Rex.UI.UITextBox();
            this.uiLabel6 = new Rex.UI.UILabel();
            this.textBox_link = new Rex.UI.UILinkData();
            this.textBox_link2 = new Rex.UI.UILinkData();
            this.skinCheckBox1 = new CCWin.SkinControl.SkinCheckBox();
            this.uiLinkData1 = new Rex.UI.UILinkData();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uiLinkData2 = new Rex.UI.UILinkData();
            this.skinCheckBox2 = new CCWin.SkinControl.SkinCheckBox();
            this.SuspendLayout();
            // 
            // button_run
            // 
            this.button_run.Location = new System.Drawing.Point(18, 305);
            this.button_run.Click += new System.EventHandler(this.button_run_Click);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(410, 305);
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(761, 305);
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(19, 60);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(81, 23);
            this.uiLabel1.TabIndex = 16;
            this.uiLabel1.Text = "数据名称:";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(19, 159);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(81, 23);
            this.uiLabel3.TabIndex = 16;
            this.uiLabel3.Text = "数据名称:";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiComboBox3
            // 
            this.uiComboBox3.FillColor = System.Drawing.Color.White;
            this.uiComboBox3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiComboBox3.Items.AddRange(new object[] {
            "加法",
            "减法",
            "乘法",
            "除法"});
            this.uiComboBox3.Location = new System.Drawing.Point(346, 106);
            this.uiComboBox3.Margin = new System.Windows.Forms.Padding(0);
            this.uiComboBox3.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox3.Name = "uiComboBox3";
            this.uiComboBox3.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.uiComboBox3.Radius = 2;
            this.uiComboBox3.Size = new System.Drawing.Size(74, 29);
            this.uiComboBox3.TabIndex = 13;
            this.uiComboBox3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox3.SelectedIndexChanged += new System.EventHandler(this.uiComboBox3_SelectedIndexChanged);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel5.Location = new System.Drawing.Point(262, 107);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(81, 23);
            this.uiLabel5.TabIndex = 16;
            this.uiLabel5.Text = "运算符号:";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTextBox3
            // 
            this.uiTextBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiTextBox3.Location = new System.Drawing.Point(346, 232);
            this.uiTextBox3.Margin = new System.Windows.Forms.Padding(0);
            this.uiTextBox3.Maximum = 2147483647D;
            this.uiTextBox3.Minimum = -2147483648D;
            this.uiTextBox3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTextBox3.Name = "uiTextBox3";
            this.uiTextBox3.Size = new System.Drawing.Size(146, 29);
            this.uiTextBox3.Style = Rex.UI.UIStyle.Custom;
            this.uiTextBox3.StyleCustomMode = true;
            this.uiTextBox3.TabIndex = 14;
            this.uiTextBox3.Text = "结果数据";
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel6.Location = new System.Drawing.Point(260, 235);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(81, 23);
            this.uiLabel6.TabIndex = 15;
            this.uiLabel6.Text = "运算结果:";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_link
            // 
            this.textBox_link.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBox_link.Location = new System.Drawing.Point(96, 59);
            this.textBox_link.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_link.MinimumSize = new System.Drawing.Size(100, 0);
            this.textBox_link.Name = "textBox_link";
            this.textBox_link.RadiusSides = Rex.UI.UICornerRadiusSides.None;
            this.textBox_link.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom;
            this.textBox_link.Size = new System.Drawing.Size(323, 27);
            this.textBox_link.StyleCustomMode = true;
            this.textBox_link.TabIndex = 27;
            this.textBox_link.Text = "uiLinkData1";
            this.textBox_link.BtnAdd += new Rex.UI.UILinkData.BtnAddHandle(this.textBox_link_BtnAdd);
            this.textBox_link.BtnDec += new Rex.UI.UILinkData.BtnDecHandle(this.textBox_link_BtnDec);
            // 
            // textBox_link2
            // 
            this.textBox_link2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBox_link2.Location = new System.Drawing.Point(92, 160);
            this.textBox_link2.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_link2.MinimumSize = new System.Drawing.Size(100, 0);
            this.textBox_link2.Name = "textBox_link2";
            this.textBox_link2.RadiusSides = Rex.UI.UICornerRadiusSides.None;
            this.textBox_link2.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom;
            this.textBox_link2.Size = new System.Drawing.Size(327, 27);
            this.textBox_link2.StyleCustomMode = true;
            this.textBox_link2.TabIndex = 27;
            this.textBox_link2.Text = "uiLinkData1";
            this.textBox_link2.BtnAdd += new Rex.UI.UILinkData.BtnAddHandle(this.uiLinkData1_BtnAdd);
            // 
            // skinCheckBox1
            // 
            this.skinCheckBox1.AutoSize = true;
            this.skinCheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinCheckBox1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinCheckBox1.DownBack = null;
            this.skinCheckBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinCheckBox1.Location = new System.Drawing.Point(430, 62);
            this.skinCheckBox1.MouseBack = null;
            this.skinCheckBox1.Name = "skinCheckBox1";
            this.skinCheckBox1.NormlBack = null;
            this.skinCheckBox1.SelectedDownBack = null;
            this.skinCheckBox1.SelectedMouseBack = null;
            this.skinCheckBox1.SelectedNormlBack = null;
            this.skinCheckBox1.Size = new System.Drawing.Size(157, 29);
            this.skinCheckBox1.TabIndex = 30;
            this.skinCheckBox1.Text = "自动循环加载:";
            this.skinCheckBox1.UseVisualStyleBackColor = false;
            this.skinCheckBox1.CheckedChanged += new System.EventHandler(this.skinCheckBox1_CheckedChanged);
            // 
            // uiLinkData1
            // 
            this.uiLinkData1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLinkData1.Location = new System.Drawing.Point(663, 60);
            this.uiLinkData1.Margin = new System.Windows.Forms.Padding(0);
            this.uiLinkData1.MinimumSize = new System.Drawing.Size(100, 0);
            this.uiLinkData1.Name = "uiLinkData1";
            this.uiLinkData1.RadiusSides = Rex.UI.UICornerRadiusSides.None;
            this.uiLinkData1.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom;
            this.uiLinkData1.Size = new System.Drawing.Size(176, 27);
            this.uiLinkData1.StyleCustomMode = true;
            this.uiLinkData1.TabIndex = 29;
            this.uiLinkData1.Text = "uiLinkData1";
            this.uiLinkData1.BtnAdd += new Rex.UI.UILinkData.BtnAddHandle(this.uiLinkData1_BtnAdd_1);
            this.uiLinkData1.BtnDec += new Rex.UI.UILinkData.BtnDecHandle(this.uiLinkData1_BtnDec_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(585, 70);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 28;
            this.label5.Text = "循环索引号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(590, 168);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 28;
            this.label1.Text = "循环索引号：";
            // 
            // uiLinkData2
            // 
            this.uiLinkData2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLinkData2.Location = new System.Drawing.Point(669, 159);
            this.uiLinkData2.Margin = new System.Windows.Forms.Padding(0);
            this.uiLinkData2.MinimumSize = new System.Drawing.Size(100, 0);
            this.uiLinkData2.Name = "uiLinkData2";
            this.uiLinkData2.RadiusSides = Rex.UI.UICornerRadiusSides.None;
            this.uiLinkData2.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom;
            this.uiLinkData2.Size = new System.Drawing.Size(176, 27);
            this.uiLinkData2.StyleCustomMode = true;
            this.uiLinkData2.TabIndex = 29;
            this.uiLinkData2.Text = "uiLinkData1";
            this.uiLinkData2.BtnAdd += new Rex.UI.UILinkData.BtnAddHandle(this.uiLinkData2_BtnAdd);
            this.uiLinkData2.BtnDec += new Rex.UI.UILinkData.BtnDecHandle(this.uiLinkData2_BtnDec);
            // 
            // skinCheckBox2
            // 
            this.skinCheckBox2.AutoSize = true;
            this.skinCheckBox2.BackColor = System.Drawing.Color.Transparent;
            this.skinCheckBox2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinCheckBox2.DownBack = null;
            this.skinCheckBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinCheckBox2.Location = new System.Drawing.Point(436, 161);
            this.skinCheckBox2.MouseBack = null;
            this.skinCheckBox2.Name = "skinCheckBox2";
            this.skinCheckBox2.NormlBack = null;
            this.skinCheckBox2.SelectedDownBack = null;
            this.skinCheckBox2.SelectedMouseBack = null;
            this.skinCheckBox2.SelectedNormlBack = null;
            this.skinCheckBox2.Size = new System.Drawing.Size(157, 29);
            this.skinCheckBox2.TabIndex = 30;
            this.skinCheckBox2.Text = "自动循环加载:";
            this.skinCheckBox2.UseVisualStyleBackColor = false;
            this.skinCheckBox2.CheckedChanged += new System.EventHandler(this.skinCheckBox2_CheckedChanged);
            // 
            // AlrithmeticModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 355);
            this.Controls.Add(this.skinCheckBox2);
            this.Controls.Add(this.skinCheckBox1);
            this.Controls.Add(this.uiLinkData2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uiLinkData1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_link2);
            this.Controls.Add(this.textBox_link);
            this.Controls.Add(this.uiLabel6);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.uiTextBox3);
            this.Controls.Add(this.uiComboBox3);
            this.Name = "AlrithmeticModuleForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.DelayModuleForm_Load);
            this.Controls.SetChildIndex(this.button_cancel, 0);
            this.Controls.SetChildIndex(this.button_save, 0);
            this.Controls.SetChildIndex(this.button_run, 0);
            this.Controls.SetChildIndex(this.uiComboBox3, 0);
            this.Controls.SetChildIndex(this.uiTextBox3, 0);
            this.Controls.SetChildIndex(this.uiLabel1, 0);
            this.Controls.SetChildIndex(this.uiLabel5, 0);
            this.Controls.SetChildIndex(this.uiLabel3, 0);
            this.Controls.SetChildIndex(this.uiLabel6, 0);
            this.Controls.SetChildIndex(this.textBox_link, 0);
            this.Controls.SetChildIndex(this.textBox_link2, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.uiLinkData1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.uiLinkData2, 0);
            this.Controls.SetChildIndex(this.skinCheckBox1, 0);
            this.Controls.SetChildIndex(this.skinCheckBox2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private Rex.UI.UILabel uiLabel1;
		private Rex.UI.UILabel uiLabel3;
		private Rex.UI.UIComboBox uiComboBox3;
		private Rex.UI.UILabel uiLabel5;
		private Rex.UI.UITextBox uiTextBox3;
		private Rex.UI.UILabel uiLabel6;
		private Rex.UI.UILinkData textBox_link;
		private Rex.UI.UILinkData textBox_link2;
		private CCWin.SkinControl.SkinCheckBox skinCheckBox1;
		private Rex.UI.UILinkData uiLinkData1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label1;
		private Rex.UI.UILinkData uiLinkData2;
		private CCWin.SkinControl.SkinCheckBox skinCheckBox2;
	}
}