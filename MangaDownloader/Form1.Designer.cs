﻿namespace MangaDownloader
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxLink = new System.Windows.Forms.TextBox();
            this.buttonChecking = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnDownload = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnTom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnChapter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLink = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.buttonDontSelect = new System.Windows.Forms.Button();
            this.progressBarToms = new System.Windows.Forms.ProgressBar();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelIndicatorTom = new System.Windows.Forms.Label();
            this.progressBarChapters = new System.Windows.Forms.ProgressBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripConsole = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sdfsdfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dsgsdgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sdgsdgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxLink
            // 
            this.textBoxLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLink.Location = new System.Drawing.Point(13, 35);
            this.textBoxLink.Multiline = true;
            this.textBoxLink.Name = "textBoxLink";
            this.textBoxLink.Size = new System.Drawing.Size(697, 32);
            this.textBoxLink.TabIndex = 0;
            // 
            // buttonChecking
            // 
            this.buttonChecking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChecking.Location = new System.Drawing.Point(716, 35);
            this.buttonChecking.Name = "buttonChecking";
            this.buttonChecking.Size = new System.Drawing.Size(75, 32);
            this.buttonChecking.TabIndex = 1;
            this.buttonChecking.Text = "Checking";
            this.buttonChecking.UseVisualStyleBackColor = true;
            this.buttonChecking.Click += new System.EventHandler(this.buttonChecking_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDownload,
            this.ColumnTom,
            this.ColumnChapter,
            this.ColumnName,
            this.ColumnData,
            this.ColumnLink});
            this.dataGridView1.Location = new System.Drawing.Point(274, 102);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(517, 447);
            this.dataGridView1.TabIndex = 2;
            // 
            // ColumnDownload
            // 
            this.ColumnDownload.FillWeight = 60F;
            this.ColumnDownload.HeaderText = "Download";
            this.ColumnDownload.Name = "ColumnDownload";
            // 
            // ColumnTom
            // 
            this.ColumnTom.FillWeight = 40F;
            this.ColumnTom.HeaderText = "Tom";
            this.ColumnTom.Name = "ColumnTom";
            // 
            // ColumnChapter
            // 
            this.ColumnChapter.FillWeight = 50F;
            this.ColumnChapter.HeaderText = "Chapter";
            this.ColumnChapter.Name = "ColumnChapter";
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            // 
            // ColumnData
            // 
            this.ColumnData.HeaderText = "Data";
            this.ColumnData.Name = "ColumnData";
            // 
            // ColumnLink
            // 
            this.ColumnLink.HeaderText = "ColumnLink";
            this.ColumnLink.Name = "ColumnLink";
            this.ColumnLink.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox1.Location = new System.Drawing.Point(13, 73);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(255, 476);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(274, 73);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(75, 23);
            this.buttonSelect.TabIndex = 4;
            this.buttonSelect.Text = "Select";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // buttonDontSelect
            // 
            this.buttonDontSelect.Location = new System.Drawing.Point(355, 73);
            this.buttonDontSelect.Name = "buttonDontSelect";
            this.buttonDontSelect.Size = new System.Drawing.Size(75, 23);
            this.buttonDontSelect.TabIndex = 5;
            this.buttonDontSelect.Text = "dont select";
            this.buttonDontSelect.UseVisualStyleBackColor = true;
            this.buttonDontSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // progressBarToms
            // 
            this.progressBarToms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarToms.Location = new System.Drawing.Point(149, 567);
            this.progressBarToms.Maximum = 0;
            this.progressBarToms.Name = "progressBarToms";
            this.progressBarToms.Size = new System.Drawing.Size(561, 12);
            this.progressBarToms.TabIndex = 7;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(436, 78);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(57, 13);
            this.labelName.TabIndex = 9;
            this.labelName.Text = "labelName";
            // 
            // buttonDownload
            // 
            this.buttonDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDownload.Location = new System.Drawing.Point(716, 555);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(75, 24);
            this.buttonDownload.TabIndex = 6;
            this.buttonDownload.Text = "Download";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.Location = new System.Drawing.Point(13, 555);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 24);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelIndicatorTom
            // 
            this.labelIndicatorTom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelIndicatorTom.AutoSize = true;
            this.labelIndicatorTom.Location = new System.Drawing.Point(94, 567);
            this.labelIndicatorTom.Name = "labelIndicatorTom";
            this.labelIndicatorTom.Size = new System.Drawing.Size(35, 13);
            this.labelIndicatorTom.TabIndex = 11;
            this.labelIndicatorTom.Text = "label1";
            // 
            // progressBarChapters
            // 
            this.progressBarChapters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarChapters.Location = new System.Drawing.Point(149, 555);
            this.progressBarChapters.Maximum = 0;
            this.progressBarChapters.Name = "progressBarChapters";
            this.progressBarChapters.Size = new System.Drawing.Size(561, 12);
            this.progressBarChapters.TabIndex = 12;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripConsole});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(803, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripConsole
            // 
            this.toolStripConsole.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripConsole.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.toolStripConsole.Image = ((System.Drawing.Image)(resources.GetObject("toolStripConsole.Image")));
            this.toolStripConsole.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripConsole.Name = "toolStripConsole";
            this.toolStripConsole.Size = new System.Drawing.Size(63, 22);
            this.toolStripConsole.Text = "Console";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sdfsdfToolStripMenuItem,
            this.dsgsdgToolStripMenuItem,
            this.sdgsdgToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // sdfsdfToolStripMenuItem
            // 
            this.sdfsdfToolStripMenuItem.Name = "sdfsdfToolStripMenuItem";
            this.sdfsdfToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.sdfsdfToolStripMenuItem.Text = "sdfsdf";
            // 
            // dsgsdgToolStripMenuItem
            // 
            this.dsgsdgToolStripMenuItem.Name = "dsgsdgToolStripMenuItem";
            this.dsgsdgToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.dsgsdgToolStripMenuItem.Text = "dsgsdg";
            // 
            // sdgsdgToolStripMenuItem
            // 
            this.sdgsdgToolStripMenuItem.Name = "sdgsdgToolStripMenuItem";
            this.sdgsdgToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.sdgsdgToolStripMenuItem.Text = "sdgsdg";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 591);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.progressBarChapters);
            this.Controls.Add(this.labelIndicatorTom);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.progressBarToms);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.buttonDontSelect);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonChecking);
            this.Controls.Add(this.textBoxLink);
            this.MinimumSize = new System.Drawing.Size(460, 468);
            this.Name = "Form1";
            this.Text = "Загрузчик контента";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLink;
        private System.Windows.Forms.Button buttonChecking;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnDownload;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTom;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnChapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnData;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLink;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Button buttonDontSelect;
        private System.Windows.Forms.ProgressBar progressBarToms;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelIndicatorTom;
        private System.Windows.Forms.ProgressBar progressBarChapters;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripConsole;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sdfsdfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dsgsdgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sdgsdgToolStripMenuItem;
    }
}

