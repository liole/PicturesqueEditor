namespace Picturesque.Editor
{
	partial class LayerListItem
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayerListItem));
			this.preview = new System.Windows.Forms.PictureBox();
			this.splitter = new System.Windows.Forms.Splitter();
			this.layerTitle = new System.Windows.Forms.Label();
			this.visibleBtn = new System.Windows.Forms.CheckBox();
			this.maskIcon = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.preview)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.maskIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// preview
			// 
			this.preview.BackColor = System.Drawing.Color.White;
			this.preview.Location = new System.Drawing.Point(25, 3);
			this.preview.Name = "preview";
			this.preview.Size = new System.Drawing.Size(43, 43);
			this.preview.TabIndex = 0;
			this.preview.TabStop = false;
			this.preview.Paint += new System.Windows.Forms.PaintEventHandler(this.preview_Paint);
			// 
			// splitter
			// 
			this.splitter.BackColor = System.Drawing.Color.Silver;
			this.splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter.Enabled = false;
			this.splitter.Location = new System.Drawing.Point(0, 49);
			this.splitter.Name = "splitter";
			this.splitter.Size = new System.Drawing.Size(200, 1);
			this.splitter.TabIndex = 1;
			this.splitter.TabStop = false;
			// 
			// layerTitle
			// 
			this.layerTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.layerTitle.AutoEllipsis = true;
			this.layerTitle.ForeColor = System.Drawing.Color.White;
			this.layerTitle.Location = new System.Drawing.Point(74, 4);
			this.layerTitle.Name = "layerTitle";
			this.layerTitle.Size = new System.Drawing.Size(123, 42);
			this.layerTitle.TabIndex = 2;
			this.layerTitle.Text = "Layer 1";
			this.layerTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.layerTitle.Click += new System.EventHandler(this.layerTitle_Click);
			// 
			// visibleBtn
			// 
			this.visibleBtn.Appearance = System.Windows.Forms.Appearance.Button;
			this.visibleBtn.FlatAppearance.BorderSize = 0;
			this.visibleBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.visibleBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.visibleBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
			this.visibleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.visibleBtn.Image = ((System.Drawing.Image)(resources.GetObject("visibleBtn.Image")));
			this.visibleBtn.Location = new System.Drawing.Point(0, 9);
			this.visibleBtn.Name = "visibleBtn";
			this.visibleBtn.Size = new System.Drawing.Size(24, 32);
			this.visibleBtn.TabIndex = 3;
			this.visibleBtn.Text = "        ";
			this.visibleBtn.UseVisualStyleBackColor = true;
			this.visibleBtn.Click += new System.EventHandler(this.visibleBtn_Click);
			// 
			// maskIcon
			// 
			this.maskIcon.Image = ((System.Drawing.Image)(resources.GetObject("maskIcon.Image")));
			this.maskIcon.Location = new System.Drawing.Point(49, 29);
			this.maskIcon.Name = "maskIcon";
			this.maskIcon.Size = new System.Drawing.Size(24, 24);
			this.maskIcon.TabIndex = 4;
			this.maskIcon.TabStop = false;
			// 
			// LayerListItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.visibleBtn);
			this.Controls.Add(this.layerTitle);
			this.Controls.Add(this.splitter);
			this.Controls.Add(this.preview);
			this.Controls.Add(this.maskIcon);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.MinimumSize = new System.Drawing.Size(100, 50);
			this.Name = "LayerListItem";
			this.Size = new System.Drawing.Size(200, 50);
			((System.ComponentModel.ISupportInitialize)(this.preview)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.maskIcon)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox preview;
		private System.Windows.Forms.Splitter splitter;
		private System.Windows.Forms.Label layerTitle;
		private System.Windows.Forms.CheckBox visibleBtn;
		private System.Windows.Forms.PictureBox maskIcon;
	}
}
