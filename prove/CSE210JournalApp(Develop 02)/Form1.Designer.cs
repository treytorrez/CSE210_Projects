namespace CSE210JournalApp
{
    partial class Form1
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
            richTextBox1 = new RichTextBox();
            menuStrip1 = new MenuStrip();
            openToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem1 = new ToolStripMenuItem();
            newEntryToolStripMenuItem = new ToolStripMenuItem();
            existingEntryToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem1 = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            promptToolStripMenuItem = new ToolStripMenuItem();
            clearTextboxToolStripMenuItem = new ToolStripMenuItem();
            setDirectoryToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.FromArgb(64, 64, 64);
            richTextBox1.BorderStyle = BorderStyle.FixedSingle;
            richTextBox1.Font = new Font("Microsoft YaHei", 12F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox1.ForeColor = SystemColors.Control;
            richTextBox1.Location = new Point(0, 28);
            richTextBox1.Margin = new Padding(6);
            richTextBox1.MinimumSize = new Size(100, 100);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(992, 544);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "Set your directory and create a New Entry with Menu > Open > New Entry";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(64, 64, 64);
            menuStrip1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip1.Items.AddRange(new ToolStripItem[] { openToolStripMenuItem, setDirectoryToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(11, 4, 0, 4);
            menuStrip1.Size = new Size(992, 27);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem1, saveAsToolStripMenuItem1, viewToolStripMenuItem, promptToolStripMenuItem, clearTextboxToolStripMenuItem });
            openToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            openToolStripMenuItem.ForeColor = SystemColors.Control;
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(51, 19);
            openToolStripMenuItem.Text = "Menu";
            // 
            // openToolStripMenuItem1
            // 
            openToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { newEntryToolStripMenuItem, existingEntryToolStripMenuItem });
            openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            openToolStripMenuItem1.Size = new Size(180, 22);
            openToolStripMenuItem1.Text = "Open";
            // 
            // newEntryToolStripMenuItem
            // 
            newEntryToolStripMenuItem.Name = "newEntryToolStripMenuItem";
            newEntryToolStripMenuItem.Size = new Size(149, 22);
            newEntryToolStripMenuItem.Text = "New Entry";
            newEntryToolStripMenuItem.Click += newEntry;
            // 
            // existingEntryToolStripMenuItem
            // 
            existingEntryToolStripMenuItem.Name = "existingEntryToolStripMenuItem";
            existingEntryToolStripMenuItem.Size = new Size(149, 22);
            existingEntryToolStripMenuItem.Text = "Existing Entry";
            // 
            // saveAsToolStripMenuItem1
            // 
            saveAsToolStripMenuItem1.Name = "saveAsToolStripMenuItem1";
            saveAsToolStripMenuItem1.Size = new Size(180, 22);
            saveAsToolStripMenuItem1.Text = "Save";
            saveAsToolStripMenuItem1.Click += saveEntry;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(180, 22);
            viewToolStripMenuItem.Text = "View Journal";
            viewToolStripMenuItem.Click += displayJournal;
            // 
            // promptToolStripMenuItem
            // 
            promptToolStripMenuItem.Name = "promptToolStripMenuItem";
            promptToolStripMenuItem.Size = new Size(180, 22);
            promptToolStripMenuItem.Text = "View Prompt";
            promptToolStripMenuItem.Click += promptToolStripMenuItem_Click;
            // 
            // clearTextboxToolStripMenuItem
            // 
            clearTextboxToolStripMenuItem.ForeColor = Color.Red;
            clearTextboxToolStripMenuItem.Name = "clearTextboxToolStripMenuItem";
            clearTextboxToolStripMenuItem.Size = new Size(180, 22);
            clearTextboxToolStripMenuItem.Text = "Clear Textbox";
            clearTextboxToolStripMenuItem.Click += clearTextBox;
            // 
            // setDirectoryToolStripMenuItem
            // 
            setDirectoryToolStripMenuItem.ForeColor = SystemColors.Control;
            setDirectoryToolStripMenuItem.Name = "setDirectoryToolStripMenuItem";
            setDirectoryToolStripMenuItem.Size = new Size(86, 19);
            setDirectoryToolStripMenuItem.Text = "Set Directory";
            setDirectoryToolStripMenuItem.Click += setDirectory;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(992, 569);
            Controls.Add(richTextBox1);
            Controls.Add(menuStrip1);
            Font = new Font("Microsoft YaHei", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(6);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem1;
        private ToolStripMenuItem newEntryToolStripMenuItem;
        private ToolStripMenuItem existingEntryToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem1;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem promptToolStripMenuItem;
        private ToolStripMenuItem setDirectoryToolStripMenuItem;
        private ToolStripMenuItem clearTextboxToolStripMenuItem;
    }
}