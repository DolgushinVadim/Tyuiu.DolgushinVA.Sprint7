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
                    matrix = ds.LoadDataBase(openFile);
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
        private void buttonAddChart_DVA_Click(object sender, EventArgs e)
        {
            if (dataGridViewOpenDataBase_DVA.RowCount != 0)
            {
                if (dataGridViewOpenDataBase_DVA.RowCount > 2)
                {
                    int count = -1;
                    for (int i = 0; i < dataGridViewOpenDataBase_DVA.RowCount - 1; i++)
                    {
                        for (int j = 0; j < dataGridViewOpenDataBase_DVA.ColumnCount - 1; j++)
                        {
                            if (dataGridViewOpenDataBase_DVA.Rows[i].Cells[j].Value != null)
                            {
                                if (dataGridViewOpenDataBase_DVA.Rows[i].Cells[j].Selected == true)
                                {
                                    count = j;
                                    break;
                                }
                            }
                            if (count > -1)
                            {
                                break;
                            }
                        }
                    }
                    if (count > -1)
                    {
                        int k = 0;
                        for (int i = 0; i < dataGridViewOpenDataBase_DVA.RowCount - 1; i++)
                        {
                            if (dataGridViewOpenDataBase_DVA.Rows[i].Cells[0].Selected == true)
                            {
                                k++;
                            }
                        }
                        if (k == 0)
                        {
                            int n = 0;
                            for (int i = 1; i < dataGridViewOpenDataBase_DVA.RowCount - 1; i++)
                            {
                                if (dataGridViewOpenDataBase_DVA.Rows[i].Cells[count].Value != null)
                                {
                                    double cellValue;
                                    if (double.TryParse(dataGridViewOpenDataBase_DVA.Rows[i].Cells[count].Value.ToString(), out cellValue))
                                    {
                                        n += 0;
                                    }
                                    else if (dataGridViewOpenDataBase_DVA.Rows[i].Cells[count].ValueType.ToString().Any(char.IsLetter))
                                    {
                                        n++;
                                    }
                                }
                            }
                            if (n == 0)
                            {
                                this.chartFunction_DVA.ChartAreas[0].AxisX.Title = "ID ЭВМ";
                                string name = Convert.ToString(dataGridViewOpenDataBase_DVA.Rows[0].Cells[count].Value);
                                this.chartFunction_DVA.ChartAreas[0].AxisY.Title = name;
                                int startValue = Convert.ToInt32(dataGridViewOpenDataBase_DVA.Rows[1].Cells[3].Value);
                                startValue -= 7;
                                for (int i = 1; i < dataGridViewOpenDataBase_DVA.RowCount - 1; i++)
                                {
                                    this.chartFunction_DVA.Series[0].Points.AddXY(startValue, Convert.ToDouble(dataGridViewOpenDataBase_DVA.Rows[i].Cells[count].Value));
                                    startValue++;
                                }
                            }
                            else MessageBox.Show("Выберите столбец с числами", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else MessageBox.Show("Нельзя выбрать первый столбец", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else MessageBox.Show("Не выбран столбец", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Нет данных для построения графика", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void buttonDeleteChart_DVA_Click(object sender, EventArgs e)
        {
            if (dataGridViewOpenDataBase_DVA.RowCount != 0)
            {
                chartFunction_DVA.Series[0].Points.Clear();
            }
            else
            {
                MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    matrix = ds.LoadDataBase(openFile);
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
        private void ToolStripMenuItemSaveFile_DVA_Click(object sender, EventArgs e)
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
