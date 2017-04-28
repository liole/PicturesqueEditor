namespace Picturesque.Editor
{
	partial class NewProjectDialog
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
			this.cancelBtn = new System.Windows.Forms.Button();
			this.okBtn = new System.Windows.Forms.Button();
			this.sizeBox = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.heightValue = new System.Windows.Forms.NumericUpDown();
			this.px1Lbl = new System.Windows.Forms.Label();
			this.widthValue = new System.Windows.Forms.NumericUpDown();
			this.heightLbl = new System.Windows.Forms.Label();
			this.widthLbl = new System.Windows.Forms.Label();
			this.backgrundBox = new System.Windows.Forms.GroupBox();
			this.colorBtn = new System.Windows.Forms.Button();
			this.colorBox = new System.Windows.Forms.Panel();
			this.backgrundChb = new System.Windows.Forms.CheckBox();
			this.sizeBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.heightValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.widthValue)).BeginInit();
			this.backgrundBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// cancelBtn
			// 
			this.cancelBtn.BackColor = System.Drawing.Color.Gray;
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.cancelBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
			this.cancelBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
			this.cancelBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cancelBtn.ImageKey = "(none)";
			this.cancelBtn.Location = new System.Drawing.Point(123, 217);
			this.cancelBtn.Margin = new System.Windows.Forms.Padding(1);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(64, 24);
			this.cancelBtn.TabIndex = 7;
			this.cancelBtn.Tag = "";
			this.cancelBtn.Text = "&Cancel";
			this.cancelBtn.UseVisualStyleBackColor = false;
			// 
			// okBtn
			// 
			this.okBtn.BackColor = System.Drawing.Color.Gray;
			this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.okBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
			this.okBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
			this.okBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.okBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.okBtn.ImageKey = "(none)";
			this.okBtn.Location = new System.Drawing.Point(26, 217);
			this.okBtn.Margin = new System.Windows.Forms.Padding(1);
			this.okBtn.Name = "okBtn";
			this.okBtn.Size = new System.Drawing.Size(64, 24);
			this.okBtn.TabIndex = 6;
			this.okBtn.Tag = "";
			this.okBtn.Text = "&OK";
			this.okBtn.UseVisualStyleBackColor = false;
			// 
			// sizeBox
			// 
			this.sizeBox.Controls.Add(this.label1);
			this.sizeBox.Controls.Add(this.heightValue);
			this.sizeBox.Controls.Add(this.px1Lbl);
			this.sizeBox.Controls.Add(this.widthValue);
			this.sizeBox.Controls.Add(this.heightLbl);
			this.sizeBox.Controls.Add(this.widthLbl);
			this.sizeBox.ForeColor = System.Drawing.Color.White;
			this.sizeBox.Location = new System.Drawing.Point(12, 12);
			this.sizeBox.Name = "sizeBox";
			this.sizeBox.Size = new System.Drawing.Size(192, 101);
			this.sizeBox.TabIndex = 8;
			this.sizeBox.TabStop = false;
			this.sizeBox.Text = "Size";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(153, 61);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(18, 13);
			this.label1.TabIndex = 15;
			this.label1.Text = "px";
			// 
			// heightValue
			// 
			this.heightValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.heightValue.Location = new System.Drawing.Point(70, 57);
			this.heightValue.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
			this.heightValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.heightValue.Name = "heightValue";
			this.heightValue.Size = new System.Drawing.Size(77, 22);
			this.heightValue.TabIndex = 14;
			this.heightValue.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
			// 
			// px1Lbl
			// 
			this.px1Lbl.AutoSize = true;
			this.px1Lbl.Location = new System.Drawing.Point(153, 33);
			this.px1Lbl.Name = "px1Lbl";
			this.px1Lbl.Size = new System.Drawing.Size(18, 13);
			this.px1Lbl.TabIndex = 13;
			this.px1Lbl.Text = "px";
			// 
			// widthValue
			// 
			this.widthValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.widthValue.Location = new System.Drawing.Point(70, 29);
			this.widthValue.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
			this.widthValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.widthValue.Name = "widthValue";
			this.widthValue.Size = new System.Drawing.Size(77, 22);
			this.widthValue.TabIndex = 12;
			this.widthValue.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
			// 
			// heightLbl
			// 
			this.heightLbl.AutoSize = true;
			this.heightLbl.Location = new System.Drawing.Point(17, 61);
			this.heightLbl.Name = "heightLbl";
			this.heightLbl.Size = new System.Drawing.Size(41, 13);
			this.heightLbl.TabIndex = 1;
			this.heightLbl.Text = "Height:";
			// 
			// widthLbl
			// 
			this.widthLbl.AutoSize = true;
			this.widthLbl.Location = new System.Drawing.Point(17, 33);
			this.widthLbl.Name = "widthLbl";
			this.widthLbl.Size = new System.Drawing.Size(38, 13);
			this.widthLbl.TabIndex = 0;
			this.widthLbl.Text = "Width:";
			// 
			// backgrundBox
			// 
			this.backgrundBox.Controls.Add(this.colorBtn);
			this.backgrundBox.Controls.Add(this.colorBox);
			this.backgrundBox.Controls.Add(this.backgrundChb);
			this.backgrundBox.ForeColor = System.Drawing.Color.White;
			this.backgrundBox.Location = new System.Drawing.Point(12, 127);
			this.backgrundBox.Name = "backgrundBox";
			this.backgrundBox.Size = new System.Drawing.Size(190, 75);
			this.backgrundBox.TabIndex = 9;
			this.backgrundBox.TabStop = false;
			this.backgrundBox.Text = "      Background";
			// 
			// colorBtn
			// 
			this.colorBtn.BackColor = System.Drawing.Color.Gray;
			this.colorBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.colorBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
			this.colorBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
			this.colorBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.colorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.colorBtn.ImageKey = "(none)";
			this.colorBtn.Location = new System.Drawing.Point(57, 30);
			this.colorBtn.Margin = new System.Windows.Forms.Padding(1);
			this.colorBtn.Name = "colorBtn";
			this.colorBtn.Size = new System.Drawing.Size(114, 24);
			this.colorBtn.TabIndex = 10;
			this.colorBtn.Tag = "";
			this.colorBtn.Text = "Change color";
			this.colorBtn.UseVisualStyleBackColor = false;
			this.colorBtn.Click += new System.EventHandler(this.colorBtn_Click);
			// 
			// colorBox
			// 
			this.colorBox.BackColor = System.Drawing.Color.White;
			this.colorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.colorBox.Location = new System.Drawing.Point(20, 30);
			this.colorBox.Name = "colorBox";
			this.colorBox.Size = new System.Drawing.Size(24, 24);
			this.colorBox.TabIndex = 1;
			// 
			// backgrundChb
			// 
			this.backgrundChb.AutoSize = true;
			this.backgrundChb.Location = new System.Drawing.Point(10, 0);
			this.backgrundChb.Name = "backgrundChb";
			this.backgrundChb.Size = new System.Drawing.Size(15, 14);
			this.backgrundChb.TabIndex = 0;
			this.backgrundChb.UseVisualStyleBackColor = true;
			this.backgrundChb.CheckedChanged += new System.EventHandler(this.backgrundChb_CheckedChanged);
			// 
			// NewProjectDialog
			// 
			this.AcceptButton = this.okBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.CancelButton = this.cancelBtn;
			this.ClientSize = new System.Drawing.Size(216, 261);
			this.Controls.Add(this.backgrundBox);
			this.Controls.Add(this.sizeBox);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.okBtn);
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "NewProjectDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Project";
			this.sizeBox.ResumeLayout(false);
			this.sizeBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.heightValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.widthValue)).EndInit();
			this.backgrundBox.ResumeLayout(false);
			this.backgrundBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.Button okBtn;
		private System.Windows.Forms.GroupBox sizeBox;
		private System.Windows.Forms.Label widthLbl;
		private System.Windows.Forms.Label heightLbl;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown heightValue;
		private System.Windows.Forms.Label px1Lbl;
		private System.Windows.Forms.NumericUpDown widthValue;
		private System.Windows.Forms.GroupBox backgrundBox;
		private System.Windows.Forms.CheckBox backgrundChb;
		private System.Windows.Forms.Button colorBtn;
		private System.Windows.Forms.Panel colorBox;
	}
}