namespace MarkdownTable
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.tabMain = new System.Windows.Forms.TabControl();
			this.tabMain_pageMarkdown = new System.Windows.Forms.TabPage();
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.inputMarkdown = new System.Windows.Forms.TextBox();
			this.toolMarkdown = new System.Windows.Forms.ToolStrip();
			this.toolMarkdown_itemCopy = new System.Windows.Forms.ToolStripButton();
			this.toolMarkdown_itemPaste = new System.Windows.Forms.ToolStripButton();
			this.tabMain_pageGrid = new System.Windows.Forms.TabPage();
			this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
			this.gridGrid = new System.Windows.Forms.DataGridView();
			this.toolGrid = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.toolGrid_itemRowInsert = new System.Windows.Forms.ToolStripButton();
			this.toolGrid_itemRowMoveUp = new System.Windows.Forms.ToolStripButton();
			this.toolGrid_itemRowMoveDown = new System.Windows.Forms.ToolStripButton();
			this.toolGrid_itemRowRemove = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.toolGrid_itemColumnAdd = new System.Windows.Forms.ToolStripButton();
			this.toolGrid_itemColumnRename = new System.Windows.Forms.ToolStripButton();
			this.toolGrid_itemColumnRemove = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolGrid_itemAlignLeft = new System.Windows.Forms.ToolStripButton();
			this.toolGrid_itemAlignCenter = new System.Windows.Forms.ToolStripButton();
			this.toolGrid_itemAlignRight = new System.Windows.Forms.ToolStripButton();
			this.tabMain.SuspendLayout();
			this.tabMain_pageMarkdown.SuspendLayout();
			this.toolStripContainer1.ContentPanel.SuspendLayout();
			this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.toolMarkdown.SuspendLayout();
			this.tabMain_pageGrid.SuspendLayout();
			this.toolStripContainer2.ContentPanel.SuspendLayout();
			this.toolStripContainer2.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridGrid)).BeginInit();
			this.toolGrid.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabMain
			// 
			this.tabMain.Controls.Add(this.tabMain_pageMarkdown);
			this.tabMain.Controls.Add(this.tabMain_pageGrid);
			this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabMain.Location = new System.Drawing.Point(0, 0);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(460, 262);
			this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tabMain.TabIndex = 0;
			this.tabMain.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabMain_Selecting);
			// 
			// tabMain_pageMarkdown
			// 
			this.tabMain_pageMarkdown.Controls.Add(this.toolStripContainer1);
			this.tabMain_pageMarkdown.Location = new System.Drawing.Point(4, 22);
			this.tabMain_pageMarkdown.Name = "tabMain_pageMarkdown";
			this.tabMain_pageMarkdown.Size = new System.Drawing.Size(452, 236);
			this.tabMain_pageMarkdown.TabIndex = 0;
			this.tabMain_pageMarkdown.Text = "Markdown";
			this.tabMain_pageMarkdown.UseVisualStyleBackColor = true;
			// 
			// toolStripContainer1
			// 
			this.toolStripContainer1.BottomToolStripPanelVisible = false;
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.Controls.Add(this.inputMarkdown);
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(452, 211);
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer1.LeftToolStripPanelVisible = false;
			this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.RightToolStripPanelVisible = false;
			this.toolStripContainer1.Size = new System.Drawing.Size(452, 236);
			this.toolStripContainer1.TabIndex = 0;
			this.toolStripContainer1.Text = "toolStripContainer1";
			// 
			// toolStripContainer1.TopToolStripPanel
			// 
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolMarkdown);
			// 
			// inputMarkdown
			// 
			this.inputMarkdown.Dock = System.Windows.Forms.DockStyle.Fill;
			this.inputMarkdown.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.inputMarkdown.Location = new System.Drawing.Point(0, 0);
			this.inputMarkdown.Multiline = true;
			this.inputMarkdown.Name = "inputMarkdown";
			this.inputMarkdown.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.inputMarkdown.Size = new System.Drawing.Size(452, 211);
			this.inputMarkdown.TabIndex = 0;
			this.inputMarkdown.WordWrap = false;
			// 
			// toolMarkdown
			// 
			this.toolMarkdown.Dock = System.Windows.Forms.DockStyle.None;
			this.toolMarkdown.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolMarkdown.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolMarkdown_itemCopy,
            this.toolMarkdown_itemPaste});
			this.toolMarkdown.Location = new System.Drawing.Point(0, 0);
			this.toolMarkdown.Name = "toolMarkdown";
			this.toolMarkdown.Size = new System.Drawing.Size(452, 25);
			this.toolMarkdown.Stretch = true;
			this.toolMarkdown.TabIndex = 0;
			// 
			// toolMarkdown_itemCopy
			// 
			this.toolMarkdown_itemCopy.Image = global::MarkdownTable.Properties.Resources.Image_copy;
			this.toolMarkdown_itemCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolMarkdown_itemCopy.Name = "toolMarkdown_itemCopy";
			this.toolMarkdown_itemCopy.Size = new System.Drawing.Size(64, 22);
			this.toolMarkdown_itemCopy.Text = "コピー";
			this.toolMarkdown_itemCopy.Click += new System.EventHandler(this.toolMarkdown_itemCopy_Click);
			// 
			// toolMarkdown_itemPaste
			// 
			this.toolMarkdown_itemPaste.Image = global::MarkdownTable.Properties.Resources.Image_paste;
			this.toolMarkdown_itemPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolMarkdown_itemPaste.Name = "toolMarkdown_itemPaste";
			this.toolMarkdown_itemPaste.Size = new System.Drawing.Size(76, 22);
			this.toolMarkdown_itemPaste.Text = "貼り付け";
			this.toolMarkdown_itemPaste.Click += new System.EventHandler(this.toolMarkdown_itemPaste_Click);
			// 
			// tabMain_pageGrid
			// 
			this.tabMain_pageGrid.Controls.Add(this.toolStripContainer2);
			this.tabMain_pageGrid.Location = new System.Drawing.Point(4, 22);
			this.tabMain_pageGrid.Name = "tabMain_pageGrid";
			this.tabMain_pageGrid.Size = new System.Drawing.Size(452, 236);
			this.tabMain_pageGrid.TabIndex = 1;
			this.tabMain_pageGrid.Text = "グリッド";
			this.tabMain_pageGrid.UseVisualStyleBackColor = true;
			// 
			// toolStripContainer2
			// 
			this.toolStripContainer2.BottomToolStripPanelVisible = false;
			// 
			// toolStripContainer2.ContentPanel
			// 
			this.toolStripContainer2.ContentPanel.Controls.Add(this.gridGrid);
			this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(452, 211);
			this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer2.LeftToolStripPanelVisible = false;
			this.toolStripContainer2.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer2.Name = "toolStripContainer2";
			this.toolStripContainer2.RightToolStripPanelVisible = false;
			this.toolStripContainer2.Size = new System.Drawing.Size(452, 236);
			this.toolStripContainer2.TabIndex = 0;
			this.toolStripContainer2.Text = "toolStripContainer2";
			// 
			// toolStripContainer2.TopToolStripPanel
			// 
			this.toolStripContainer2.TopToolStripPanel.Controls.Add(this.toolGrid);
			// 
			// gridGrid
			// 
			this.gridGrid.AllowUserToOrderColumns = true;
			this.gridGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			this.gridGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridGrid.Location = new System.Drawing.Point(0, 0);
			this.gridGrid.Name = "gridGrid";
			this.gridGrid.RowTemplate.Height = 21;
			this.gridGrid.Size = new System.Drawing.Size(452, 211);
			this.gridGrid.TabIndex = 0;
			this.gridGrid.SelectionChanged += new System.EventHandler(this.gridGrid_SelectionChanged);
			this.gridGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridGrid_KeyDown);
			// 
			// toolGrid
			// 
			this.toolGrid.Dock = System.Windows.Forms.DockStyle.None;
			this.toolGrid.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolGrid_itemRowInsert,
            this.toolGrid_itemRowMoveUp,
            this.toolGrid_itemRowMoveDown,
            this.toolGrid_itemRowRemove,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.toolGrid_itemColumnAdd,
            this.toolGrid_itemColumnRename,
            this.toolGrid_itemColumnRemove,
            this.toolStripSeparator1,
            this.toolGrid_itemAlignLeft,
            this.toolGrid_itemAlignCenter,
            this.toolGrid_itemAlignRight});
			this.toolGrid.Location = new System.Drawing.Point(0, 0);
			this.toolGrid.Name = "toolGrid";
			this.toolGrid.Size = new System.Drawing.Size(452, 25);
			this.toolGrid.Stretch = true;
			this.toolGrid.TabIndex = 1;
			// 
			// toolStripLabel2
			// 
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(25, 22);
			this.toolStripLabel2.Text = "行:";
			// 
			// toolGrid_itemRowInsert
			// 
			this.toolGrid_itemRowInsert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolGrid_itemRowInsert.Image = global::MarkdownTable.Properties.Resources.Image_text_padding_top;
			this.toolGrid_itemRowInsert.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolGrid_itemRowInsert.Name = "toolGrid_itemRowInsert";
			this.toolGrid_itemRowInsert.Size = new System.Drawing.Size(23, 22);
			this.toolGrid_itemRowInsert.Text = "行を追加";
			this.toolGrid_itemRowInsert.Click += new System.EventHandler(this.toolGrid_itemRowInsert_Click);
			// 
			// toolGrid_itemRowMoveUp
			// 
			this.toolGrid_itemRowMoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolGrid_itemRowMoveUp.Enabled = false;
			this.toolGrid_itemRowMoveUp.Image = global::MarkdownTable.Properties.Resources.Image_arrow_up;
			this.toolGrid_itemRowMoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolGrid_itemRowMoveUp.Name = "toolGrid_itemRowMoveUp";
			this.toolGrid_itemRowMoveUp.Size = new System.Drawing.Size(23, 22);
			this.toolGrid_itemRowMoveUp.Text = "選択行を上へ [Alt + ↑]";
			this.toolGrid_itemRowMoveUp.Click += new System.EventHandler(this.toolGrid_itemRowMoveUp_Click);
			// 
			// toolGrid_itemRowMoveDown
			// 
			this.toolGrid_itemRowMoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolGrid_itemRowMoveDown.Enabled = false;
			this.toolGrid_itemRowMoveDown.Image = global::MarkdownTable.Properties.Resources.Image_arrow_down;
			this.toolGrid_itemRowMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolGrid_itemRowMoveDown.Name = "toolGrid_itemRowMoveDown";
			this.toolGrid_itemRowMoveDown.Size = new System.Drawing.Size(23, 22);
			this.toolGrid_itemRowMoveDown.Text = "選択行を下へ [Alt + ↓]";
			this.toolGrid_itemRowMoveDown.Click += new System.EventHandler(this.toolGrid_itemRowMoveDown_Click);
			// 
			// toolGrid_itemRowRemove
			// 
			this.toolGrid_itemRowRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolGrid_itemRowRemove.Image = global::MarkdownTable.Properties.Resources.Image_cross;
			this.toolGrid_itemRowRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolGrid_itemRowRemove.Name = "toolGrid_itemRowRemove";
			this.toolGrid_itemRowRemove.Size = new System.Drawing.Size(23, 22);
			this.toolGrid_itemRowRemove.Text = "選択行を削除";
			this.toolGrid_itemRowRemove.Click += new System.EventHandler(this.toolGrid_itemRowRemove_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(25, 22);
			this.toolStripLabel1.Text = "列:";
			// 
			// toolGrid_itemColumnAdd
			// 
			this.toolGrid_itemColumnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolGrid_itemColumnAdd.Image = global::MarkdownTable.Properties.Resources.Image_add;
			this.toolGrid_itemColumnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolGrid_itemColumnAdd.Name = "toolGrid_itemColumnAdd";
			this.toolGrid_itemColumnAdd.Size = new System.Drawing.Size(23, 22);
			this.toolGrid_itemColumnAdd.Text = "右端のセルが選択されている状態で Alt + →";
			this.toolGrid_itemColumnAdd.Click += new System.EventHandler(this.toolGrid_itemColumnAdd_Click);
			// 
			// toolGrid_itemColumnRename
			// 
			this.toolGrid_itemColumnRename.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolGrid_itemColumnRename.Enabled = false;
			this.toolGrid_itemColumnRename.Image = global::MarkdownTable.Properties.Resources.Image_pencil;
			this.toolGrid_itemColumnRename.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolGrid_itemColumnRename.Name = "toolGrid_itemColumnRename";
			this.toolGrid_itemColumnRename.Size = new System.Drawing.Size(23, 22);
			this.toolGrid_itemColumnRename.Text = "列名を編集 [Shift + F2]";
			this.toolGrid_itemColumnRename.Click += new System.EventHandler(this.toolGrid_itemColumnRename_Click);
			// 
			// toolGrid_itemColumnRemove
			// 
			this.toolGrid_itemColumnRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolGrid_itemColumnRemove.Image = global::MarkdownTable.Properties.Resources.Image_cross;
			this.toolGrid_itemColumnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolGrid_itemColumnRemove.Name = "toolGrid_itemColumnRemove";
			this.toolGrid_itemColumnRemove.Size = new System.Drawing.Size(23, 22);
			this.toolGrid_itemColumnRemove.Text = "選択列を削除";
			this.toolGrid_itemColumnRemove.Click += new System.EventHandler(this.toolGrid_itemColumnRemove_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolGrid_itemAlignLeft
			// 
			this.toolGrid_itemAlignLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolGrid_itemAlignLeft.Image = global::MarkdownTable.Properties.Resources.Image_text_align_left;
			this.toolGrid_itemAlignLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolGrid_itemAlignLeft.Name = "toolGrid_itemAlignLeft";
			this.toolGrid_itemAlignLeft.Size = new System.Drawing.Size(23, 22);
			this.toolGrid_itemAlignLeft.Text = "選択列を左寄せ";
			this.toolGrid_itemAlignLeft.Click += new System.EventHandler(this.toolGrid_itemAlignLeft_Click);
			// 
			// toolGrid_itemAlignCenter
			// 
			this.toolGrid_itemAlignCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolGrid_itemAlignCenter.Image = global::MarkdownTable.Properties.Resources.Image_text_align_center;
			this.toolGrid_itemAlignCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolGrid_itemAlignCenter.Name = "toolGrid_itemAlignCenter";
			this.toolGrid_itemAlignCenter.Size = new System.Drawing.Size(23, 22);
			this.toolGrid_itemAlignCenter.Text = "選択列を中央寄せ";
			this.toolGrid_itemAlignCenter.Click += new System.EventHandler(this.toolGrid_itemAlignCenter_Click);
			// 
			// toolGrid_itemAlignRight
			// 
			this.toolGrid_itemAlignRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolGrid_itemAlignRight.Image = global::MarkdownTable.Properties.Resources.Image_text_align_right;
			this.toolGrid_itemAlignRight.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolGrid_itemAlignRight.Name = "toolGrid_itemAlignRight";
			this.toolGrid_itemAlignRight.Size = new System.Drawing.Size(23, 22);
			this.toolGrid_itemAlignRight.Text = "選択列を右寄せ";
			this.toolGrid_itemAlignRight.Click += new System.EventHandler(this.toolGrid_itemAlignRight_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(460, 262);
			this.Controls.Add(this.tabMain);
			this.Name = "Form1";
			this.Text = "まーくだうんてーぶる☆彡";
			this.tabMain.ResumeLayout(false);
			this.tabMain_pageMarkdown.ResumeLayout(false);
			this.toolStripContainer1.ContentPanel.ResumeLayout(false);
			this.toolStripContainer1.ContentPanel.PerformLayout();
			this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.PerformLayout();
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.toolMarkdown.ResumeLayout(false);
			this.toolMarkdown.PerformLayout();
			this.tabMain_pageGrid.ResumeLayout(false);
			this.toolStripContainer2.ContentPanel.ResumeLayout(false);
			this.toolStripContainer2.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer2.TopToolStripPanel.PerformLayout();
			this.toolStripContainer2.ResumeLayout(false);
			this.toolStripContainer2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridGrid)).EndInit();
			this.toolGrid.ResumeLayout(false);
			this.toolGrid.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabMain;
		private System.Windows.Forms.TabPage tabMain_pageMarkdown;
		private System.Windows.Forms.TabPage tabMain_pageGrid;
		private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private System.Windows.Forms.ToolStripContainer toolStripContainer2;
		private System.Windows.Forms.TextBox inputMarkdown;
		private System.Windows.Forms.ToolStrip toolMarkdown;
		private System.Windows.Forms.ToolStrip toolGrid;
		private System.Windows.Forms.DataGridView gridGrid;
		private System.Windows.Forms.ToolStripButton toolGrid_itemColumnAdd;
		private System.Windows.Forms.ToolStripButton toolGrid_itemColumnRemove;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton toolGrid_itemAlignLeft;
		private System.Windows.Forms.ToolStripButton toolGrid_itemAlignCenter;
		private System.Windows.Forms.ToolStripButton toolGrid_itemAlignRight;
		private System.Windows.Forms.ToolStripButton toolGrid_itemColumnRename;
		private System.Windows.Forms.ToolStripButton toolMarkdown_itemCopy;
		private System.Windows.Forms.ToolStripButton toolMarkdown_itemPaste;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton toolGrid_itemRowMoveUp;
		private System.Windows.Forms.ToolStripButton toolGrid_itemRowMoveDown;
		private System.Windows.Forms.ToolStripButton toolGrid_itemRowInsert;
		private System.Windows.Forms.ToolStripButton toolGrid_itemRowRemove;
		private System.Windows.Forms.ToolStripLabel toolStripLabel2;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
	}
}

