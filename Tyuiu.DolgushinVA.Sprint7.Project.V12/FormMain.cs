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
        static string[,] matrixSearch;
        static string[,] matrixSort;
        static string[,] matrixFilter;
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
                if (result == DialogResult.Yes)
                {
                    del = 1;
                }
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
        private void textBoxSearch_DVA_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridViewOpenDataBase_DVA.RowCount != 0)
            {
                matrixSearch = new string[dataGridViewOpenDataBase_DVA.RowCount, dataGridViewOpenDataBase_DVA.ColumnCount];
                for (int i = 0; i < dataGridViewOpenDataBase_DVA.RowCount - 1; i++)
                {
                    for (int j = 0; j < dataGridViewOpenDataBase_DVA.ColumnCount - 1; j++)
                    {
                        matrixSearch[i, j] = Convert.ToString(dataGridViewOpenDataBase_DVA.Rows[i].Cells[j].Value);
                        dataGridViewOpenDataBase_DVA.Rows[i].Cells[j].Selected = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBoxSearch_DVA_KeyUp(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < dataGridViewOpenDataBase_DVA.RowCount - 1; i++)
            {
                for (int j = 0; j < dataGridViewOpenDataBase_DVA.ColumnCount - 1; j++)
                {
                    dataGridViewOpenDataBase_DVA.Rows[i].Cells[j].Selected = false;
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                for (int i = 0; i < dataGridViewOpenDataBase_DVA.RowCount - 1; i++)
                {
                    for (int j = 0; j < dataGridViewOpenDataBase_DVA.ColumnCount - 1; j++)
                    {
                        if (dataGridViewOpenDataBase_DVA.Rows[i].Cells[j].Value != null)
                        {
                            string element = dataGridViewOpenDataBase_DVA.Rows[i].Cells[j].Value.ToString().ToLower();
                            if (element.Contains(textBoxSearch_DVA.Text.ToLower()))
                            {
                                dataGridViewOpenDataBase_DVA.Rows[i].Cells[j].Selected = true;
                            }
                        }
                    }
                }
                int search = 0;
                for (int r = 0; r < dataGridViewOpenDataBase_DVA.RowCount - 1; r++)
                {
                    for (int c = 0; c < dataGridViewOpenDataBase_DVA.ColumnCount - 1; c++)
                    {
                        if (dataGridViewOpenDataBase_DVA.Rows[r].Cells[c].Selected == true)
                        {
                            search += 1;
                        }
                    }
                }
                if (search == 0)
                {
                    for (int r = 0; r < dataGridViewOpenDataBase_DVA.RowCount - 1; r++)
                    {
                        for (int c = 0; c < dataGridViewOpenDataBase_DVA.ColumnCount - 1; c++)
                        {
                            dataGridViewOpenDataBase_DVA.Rows[r].Visible = true;
                        }
                    }
                }
                else
                {
                    int clear = 0;
                    for (int r = 1; r < dataGridViewOpenDataBase_DVA.RowCount - 1; r++)
                    {
                        for (int c = 0; c < dataGridViewOpenDataBase_DVA.ColumnCount - 1; c++)
                        {
                            if (dataGridViewOpenDataBase_DVA.Rows[r].Cells[c].Selected == true)
                            {
                                clear += 1;
                            }
                        }
                        if (clear == 0)
                        {
                            dataGridViewOpenDataBase_DVA.Rows[r].Visible = false;
                        }
                        else
                        {
                            dataGridViewOpenDataBase_DVA.Rows[r].Visible = true;
                            clear = 0;
                        }
                    }
                }
            }
        }
        private void textBoxSort_DVA_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridViewOpenDataBase_DVA.RowCount != 0)
            {
                matrixSort = new string[dataGridViewOpenDataBase_DVA.RowCount, dataGridViewOpenDataBase_DVA.ColumnCount];
                for (int i = 0; i < dataGridViewOpenDataBase_DVA.RowCount; i++)
                {
                    for (int j = 0; j < dataGridViewOpenDataBase_DVA.ColumnCount; j++)
                    {
                        matrixSort[i, j] = Convert.ToString(dataGridViewOpenDataBase_DVA.Rows[i].Cells[j].Value);
                        dataGridViewOpenDataBase_DVA.Rows[i].Cells[j].Selected = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboBoxSort_DVA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSort_DVA.SelectedItem != null)
            {
                int columnIndex = -1;
                foreach (DataGridViewColumn column in dataGridViewOpenDataBase_DVA.Columns)
                {
                    if (column.Selected)
                    {
                        columnIndex = column.Index;
                        break;
                    }
                }
                if (columnIndex >= 0)
                {
                    bool canSort = true;
                    foreach (DataGridViewRow row in dataGridViewOpenDataBase_DVA.Rows)
                    {
                        int cellValue;
                        if (row.Cells[columnIndex].Value != null && int.TryParse(row.Cells[columnIndex].Value.ToString(), out cellValue))
                        {
                            row.Cells[columnIndex].Value = cellValue;
                        }
                        else
                        {
                            row.Cells[columnIndex].Value = 0;
                            canSort = false;
                        }
                    }
                    if (canSort)
                    {
                        DataGridViewColumn column = dataGridViewOpenDataBase_DVA.Columns[columnIndex];
                        string selectedItem = comboBoxSort_DVA.SelectedItem.ToString();

                        if (selectedItem == "По возрастанию")
                            dataGridViewOpenDataBase_DVA.Sort(column, ListSortDirection.Ascending);
                        else if (selectedItem == "По убыванию")
                            dataGridViewOpenDataBase_DVA.Sort(column, ListSortDirection.Descending);
                    }
                    //else MessageBox.Show("Невозможно выполнить сортировку");
                }
            }
        }
        private void textBoxFilter_DVA_KeyDoWn(object sender, KeyEventArgs e)
        {
            if (dataGridViewOpenDataBase_DVA.RowCount != 0)
            {
                matrixFilter = new string[dataGridViewOpenDataBase_DVA.RowCount, dataGridViewOpenDataBase_DVA.ColumnCount];
                for (int i = 0; i < dataGridViewOpenDataBase_DVA.RowCount - 1; i++)
                {
                    for (int j = 0; j < dataGridViewOpenDataBase_DVA.ColumnCount - 1; j++)
                    {
                        matrixFilter[i, j] = Convert.ToString(dataGridViewOpenDataBase_DVA.Rows[i].Cells[j].Value);
                    }
                }
            }
            else
            {
                MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBoxFilter_DVA_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int filter = 0;
                for (int i = 0; i < dataGridViewOpenDataBase_DVA.RowCount - 1; i++)
                {
                    for (int j = 0; j < dataGridViewOpenDataBase_DVA.ColumnCount - 1; j++)
                    {
                        if (dataGridViewOpenDataBase_DVA.Rows[i].Cells[j].Value != null)
                        {
                            if (dataGridViewOpenDataBase_DVA.Rows[i].Cells[j].Selected == true)
                            {
                                filter = j;
                                break;
                            }
                        }
                        if (filter > 0)
                        {
                            break;
                        }  
                    }
                }
                for (int i = 0; i < dataGridViewOpenDataBase_DVA.RowCount - 1; i++)
                {
                    for (int j = 0; j < dataGridViewOpenDataBase_DVA.ColumnCount - 1; j++)
                    {
                        dataGridViewOpenDataBase_DVA.Rows[i].Cells[j].Selected = false;
                    }
                }
                if (filter > 0)
                {
                    for (int i = 0; i < dataGridViewOpenDataBase_DVA.RowCount - 1; i++)
                    {
                        string elmnt = dataGridViewOpenDataBase_DVA.Rows[i].Cells[filter].Value.ToString().ToLower();
                        if (elmnt.StartsWith(dataGridViewOpenDataBase_DVA.Text.ToLower()))
                        {
                            dataGridViewOpenDataBase_DVA.Rows[i].Cells[filter].Selected = true;
                        }
                    }

                    for (int r = 1; r < dataGridViewOpenDataBase_DVA.RowCount - 1; r++)
                    {
                        if (dataGridViewOpenDataBase_DVA.Rows[r].Cells[filter].Selected == true)
                        {
                            dataGridViewOpenDataBase_DVA.Rows[r].Visible = true;
                        }
                        else
                        {
                            dataGridViewOpenDataBase_DVA.Rows[r].Visible = false;
                        }
                    }
                    for (int i = 0; i < dataGridViewOpenDataBase_DVA.RowCount - 1; i++)
                    {
                        for (int j = 0; j < dataGridViewOpenDataBase_DVA.ColumnCount - 1; j++)
                        {
                            dataGridViewOpenDataBase_DVA.Rows[i].Cells[j].Selected = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Не выбран столбец", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
