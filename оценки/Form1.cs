using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace оценки
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            dataGridView1.CellValidating += DataGridView1_CellValidating;
            FillDataGridViewWithStudents();
            TransferAndSortData();
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Химия"].Index ||
                e.ColumnIndex == dataGridView1.Columns["Физика"].Index ||
                e.ColumnIndex == dataGridView1.Columns["Математика"].Index)
            {
                var rowIndex = e.RowIndex;

                CalculateAverage(rowIndex);
            }
        }

        private void TransferAndSortData()
        {
            dataGridView2.Rows.Clear();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    dataGridView2.Rows.Add(
                        row.Cells["Группа"].Value,
                        row.Cells["Студент"].Value,
                        row.Cells["Средний_бал"].Value
                    );
                }
            }

            SortDataGridViewByAverageScore(dataGridView2);
        }

        private void SortDataGridViewByAverageScore(DataGridView dgv)
        {
            dgv.Sort(dgv.Columns["Средний_бал"], ListSortDirection.Descending);
        }

        private void CalculateAverage(int rowIndex)
        {
            var currentRow = dataGridView1.Rows[rowIndex];

            double? химия = (double?)currentRow.Cells["Химия"].Value;
            double? физика = (double?)currentRow.Cells["Физика"].Value;
            double? математика = (double?)currentRow.Cells["Математика"].Value;

            int count = 0;
            double sum = 0;

            if (химия.HasValue && химия != 0)
            {
                sum += химия.Value;
                count++;
            }

            if (физика.HasValue && физика != 0)
            {
                sum += физика.Value;
                count++;
            }

            if (математика.HasValue && математика != 0)
            {
                sum += математика.Value;
                count++;
            }

            double? average = count > 0 ? (double?)sum / count : null;

            currentRow.Cells["Средний_бал"].Value = average;

            TransferAndSortData();
        }

        private void DataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Химия"].Index ||
                e.ColumnIndex == dataGridView1.Columns["Физика"].Index ||
                e.ColumnIndex == dataGridView1.Columns["Математика"].Index)
            {
                int value;
                if (int.TryParse(e.FormattedValue.ToString(), out value))
                {
                    if (value < 2 || value > 5)
                    {
                        MessageBox.Show("Допустимы значения от 2 до 5.");
                        e.Cancel = true;
                        dataGridView1.CurrentCell.Value = DBNull.Value;
                        dataGridView1.Rows[e.RowIndex].ErrorText = "";
                        dataGridView1.CancelEdit();
                    }
                }
                else
                {
                    e.Cancel = false;
                }
            }
        }

        private void FillDataGridViewWithStudents()
        {
            Student[] students = new Student[]
            {
                new Student { Группа = "Группа 1", Студент = "Иван Иванов", Химия = null, Физика = null, Математика = null, Средний_бал = null },
                new Student { Группа = "Группа 1", Студент = "Петр Петров", Химия = null, Физика = null, Математика = null, Средний_бал = null },
                new Student { Группа = "Группа 1", Студент = "Сергей Сергеев", Химия = null, Физика = null, Математика = null, Средний_бал = null },
                new Student { Группа = "Группа 1", Студент = "Алексей Алексеев", Химия = null, Физика = null, Математика = null, Средний_бал = null },
                new Student { Группа = "Группа 1", Студент = "Дмитрий Дмитриев", Химия = null, Физика = null, Математика = null, Средний_бал = null },
                new Student { Группа = "Группа 1", Студент = "Андрей Андреев", Химия = null, Физика = null, Математика = null, Средний_бал = null },
                new Student { Группа = "Группа 1", Студент = "Михаил Михайлов", Химия = null, Физика = null, Математика = null, Средний_бал = null },
                new Student { Группа = "Группа 1", Студент = "Николай Николаев", Химия = null, Физика = null, Математика = null, Средний_бал = null },

                new Student { Группа = "Группа 2", Студент = "Анна Васильева", Химия = null, Физика = null, Математика = null, Средний_бал = null },
                new Student { Группа = "Группа 2", Студент = "Марина Смирнова", Химия = null, Физика = null, Математика = null, Средний_бал = null },
                new Student { Группа = "Группа 2", Студент = "Елена Егорова", Химия = null, Физика = null, Математика = null, Средний_бал = null },
                new Student { Группа = "Группа 2", Студент = "Ольга Орлова", Химия = null, Физика = null, Математика = null, Средний_бал = null },
                new Student { Группа = "Группа 2", Студент = "Татьяна Тихонова", Химия = null, Физика = null, Математика = null, Средний_бал = null },
                new Student { Группа = "Группа 2", Студент = "Светлана Светлова", Химия = null, Физика = null, Математика = null, Средний_бал = null },
                new Student { Группа = "Группа 2", Студент = "Кристина Крылова", Химия = null, Физика = null, Математика = null, Средний_бал = null },
                new Student { Группа = "Группа 2", Студент = "Дарья Дмитриева", Химия = null, Физика = null, Математика = null, Средний_бал = null },

                new Student { Группа = "Группа 3", Студент = "Александр Александров", Химия = null, Физика = null, Математика = null, Средний_бал = null },
                new Student { Группа = "Группа 3", Студент = "Виктор Викторов", Химия = null, Физика = null, Математика = null, Средний_бал = null },
                new Student { Группа = "Группа 3", Студент = "Евгений Евгеньев", Химия = null, Физика = null, Математика = null, Средний_бал = null },
                new Student { Группа = "Группа 3", Студент = "Константин Константинов", Химия = null, Физика = null, Математика = null, Средний_бал = null },
                new Student { Группа = "Группа 3", Студент = "Максим Максимов", Химия = null, Физика = null, Математика = null, Средний_бал = null },
                new Student { Группа = "Группа 3", Студент = "Павел Павлов", Химия = null, Физика = null, Математика = null, Средний_бал = null },
                new Student { Группа = "Группа 3", Студент = "Роман Романов", Химия = null, Физика = null, Математика = null, Средний_бал = null },
                new Student { Группа = "Группа 3", Студент = "Ярослав Ярославов", Химия = null, Физика = null, Математика = null, Средний_бал = null },
            };

            dataGridView1.DataSource = students;
            dataGridView1.AutoGenerateColumns = true;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Name == "Группа" || column.Name == "Студент" || column.Name == "Средний_бал")
                {
                    column.ReadOnly = true;
                }
            }

            dataGridView1.Refresh();

            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                if (column.Name == "Группа" || column.Name == "Студент" || column.Name == "Средний_бал")
                {
                    column.ReadOnly = true;
                }
                else
                {
                    column.Visible = false;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    public class Student
    {
        public string Группа { get; set; }
        public string Студент { get; set; }
        public double? Химия { get; set; }
        public double? Физика { get; set; }
        public double? Математика { get; set; }
        public double? Средний_бал { get; set; }
    }
}
