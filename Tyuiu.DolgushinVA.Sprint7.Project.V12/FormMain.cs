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
        static int clear = 0;
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
                    dataGridViewOpenDataBase_DVA.ColumnCount = columns + 5;

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
                int count = -1;
                for (int i = 0; i < dataGridViewOpenDataBase_DVA.RowCount - 1; i++)
                {
                    for (int j = 0; j < dataGridViewOpenDataBase_DVA.ColumnCount - 1; j++)
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
                if (count > -1)
                {
                    if (dataGridViewOpenDataBase_DVA.Rows[0].Cells[count].Selected == true)
                    {
                        MessageBox.Show("Первую строку нельзя удалить", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var result = MessageBox.Show($"{"Удалить данную строку?\rЕе невозможно будет восстановить"}", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            int k = -1;
                            int delete = 0;
                            for (int i = 1; i < dataGridViewOpenDataBase_DVA.RowCount - 1; i++)
                            {
                                if (dataGridViewOpenDataBase_DVA.Rows[i].Cells[count].Selected == true)
                                {
                                    k = i;
                                    break;
                                }
                                if (k > -1)
                                {
                                    break;
                                }
                            }
                            for (int i = 1; i < dataGridViewOpenDataBase_DVA.RowCount - 1; i++)
                            {
                                if (dataGridViewOpenDataBase_DVA.Rows[i].Cells[count].Selected == true)
                                {
                                    delete++;
                                }
                            }
                            for (int r = 0; r < delete; r++)
                            {
                                dataGridViewOpenDataBase_DVA.Rows.Remove(dataGridViewOpenDataBase_DVA.Rows[k]);
                            }
                            for (int i = 0; i < dataGridViewOpenDataBase_DVA.RowCount - 1; i++)
                            {
                                for (int j = 0; j < dataGridViewOpenDataBase_DVA.ColumnCount - 1; j++)
                                {
                                    dataGridViewOpenDataBase_DVA.Rows[i].Cells[j].Selected = false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите строку, которую ходите удалить", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (e.KeyCode == Keys.Enter)
            {
                for (int i = 0; i < matrixSearch.GetUpperBound(0); i++)
                {
                    for (int j = 0; j < matrixSearch.GetUpperBound(1); j++)
                    {
                        if (matrixSearch[i, j] != null)
                        {
                            string element = matrixSearch[i, j].ToLower();
                            if (element.Contains(textBoxSearch_DVA.Text.ToLower())) dataGridViewOpenDataBase_DVA.Rows[i].Cells[j].Selected = true;
                        }
                    }
                }
            }
        }
        private void comboBoxSort_DVA_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridViewOpenDataBase_DVA.RowCount != 0)
            {
                matrixSort = new string[dataGridViewOpenDataBase_DVA.RowCount, dataGridViewOpenDataBase_DVA.ColumnCount];
                for (int i = 0; i <= dataGridViewOpenDataBase_DVA.RowCount; i++)
                {
                    for (int j = 0; j <= dataGridViewOpenDataBase_DVA.ColumnCount; j++)
                    {
                        matrixSort[i, j] = Convert.ToString(dataGridViewOpenDataBase_DVA.Rows[i].Cells[j].Value);
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
                for (int i = 0; i < dataGridViewOpenDataBase_DVA.RowCount - 1; i++)
                {
                    for (int j = 0; j < dataGridViewOpenDataBase_DVA.ColumnCount - 1; j++)
                    {
                        if (dataGridViewOpenDataBase_DVA.Rows[i].Cells[j].Value != null)
                        {
                            if (dataGridViewOpenDataBase_DVA.Rows[i].Cells[j].Selected == true)
                            {
                                columnIndex = j;
                                break;
                            }
                        }
                    }
                    if (columnIndex > -1)
                    {
                        break;
                    }
                }
                for (int i = 1; i < dataGridViewOpenDataBase_DVA.RowCount - 1; i++)
                {
                    string element = dataGridViewOpenDataBase_DVA.Rows[i].Cells[columnIndex].Value.ToString();
                    if (element.Contains(","))
                    {
                        element.Replace(",", ".");
                        dataGridViewOpenDataBase_DVA.Rows[i].Cells[columnIndex].Value = Convert.ToDouble(dataGridViewOpenDataBase_DVA.Rows[i].Cells[columnIndex].Value.ToString());
                    }
                    else
                    {
                        int cellValue;
                        if (int.TryParse(dataGridViewOpenDataBase_DVA.Rows[i].Cells[columnIndex].Value.ToString(), out cellValue))
                        {
                            dataGridViewOpenDataBase_DVA.Rows[i].Cells[columnIndex].Value = Convert.ToDouble(dataGridViewOpenDataBase_DVA.Rows[i].Cells[columnIndex].Value.ToString());
                        }
                    }
                }
                if (dataGridViewOpenDataBase_DVA.RowCount != 0)
                {
                    DataGridViewRow row = dataGridViewOpenDataBase_DVA.Rows[0];
                    dataGridViewOpenDataBase_DVA.Rows.Remove(dataGridViewOpenDataBase_DVA.Rows[0]);
                    DataGridViewColumn column = dataGridViewOpenDataBase_DVA.Columns[columnIndex];
                    string selectedItem = comboBoxSort_DVA.SelectedItem.ToString();
                    if (selectedItem == "По возрастанию")
                    {
                        dataGridViewOpenDataBase_DVA.Sort(column, ListSortDirection.Ascending);
                    }
                    if (selectedItem == "По убыванию")
                    {
                        dataGridViewOpenDataBase_DVA.Sort(column, ListSortDirection.Descending);
                    }
                    dataGridViewOpenDataBase_DVA.Rows.Insert(0, row);
                    for (int i = 0; i < dataGridViewOpenDataBase_DVA.RowCount - 1; i++)
                    {
                        for (int j = 0; j < dataGridViewOpenDataBase_DVA.ColumnCount - 1; j++)
                        {
                            dataGridViewOpenDataBase_DVA.Rows[i].Cells[j].Selected = false;
                        }
                    }
                    textBoxQuantity_DVA.Text = "";
                    textBoxSum_DVA.Text = "";
                    textBoxMiddleValue_DVA.Text = "";
                    textBoxMinValue_DVA.Text = "";
                    textBoxMaxValue_DVA.Text = "";
                }
                else
                {
                    MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void textBoxFilter_DVA_KeyDown(object sender, KeyEventArgs e)
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
                clear++;
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
                for (int i = 0; i < dataGridViewOpenDataBase_DVA.RowCount - 1; i++)
                {
                    for (int j = 0; j < dataGridViewOpenDataBase_DVA.ColumnCount - 1; j++)
                    {
                        dataGridViewOpenDataBase_DVA.Rows[i].Cells[j].Selected = false;
                    }
                }
                if (count > -1)
                {
                    for (int i = 0; i < dataGridViewOpenDataBase_DVA.RowCount; i++)
                    {
                        if (dataGridViewOpenDataBase_DVA.Rows[i].Cells[count].Value != null)
                        {
                            string element = dataGridViewOpenDataBase_DVA.Rows[i].Cells[count].Value.ToString().ToLower();
                            if (element.StartsWith(textBoxFilter_DVA.Text.ToLower())) dataGridViewOpenDataBase_DVA.Rows[i].Cells[count].Selected = true;
                        }
                    }
                    for (int r = 1; r < dataGridViewOpenDataBase_DVA.RowCount - 1; r++)
                    {
                        if (dataGridViewOpenDataBase_DVA.Rows[r].Cells[count].Selected != true)
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
                    textBoxQuantity_DVA.Text = "";
                    textBoxSum_DVA.Text = "";
                    textBoxMiddleValue_DVA.Text = "";
                    textBoxMinValue_DVA.Text = "";
                    textBoxMaxValue_DVA.Text = "";
                }
                else
                {
                    MessageBox.Show("Не выбран столбец", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void buttonClearFilter_DVA_Click(object sender, EventArgs e)
        {
            if ((dataGridViewOpenDataBase_DVA.RowCount != 0) && (clear != 0))
            {
                dataGridViewOpenDataBase_DVA.Rows.Clear();
                dataGridViewOpenDataBase_DVA.Columns.Clear();
                dataGridViewOpenDataBase_DVA.RowCount = matrixFilter.GetUpperBound(0) + 1;
                dataGridViewOpenDataBase_DVA.ColumnCount = matrixFilter.GetUpperBound(1) + 1;
                textBoxMaxValue_DVA.Text = Convert.ToString(matrixFilter.GetUpperBound(0) + 1);
                textBoxMinValue_DVA.Text = Convert.ToString(matrixFilter.GetUpperBound(1) + 1);
                for (int i = 0; i < dataGridViewOpenDataBase_DVA.RowCount - 1; i++)
                {
                    for (int j = 0; j < dataGridViewOpenDataBase_DVA.ColumnCount - 1; j++)
                    {
                        dataGridViewOpenDataBase_DVA.Rows[i].Cells[j].Value = matrixFilter[i, j];
                    }
                }
                dataGridViewOpenDataBase_DVA.AutoResizeColumns();
            }
            else if ((dataGridViewOpenDataBase_DVA.RowCount != 0) && (clear == 0))
            {
                MessageBox.Show("Фильтрация ещё не была применена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBoxQuantity_DVA_KeyUp(object sender, KeyEventArgs e)
        {
            if (dataGridViewOpenDataBase_DVA.RowCount != 0)
            {
                if (e.KeyCode == Keys.Enter)
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
                            if (count > -1) break;
                        }
                    }
                    int quantity = 0;
                    for (int r = 0; r < dataGridViewOpenDataBase_DVA.RowCount - 1; r++)
                    {
                        if (dataGridViewOpenDataBase_DVA.Rows[r].Cells[count].Selected == true) quantity++;
                    }
                    textBoxQuantity_DVA.Text = Convert.ToString(quantity);
                }
            }
            else
            {
                MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBoxSum_DVA_KeyUp(object sender, KeyEventArgs e)
        {
            if (dataGridViewOpenDataBase_DVA.RowCount != 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int count = -1;
                    for (int i = 0; i < dataGridViewOpenDataBase_DVA.RowCount - 1; i++)
                    {
                        for (int j = 0; j < dataGridViewOpenDataBase_DVA.ColumnCount - 1; j++)
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
                    if (count > -1)
                    {
                        if (dataGridViewOpenDataBase_DVA.Rows[0].Cells[count].Selected != true)
                        {
                            double sum = 0;
                            for (int i = 1; i < dataGridViewOpenDataBase_DVA.RowCount - 1; i++)
                            {
                                if (dataGridViewOpenDataBase_DVA.Rows[i].Cells[count].Selected == true)
                                {
                                    string element = dataGridViewOpenDataBase_DVA.Rows[i].Cells[count].Value.ToString();
                                    if (element.Contains(","))
                                    {
                                        element.Replace(",", ".");
                                        sum += Convert.ToDouble(dataGridViewOpenDataBase_DVA.Rows[i].Cells[count].Value.ToString());
                                    }
                                    else
                                    {
                                        int cellValue;
                                        if (int.TryParse(dataGridViewOpenDataBase_DVA.Rows[i].Cells[count].Value.ToString(), out cellValue))
                                        {
                                            sum += Convert.ToDouble(dataGridViewOpenDataBase_DVA.Rows[i].Cells[count].Value.ToString());
                                        }
                                    }
                                }
                            }
                            if (sum != 0)
                            {
                                textBoxSum_DVA.Text = Convert.ToString(sum);
                            }
                            else
                            {
                                MessageBox.Show("Выберите диапозон ячеек с числами", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBoxSum_DVA.Text = "";
                                textBoxMiddleValue_DVA.Text = "";
                                textBoxMinValue_DVA.Text = "";
                                textBoxMaxValue_DVA.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите диапозон ячеек с числами", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBoxSum_DVA.Text = "";
                            textBoxMiddleValue_DVA.Text = "";
                            textBoxMinValue_DVA.Text = "";
                            textBoxMaxValue_DVA.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не выбран столбец", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBoxMinValue_DVA_KeyUp(object sender, KeyEventArgs e)
        {
            if (dataGridViewOpenDataBase_DVA.RowCount != 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int count = -1;
                    for (int i = 0; i < dataGridViewOpenDataBase_DVA.RowCount - 1; i++)
                    {
                        for (int j = 0; j < dataGridViewOpenDataBase_DVA.ColumnCount - 1; j++)
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
                    if (count > -1)
                    {
                        if (dataGridViewOpenDataBase_DVA.Rows[0].Cells[count].Selected != true)
                        {
                            double min = 9999999;
                            for (int i = 1; i < dataGridViewOpenDataBase_DVA.RowCount - 1; i++)
                            {
                                if (dataGridViewOpenDataBase_DVA.Rows[i].Cells[count].Selected == true)
                                {
                                    string element = dataGridViewOpenDataBase_DVA.Rows[i].Cells[count].Value.ToString();
                                    if (element.Contains(","))
                                    {
                                        element.Replace(",", ".");
                                        min = Math.Min(Convert.ToDouble(dataGridViewOpenDataBase_DVA.Rows[i].Cells[count].Value.ToString()), min);
                                    }
                                    else
                                    {
                                        int cellValue;
                                        if (int.TryParse(dataGridViewOpenDataBase_DVA.Rows[i].Cells[count].Value.ToString(), out cellValue))
                                        {
                                            min = Math.Min(Convert.ToDouble(dataGridViewOpenDataBase_DVA.Rows[i].Cells[count].Value.ToString()), min);
                                        }
                                    }
                                }
                            }
                            if (min != 9999999)
                            {
                                textBoxMinValue_DVA.Text = Convert.ToString(min);
                            }
                            else
                            {
                                MessageBox.Show("Выберите диапозон ячеек с числами", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBoxMinValue_DVA.Text = "";
                                textBoxSum_DVA.Text = "";
                                textBoxMiddleValue_DVA.Text = "";
                                textBoxMaxValue_DVA.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите диапозон ячеек с числами", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBoxMinValue_DVA.Text = "";
                            textBoxSum_DVA.Text = "";
                            textBoxMiddleValue_DVA.Text = "";
                            textBoxMaxValue_DVA.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не выбран столбец", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBoxMiddleValue_DVA_KeyUp(object sender, KeyEventArgs e)
        {
            if (dataGridViewOpenDataBase_DVA.RowCount != 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int count = -1;
                    for (int i = 0; i < dataGridViewOpenDataBase_DVA.RowCount - 1; i++)
                    {
                        for (int j = 0; j < dataGridViewOpenDataBase_DVA.ColumnCount - 1; j++)
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
                    if (count > -1)
                    {
                        if (dataGridViewOpenDataBase_DVA.Rows[0].Cells[count].Selected != true)
                        {
                            double midvalue = 0;
                            int k = 0;
                            for (int i = 1; i < dataGridViewOpenDataBase_DVA.RowCount - 1; i++)
                            {
                                if (dataGridViewOpenDataBase_DVA.Rows[i].Cells[count].Selected == true)
                                {
                                    string element = dataGridViewOpenDataBase_DVA.Rows[i].Cells[count].Value.ToString();
                                    if (element.Contains(","))
                                    {
                                        element.Replace(",", ".");
                                        midvalue += Convert.ToDouble(dataGridViewOpenDataBase_DVA.Rows[i].Cells[count].Value.ToString());
                                        k++;
                                    }
                                    else
                                    {
                                        int cellValue;
                                        if (int.TryParse(dataGridViewOpenDataBase_DVA.Rows[i].Cells[count].Value.ToString(), out cellValue))
                                        {
                                            midvalue += Convert.ToDouble(dataGridViewOpenDataBase_DVA.Rows[i].Cells[count].Value.ToString());
                                            k++;
                                        }
                                    }
                                }
                            }
                            if (midvalue != 0)
                            {
                                textBoxMiddleValue_DVA.Text = Convert.ToString(midvalue / k);
                            }
                            else
                            {
                                MessageBox.Show("Выберите диапозон ячеек с числами", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBoxMiddleValue_DVA.Text = "";
                                textBoxSum_DVA.Text = "";
                                textBoxMinValue_DVA.Text = "";
                                textBoxMaxValue_DVA.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите диапозон ячеек с числами", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBoxMiddleValue_DVA.Text = "";
                            textBoxSum_DVA.Text = "";
                            textBoxMinValue_DVA.Text = "";
                            textBoxMaxValue_DVA.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не выбран столбец", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBoxMaxValue_DVA_KeyUp(object sender, KeyEventArgs e)
        {
            if (dataGridViewOpenDataBase_DVA.RowCount != 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int count = -1;
                    for (int i = 0; i < dataGridViewOpenDataBase_DVA.RowCount - 1; i++)
                    {
                        for (int j = 0; j < dataGridViewOpenDataBase_DVA.ColumnCount - 1; j++)
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
                    if (count > -1)
                    {
                        if (dataGridViewOpenDataBase_DVA.Rows[0].Cells[count].Selected != true)
                        {
                            double max = -9999999;
                            for (int i = 1; i < dataGridViewOpenDataBase_DVA.RowCount - 1; i++)
                            {
                                if (dataGridViewOpenDataBase_DVA.Rows[i].Cells[count].Selected == true)
                                {
                                    string element = dataGridViewOpenDataBase_DVA.Rows[i].Cells[count].Value.ToString();
                                    if (element.Contains(","))
                                    {
                                        element.Replace(",", ".");
                                        max = Math.Max(Convert.ToDouble(dataGridViewOpenDataBase_DVA.Rows[i].Cells[count].Value.ToString()), max);
                                    }
                                    else
                                    {
                                        int cellValue;
                                        if (int.TryParse(dataGridViewOpenDataBase_DVA.Rows[i].Cells[count].Value.ToString(), out cellValue))
                                        {
                                            max = Math.Max(Convert.ToDouble(dataGridViewOpenDataBase_DVA.Rows[i].Cells[count].Value.ToString()), max);
                                        }
                                    }
                                }
                            }
                            if (max != -9999999)
                            {
                                textBoxMaxValue_DVA.Text = Convert.ToString(max);
                            }
                            else
                            {
                                MessageBox.Show("Выберите диапозон ячеек с числами", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBoxMaxValue_DVA.Text = "";
                                textBoxSum_DVA.Text = "";
                                textBoxMiddleValue_DVA.Text = "";
                                textBoxMinValue_DVA.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите диапозон ячеек с числами", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBoxMaxValue_DVA.Text = "";
                            textBoxSum_DVA.Text = "";
                            textBoxMiddleValue_DVA.Text = "";
                            textBoxMinValue_DVA.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не выбран столбец", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    dataGridViewOpenDataBase_DVA.ColumnCount = columns + 5;

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
        private void toolStripMenuItemAbout_DVA_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }
        private void ToolStripMenuItemCharts_DVA_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormCharts formCharts = new FormCharts();
            formCharts.Show();

        }
        private void ToolStripMenuItemGuide_DVA_Click(object sender, EventArgs e)
        {
            FormGuide formGuide = new FormGuide();
            formGuide.ShowDialog();
        }
    }
}
