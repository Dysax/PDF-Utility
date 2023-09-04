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
            var fileList = lstPDFFiles.Items.Cast<ListItem>().Select(item => item.Value).ToArray();


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

        private void btnAddPDFForSeparation_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "PDF Files|*.pdf",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                lstPages.Items.Clear();
                using (PdfReader reader = new PdfReader(openFileDialog.FileName))
                {
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        lstPages.Items.Add($"Page {i}");
                    }
                }
                lstPages.Tag = openFileDialog.FileName; // Use Tag property to store the path of the selected PDF
            }
        }

        private void btnSeparatePDF_Click(object sender, EventArgs e)
        {
            if (lstPages.Items.Count == 0 || lstPages.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select pages to separate.");
                return;
            }

            string sourcePdf = lstPages.Tag.ToString();

            using (PdfReader reader = new PdfReader(sourcePdf))
            {
                foreach (var item in lstPages.SelectedItems)
                {
                    string[] words = item.ToString().Split(' ');
                    int pageIndex = int.Parse(words[1]); // Assuming the format is "Page {number}"

                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "PDF Files|*.pdf",
                        FileName = $"Page_{pageIndex}.pdf"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string outputFilePath = saveFileDialog.FileName;

                        using (FileStream fs = new FileStream(outputFilePath, FileMode.Create))
                        using (Document document = new Document())
                        using (PdfCopy copy = new PdfCopy(document, fs))
                        {
                            document.Open();
                            copy.AddPage(copy.GetImportedPage(reader, pageIndex));
                        }
                    }
                }
            }
            MessageBox.Show("Pages separated successfully.");
        }
    }
}
