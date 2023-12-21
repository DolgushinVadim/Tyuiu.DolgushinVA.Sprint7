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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        static string openFile;
        static int rows;
        static int columns;
        static string[,] matrix;
        DataService ds = new DataService();
        private void buttonAddRow_DVA_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    dataGridViewOpenDataBase_DVA.Rows.Add();
                }
                catch
                {
                    MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void buttonDeleteRow_DVA_Click(object sender, EventArgs e)
        {
            if (dataGridViewOpenDataBase_DVA.RowCount != 0)
            {
                int del = 0;
                var result = MessageBox.Show($"{"Удалить данную строку?\rЕё невозможно будет восстановить"}", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) del = 1;
                if (del == 1)
                {
                    int a = dataGridViewOpenDataBase_DVA.CurrentCell.RowIndex;
                    dataGridViewOpenDataBase_DVA.Rows.RemoveAt(a);
                }
            }
            else
            {
                MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                    dataGridViewOpenDataBase_DVA.RowCount = rows;
                    dataGridViewOpenDataBase_DVA.ColumnCount = columns;

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
                    StringBuilder StrBuilder = new StringBuilder();
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            StrBuilder.Append(dataGridViewOpenDataBase_DVA.Rows[i].Cells[j].Value);

                            if (j != columns - 1) StrBuilder.Append(";");
                        }
                        StrBuilder.AppendLine();
                    }
                    File.WriteAllText(savepath, StrBuilder.ToString(), Encoding.GetEncoding(1251));
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
