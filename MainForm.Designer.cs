namespace MovieBrowser;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
			this.thumbnailViewerControl = new MovieBrowser.ThumbnailViewerControl();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.buttonFileRoot = new System.Windows.Forms.Button();
			this.textFileRoot = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.buttonRebuild = new System.Windows.Forms.Button();
			this.buttonSearch = new System.Windows.Forms.Button();
			this.textQuery = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonOpenThumbnail = new System.Windows.Forms.Button();
			this.buttonOpenMetadata = new System.Windows.Forms.Button();
			this.textThumbnailFilename = new System.Windows.Forms.TextBox();
			this.textMetadataFilename = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.panel2 = new System.Windows.Forms.Panel();
			this.labelStatus = new System.Windows.Forms.Label();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// thumbnailViewerControl
			// 
			this.thumbnailViewerControl.AllowDrop = true;
			this.thumbnailViewerControl.AutoScroll = true;
			this.thumbnailViewerControl.AutoSize = true;
			this.thumbnailViewerControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.thumbnailViewerControl.Location = new System.Drawing.Point(0, 0);
			this.thumbnailViewerControl.Name = "thumbnailViewerControl";
			this.thumbnailViewerControl.Size = new System.Drawing.Size(786, 450);
			this.thumbnailViewerControl.TabIndex = 0;
			this.thumbnailViewerControl.OnOpen += new System.EventHandler<string>(this.thumbnailViewerControl_OnOpen);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.buttonFileRoot);
			this.panel1.Controls.Add(this.textFileRoot);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.buttonRebuild);
			this.panel1.Controls.Add(this.buttonSearch);
			this.panel1.Controls.Add(this.textQuery);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.buttonOpenThumbnail);
			this.panel1.Controls.Add(this.buttonOpenMetadata);
			this.panel1.Controls.Add(this.textThumbnailFilename);
			this.panel1.Controls.Add(this.textMetadataFilename);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(786, 137);
			this.panel1.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(74, 100);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 13;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// buttonFileRoot
			// 
			this.buttonFileRoot.Location = new System.Drawing.Point(315, 64);
			this.buttonFileRoot.Name = "buttonFileRoot";
			this.buttonFileRoot.Size = new System.Drawing.Size(26, 23);
			this.buttonFileRoot.TabIndex = 12;
			this.buttonFileRoot.Text = "...";
			this.buttonFileRoot.UseVisualStyleBackColor = true;
			this.buttonFileRoot.Click += new System.EventHandler(this.buttonFileRoot_Click);
			// 
			// textFileRoot
			// 
			this.textFileRoot.Location = new System.Drawing.Point(100, 63);
			this.textFileRoot.Name = "textFileRoot";
			this.textFileRoot.Size = new System.Drawing.Size(209, 23);
			this.textFileRoot.TabIndex = 11;
			this.textFileRoot.Text = "Z:\\m";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 67);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 15);
			this.label4.TabIndex = 10;
			this.label4.Text = "File Root";
			// 
			// buttonRebuild
			// 
			this.buttonRebuild.Location = new System.Drawing.Point(240, 102);
			this.buttonRebuild.Name = "buttonRebuild";
			this.buttonRebuild.Size = new System.Drawing.Size(69, 23);
			this.buttonRebuild.TabIndex = 9;
			this.buttonRebuild.Text = "Rebuild";
			this.buttonRebuild.UseVisualStyleBackColor = true;
			this.buttonRebuild.Click += new System.EventHandler(this.buttonRebuild_Click);
			// 
			// buttonSearch
			// 
			this.buttonSearch.Location = new System.Drawing.Point(717, 102);
			this.buttonSearch.Name = "buttonSearch";
			this.buttonSearch.Size = new System.Drawing.Size(51, 23);
			this.buttonSearch.TabIndex = 8;
			this.buttonSearch.Text = "Search";
			this.buttonSearch.UseVisualStyleBackColor = true;
			this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
			// 
			// textQuery
			// 
			this.textQuery.Location = new System.Drawing.Point(364, 34);
			this.textQuery.Multiline = true;
			this.textQuery.Name = "textQuery";
			this.textQuery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textQuery.Size = new System.Drawing.Size(347, 91);
			this.textQuery.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(364, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(39, 15);
			this.label3.TabIndex = 6;
			this.label3.Text = "Query";
			// 
			// buttonOpenThumbnail
			// 
			this.buttonOpenThumbnail.Location = new System.Drawing.Point(315, 35);
			this.buttonOpenThumbnail.Name = "buttonOpenThumbnail";
			this.buttonOpenThumbnail.Size = new System.Drawing.Size(26, 23);
			this.buttonOpenThumbnail.TabIndex = 5;
			this.buttonOpenThumbnail.Text = "...";
			this.buttonOpenThumbnail.UseVisualStyleBackColor = true;
			this.buttonOpenThumbnail.Click += new System.EventHandler(this.buttonOpenThumbnail_Click);
			// 
			// buttonOpenMetadata
			// 
			this.buttonOpenMetadata.Location = new System.Drawing.Point(315, 6);
			this.buttonOpenMetadata.Name = "buttonOpenMetadata";
			this.buttonOpenMetadata.Size = new System.Drawing.Size(26, 23);
			this.buttonOpenMetadata.TabIndex = 4;
			this.buttonOpenMetadata.Text = "...";
			this.buttonOpenMetadata.UseVisualStyleBackColor = true;
			this.buttonOpenMetadata.Click += new System.EventHandler(this.buttonOpenMetadata_Click);
			// 
			// textThumbnailFilename
			// 
			this.textThumbnailFilename.Location = new System.Drawing.Point(100, 34);
			this.textThumbnailFilename.Name = "textThumbnailFilename";
			this.textThumbnailFilename.Size = new System.Drawing.Size(209, 23);
			this.textThumbnailFilename.TabIndex = 3;
			this.textThumbnailFilename.Text = "H:\\src\\sboothza\\MovieBrowser\\data\\thumbs.db";
			// 
			// textMetadataFilename
			// 
			this.textMetadataFilename.Location = new System.Drawing.Point(100, 6);
			this.textMetadataFilename.Name = "textMetadataFilename";
			this.textMetadataFilename.Size = new System.Drawing.Size(209, 23);
			this.textMetadataFilename.TabIndex = 2;
			this.textMetadataFilename.Text = "H:\\src\\sboothza\\MovieBrowser\\data\\files.db";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 15);
			this.label2.TabIndex = 1;
			this.label2.Text = "Thumbnail Db";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Metadata Db";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.labelStatus);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 410);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(786, 40);
			this.panel2.TabIndex = 2;
			// 
			// labelStatus
			// 
			this.labelStatus.AutoSize = true;
			this.labelStatus.Location = new System.Drawing.Point(16, 9);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(22, 15);
			this.labelStatus.TabIndex = 0;
			this.labelStatus.Text = "Ok";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(786, 450);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.thumbnailViewerControl);
			this.MinimumSize = new System.Drawing.Size(802, 489);
			this.Name = "MainForm";
			this.Text = "Movie Browser";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

    }

	#endregion

	private ThumbnailViewerControl thumbnailViewerControl;
	private Panel panel1;
	private Button buttonSearch;
	private TextBox textQuery;
	private Label label3;
	private Button buttonOpenThumbnail;
	private Button buttonOpenMetadata;
	private TextBox textThumbnailFilename;
	private TextBox textMetadataFilename;
	private Label label2;
	private Label label1;
	private OpenFileDialog openFileDialog;
	private Panel panel2;
	private Label labelStatus;
	private Button buttonRebuild;
	private Button buttonFileRoot;
	private TextBox textFileRoot;
	private Label label4;
	private FolderBrowserDialog folderBrowserDialog;
	private Button button1;
}
