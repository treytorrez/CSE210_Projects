//Remeber to comment heavily, possibly too much. explain what everything does

using System;
using System.Diagnostics;
using System.IO;


namespace CSE210JournalApp
{
    public partial class Form1 : Form
    {
        // field variables
        public string journalFilePath = "";
        Entry currentEntry = new Entry();

        // Constructors

        public Form1()
        {
            InitializeComponent();

        }

        // Event Handlers

        public void Form1_Load(object sender, EventArgs e)
        {

        }

        private void promptToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            currentEntry.entryContent = richTextBox1.Lines;
        }

        private void clearTextBox(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        public void setDirectory(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            // Show dialog and read selected folder
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                journalFilePath = folderBrowserDialog1.SelectedPath;
            }
        }

        public void saveTextArrayToFile(string[] textArray, string fileName)
        {
            string editTime = DateTime.Now.ToString();
            FileStream fileStream = new FileStream(fileName + "\\" + currentEntry.name + ".txt", FileMode.Create);

            StreamWriter writer = new StreamWriter(fileStream);

            if (currentEntry.entryContent[0].Contains("Last Edited") == false)
            {
                writer.WriteLine(currentEntry.name + $" Last Edited: {editTime}");
            }

            foreach (string line in textArray)
            {
                writer.WriteLine(line);
                Debug.WriteLine(line);
            }

            writer.Close();
        }

        public void newEntry(object sender, EventArgs e)
        {
            // Create a new entry object
            Entry newEntry = new Entry();

            // Set Entry as the current entry
            currentEntry = newEntry;

            // Prompt the user for a name
            newEntry.name = popupEntryBox();

            // Clear the text box
            richTextBox1.Text = "";
        }

        public void saveEntry(object sender, EventArgs e)
        {
            if (journalFilePath == "")
            {
                // Prompt the user for a directory
                // Display an error message box
                MessageBox.Show("Please Set Directory first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (currentEntry.name == "All Entries")
            {
                MessageBox.Show("An issue occured with file names. Please copy any content, create a new entry, and paste it there.");
            }
            else
            {
                // Save the current entry to a file
                saveTextArrayToFile(currentEntry.entryContent, journalFilePath);

            }
        }

        public void displayJournal(object sender, EventArgs e)
        {
            // Prompt the user for a directory
            if (journalFilePath == "")
            {
                MessageBox.Show("Please Set Directory first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Open the directory and read all files into a string array
            string[] journalFiles = Directory.GetFiles(journalFilePath, "*.txt");

            if (journalFiles.Length == 0)
            {
                MessageBox.Show("No files found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                Debug.WriteLine(journalFiles.Length);
                foreach (string s in journalFiles)
                {
                    Debug.WriteLine(s);
                }

                // Make an entry with each file combined
                Entry allEntries = new Entry();
                currentEntry = allEntries;
                allEntries.name = "All Entries";
                allEntries.entryContent = new string[0]; // Initialize the entryContent array

                foreach (string file in journalFiles)
                {
                    string[] fileContents = readTextArrayFromFile(file);

                    allEntries.entryContent = allEntries.entryContent.Concat(fileContents).ToArray();
                }

                // Display the string array in the text box
                displayTextArray(allEntries.entryContent);
            }
        }

        // Helper Methods

        public string[] readTextArrayFromFile(string fileName)
        {
            string[] textArray = File.ReadAllLines(fileName);

            return textArray;
        }

        public void displayTextArray(string[] textArray, bool clearBox = true)
        {
            if (clearBox)
            {
                richTextBox1.Text = "";
            }

            foreach (string s in textArray)
            {
                richTextBox1.Text += s + "\n";
            }
        }

        public string popupEntryBox()
        {
            string userinput = "";
            Form prompt = new Form();
            prompt.Width = 300;
            prompt.Height = 150;
            prompt.Text = "Enter Text";
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 200 };
            Button confirmButton = new Button() { Text = "OK", Left = 150, Width = 100, Top = 70 };
            confirmButton.Click += (sender, e) => { userinput = textBox.Text; prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmButton);

            // Show the dialog
            prompt.ShowDialog();

            return userinput;
        }
    }
}
