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
using Tyuiu.DolgushinVA.Sprint7.Project.V12.Lib;
namespace Tyuiu.DolgushinVA.Sprint7.Project.V12
{
    public partial class FormCharts : Form
    {
        public FormCharts()
        {
            InitializeComponent();
        }
        static string openFile;
        static int rows;
        static int columns;
        static string[,] matrix;
        DataService ds = new DataService();
        private void buttonOpenFile_DVA_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog_DVA.ShowDialog();
                openFile = openFileDialog_DVA.FileName;

                if (openFile != "")
                {
                    matrix = ds.LoadFromDataFile(openFile);
                    rows = matrix.GetLength(0);
                    columns = matrix.GetLength(1);
                    dataGridViewOpenDataBase_DVA.RowCount = rows + 1;
                    dataGridViewOpenDataBase_DVA.ColumnCount = columns + 1;

                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            dataGridViewOpenDataBase_DVA.Rows[i].Cells[j].Value = matrix[i, j];
                            dataGridViewOpenDataBase_DVA.Rows[i].Cells[j].Selected = false;
                        }
                    }
                    dataGridViewOpenDataBase_DVA.AutoResizeColumns();
                }
                else
                {
                    MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при загрузке файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonSaveFile_DVA_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog_DVA.FileName = ".csv";
                saveFileDialog_DVA.InitialDirectory = @":C";
                if (saveFileDialog_DVA.ShowDialog() == DialogResult.OK)
                {
                    string savepath = saveFileDialog_DVA.FileName;
                    if (File.Exists(savepath))
                    {
                        File.Delete(savepath);
                    }
                    int rows = dataGridViewOpenDataBase_DVA.RowCount;
                    int columns = dataGridViewOpenDataBase_DVA.ColumnCount;
                    StringBuilder strBuilder = new StringBuilder();
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            strBuilder.Append(dataGridViewOpenDataBase_DVA.Rows[i].Cells[j].Value);

                            if (j != columns - 1)
                            {
                                strBuilder.Append(";");
                            }
                        }
                        strBuilder.AppendLine();
                    }
                    File.WriteAllText(savepath, strBuilder.ToString(), Encoding.GetEncoding(1251));
                    MessageBox.Show("Файл успешно сохранен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Файл не сохранен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void toolStripMenuItemAbout_DVA_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }
        private void ToolStripMenuItemMainPage_DVA_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMain formMain = new FormMain();
            formMain.Show();

        }
        private void ToolStripMenuItemGuide_DVA_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormGuide formGuide = new FormGuide();
            formGuide.ShowDialog();
        }
        private void ToolStripMenuItemOpenFile_DVA_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog_DVA.ShowDialog();
                openFile = openFileDialog_DVA.FileName;

                if (openFile != "")
                {
                    matrix = ds.LoadFromDataFile(openFile);
                    rows = matrix.GetLength(0);
                    columns = matrix.GetLength(1);
                    dataGridViewOpenDataBase_DVA.RowCount = rows + 1;
                    dataGridViewOpenDataBase_DVA.ColumnCount = columns + 1;

                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            dataGridViewOpenDataBase_DVA.Rows[i].Cells[j].Value = matrix[i, j];
                            dataGridViewOpenDataBase_DVA.Rows[i].Cells[j].Selected = false;
                        }
                    }
                    dataGridViewOpenDataBase_DVA.AutoResizeColumns();
                }
                else
                {
                    MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при загрузке файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ToolStripMenuItemSaveFile_URI_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog_DVA.FileName = ".csv";
                saveFileDialog_DVA.InitialDirectory = @":C";
                if (saveFileDialog_DVA.ShowDialog() == DialogResult.OK)
                {
                    string savepath = saveFileDialog_DVA.FileName;
                    if (File.Exists(savepath))
                    {
                        File.Delete(savepath);
                    }
                    int rows = dataGridViewOpenDataBase_DVA.RowCount;
                    int columns = dataGridViewOpenDataBase_DVA.ColumnCount;
                    StringBuilder strBuilder = new StringBuilder();
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            strBuilder.Append(dataGridViewOpenDataBase_DVA.Rows[i].Cells[j].Value);

                            if (j != columns - 1)
                            {
                                strBuilder.Append(";");
                            }
                        }
                        strBuilder.AppendLine();
                    }
                    File.WriteAllText(savepath, strBuilder.ToString(), Encoding.GetEncoding(1251));
                    MessageBox.Show("Файл успешно сохранен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Файл не сохранен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
