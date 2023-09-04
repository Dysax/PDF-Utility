using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PDF_Combiner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCombinePDF_Click(object sender, EventArgs e)
        {
            var fileList = lstPDFFiles.Items.Cast<string>().ToArray();

            // Check if PDF files are selected
            if (fileList == null || fileList.Length == 0)
            {
                MessageBox.Show("Please select PDF files to combine.");
                return; // Return early to avoid further execution
            }

            // Select the output file for combined PDF
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string outputFilePath = saveFileDialog.FileName;

                // Create a new document to hold the combined PDF
                try
                {
                    using (FileStream fs = new FileStream(outputFilePath, FileMode.Create))
                    using (Document document = new Document())
                    using (PdfCopy copy = new PdfCopy(document, fs))
                    {
                        document.Open();

                        foreach (string filePath in fileList)
                        {
                            using (PdfReader reader = new PdfReader(filePath))
                            {
                                for (int page = 1; page <= reader.NumberOfPages; page++)
                                {
                                    copy.AddPage(copy.GetImportedPage(reader, page));
                                }
                            }
                        }
                    }

                    MessageBox.Show("PDFs combined successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while combining PDFs: " + ex.Message);
                }
            }
        }

        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "PDF Files|*.pdf",
                Multiselect = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog.FileNames)
                {
                    lstPDFFiles.Items.Add(new ListItem(Path.GetFileName(file), file));

                }
            }
        }

        public class ListItem
        {
            public string Name { get; set; }
            public string Value { get; set; }

            public ListItem(string name, string value)
            {
                Name = name;
                Value = value;
            }

            public override string ToString()
            {
                return Name;
            }
        }




        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (lstPDFFiles.SelectedIndex > 0)
            {
                int index = lstPDFFiles.SelectedIndex;
                var item = lstPDFFiles.SelectedItem;
                lstPDFFiles.Items.RemoveAt(index);
                lstPDFFiles.Items.Insert(index - 1, item);
                lstPDFFiles.SelectedIndex = index - 1;
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (lstPDFFiles.SelectedIndex < lstPDFFiles.Items.Count - 1 && lstPDFFiles.SelectedIndex >= 0)
            {
                int index = lstPDFFiles.SelectedIndex;
                var item = lstPDFFiles.SelectedItem;
                lstPDFFiles.Items.RemoveAt(index);
                lstPDFFiles.Items.Insert(index + 1, item);
                lstPDFFiles.SelectedIndex = index + 1;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
