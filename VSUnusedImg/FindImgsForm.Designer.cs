namespace JitbitSoftware.VSUnusedImg
{
	partial class FindImgsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindImgsForm));
			this.lstImages = new System.Windows.Forms.ListBox();
			this.btnStart = new System.Windows.Forms.Button();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.label1 = new System.Windows.Forms.Label();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnDeleteSelected = new System.Windows.Forms.Button();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lstImages
			// 
			this.lstImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstImages.FormattingEnabled = true;
			this.lstImages.Location = new System.Drawing.Point(12, 74);
			this.lstImages.Name = "lstImages";
			this.lstImages.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lstImages.Size = new System.Drawing.Size(333, 134);
			this.lstImages.TabIndex = 0;
			this.lstImages.SelectedIndexChanged += new System.EventHandler(this.lstImages_SelectedIndexChanged);
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(12, 12);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(75, 23);
			this.btnStart.TabIndex = 1;
			this.btnStart.Text = "Search!";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(93, 12);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(252, 23);
			this.progressBar1.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 55);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Unused images:";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 240);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(357, 22);
			this.statusStrip1.TabIndex = 4;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(48, 17);
			this.toolStripStatusLabel1.Text = "Ready...";
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelete.Enabled = false;
			this.btnDelete.Location = new System.Drawing.Point(190, 214);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(155, 23);
			this.btnDelete.TabIndex = 5;
			this.btnDelete.Text = "Delete all unused images";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnDeleteSelected
			// 
			this.btnDeleteSelected.Enabled = false;
			this.btnDeleteSelected.Location = new System.Drawing.Point(12, 214);
			this.btnDeleteSelected.Name = "btnDeleteSelected";
			this.btnDeleteSelected.Size = new System.Drawing.Size(172, 23);
			this.btnDeleteSelected.TabIndex = 6;
			this.btnDeleteSelected.Text = "Delete selected";
			this.btnDeleteSelected.UseVisualStyleBackColor = true;
			this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
			// 
			// FindImgsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(357, 262);
			this.Controls.Add(this.btnDeleteSelected);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.lstImages);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FindImgsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Unused images";
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox lstImages;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnDeleteSelected;
	}
}