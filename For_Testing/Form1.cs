using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace For_Testing
{
    public partial class TxtRedactorForm : Form
    {
        public TxtRedactorForm()
        {
            InitializeComponent();
            closeButton.BackColor = Color.Red;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Txt files (*.txt)|*.txt";
            saveDialog.FilterIndex = 2;
            saveDialog.RestoreDirectory = true;
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveDialog.FileName))
                {
                    sw.WriteLine(textBox1.Text);
                }
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Close current file? All unsaved changes will be discarded!", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Txt files (*.txt)|*.txt";
            openDialog.FilterIndex = 2;
            openDialog.RestoreDirectory = true;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(openDialog.FileName))
                {
                    textBox1.Text = sr.ReadToEnd();
                }
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Close current file and clear area? All unsaved changes will be discarded!", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            textBox1.Clear();

            //09.02.07.30.016
        }
    }
}
