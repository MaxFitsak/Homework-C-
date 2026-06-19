using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace Homework24
{
    public partial class Form1 : Form
    {
        private CompanyContext _context;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _context = new CompanyContext();

            try
            {
                LoadPositions();
                LoadEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при завантаженні даних: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPositions()
        {
            if (_context == null) _context = new CompanyContext();

            var positions = _context.Positions.ToList();
            cmbPosition.DataSource = null;

            if (positions != null && positions.Count > 0)
            {
                cmbPosition.DataSource = positions;
                cmbPosition.DisplayMember = "Title";
                cmbPosition.ValueMember = "Id";
            }
        }

        private void LoadEmployees()
        {
            if (_context == null) _context = new CompanyContext();

            var employees = _context.Employees
                .Include(e => e.Position)
                .Select(e => new
                {
                    e.Id,
                    Имя = e.FirstName ?? "",
                    Фамилия = e.LastName ?? "",
                    Зарплата = e.Salary,
                    Должность = e.Position != null ? e.Position.Title : "",
                    Дата_Найма = e.HireDate
                })
                .ToList();

            dgvEmployees.DataSource = employees;
        }

        private void ClearInputs()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            numSalary.Value = 0;
            if (cmbPosition.Items.Count > 0) cmbPosition.SelectedIndex = 0;
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvEmployees.CurrentRow == null) return;

            var row = dgvEmployees.CurrentRow;
            txtFirstName.Text = row.Cells["Имя"].Value?.ToString() ?? "";
            txtLastName.Text = row.Cells["Фамилия"].Value?.ToString() ?? "";

            if (row.Cells["Зарплата"].Value != null)
                numSalary.Value = Convert.ToDecimal(row.Cells["Зарплата"].Value);
            else
                numSalary.Value = 0;

            string positionTitle = row.Cells["Должность"].Value?.ToString() ?? "";
            if (!string.IsNullOrEmpty(positionTitle))
            {
                cmbPosition.SelectedIndex = cmbPosition.FindStringExact(positionTitle);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Заповніть ім'я та прізвище", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbPosition.SelectedValue == null)
            {
                MessageBox.Show("Спочатку виберіть або додайте посаду", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var employee = new Employee
                {
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Salary = numSalary.Value,
                    PositionId = (int)cmbPosition.SelectedValue,
                    HireDate = DateTime.Now
                };

                _context.Employees.Add(employee);
                _context.SaveChanges();

                LoadEmployees();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null) return;

            try
            {
                int employeeId = (int)dgvEmployees.CurrentRow.Cells["Id"].Value;
                var employee = _context.Employees.Find(employeeId);

                if (employee != null)
                {
                    employee.FirstName = txtFirstName.Text.Trim();
                    employee.LastName = txtLastName.Text.Trim();
                    employee.Salary = numSalary.Value;
                    employee.PositionId = (int)cmbPosition.SelectedValue;

                    _context.SaveChanges();
                    LoadEmployees();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null) return;

            try
            {
                int employeeId = (int)dgvEmployees.CurrentRow.Cells["Id"].Value;
                var employee = _context.Employees.Find(employeeId);

                if (employee != null)
                {
                    var result = MessageBox.Show($"Видалити співробітника {employee.FirstName} {employee.LastName}?",
                        "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        _context.Employees.Remove(employee);
                        _context.SaveChanges();
                        LoadEmployees();
                        ClearInputs();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddPosition_Click(object sender, EventArgs e)
        {
            string newTitle = Microsoft.VisualBasic.Interaction.InputBox("Введіть назву нової посади:", "Додавання посади", "");
            if (string.IsNullOrWhiteSpace(newTitle)) return;

            newTitle = newTitle.Trim();

            try
            {
                if (_context == null) _context = new CompanyContext();

                bool exists = _context.Positions.Any(p => p.Title.ToLower() == newTitle.ToLower());
                if (exists)
                {
                    MessageBox.Show("Така посада вже існує", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var position = new Position { Title = newTitle };
                _context.Positions.Add(position);
                _context.SaveChanges();

                LoadPositions();
                cmbPosition.SelectedIndex = cmbPosition.FindStringExact(newTitle);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditPosition_Click(object sender, EventArgs e)
        {
            if (cmbPosition.SelectedValue == null) return;

            try
            {
                if (_context == null) _context = new CompanyContext();

                int positionId = (int)cmbPosition.SelectedValue;
                var position = _context.Positions.Find(positionId);

                if (position != null)
                {
                    string updatedTitle = Microsoft.VisualBasic.Interaction.InputBox("Редагування назви посади:", "Редагування посади", position.Title);
                    if (!string.IsNullOrWhiteSpace(updatedTitle) && updatedTitle.Trim() != position.Title)
                    {
                        updatedTitle = updatedTitle.Trim();

                        bool exists = _context.Positions.Any(p => p.Id != positionId && p.Title.ToLower() == updatedTitle.ToLower());
                        if (exists)
                        {
                            MessageBox.Show("Посада з такою назвою вже існує!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        position.Title = updatedTitle;
                        _context.SaveChanges();

                        LoadPositions();
                        LoadEmployees();
                        cmbPosition.SelectedIndex = cmbPosition.FindStringExact(updatedTitle);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при редагуванні посади: {ex.Message}", "Помилка бази даних", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchByNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string searchTerm = Microsoft.VisualBasic.Interaction.InputBox("Введіть ім'я або його частину для пошуку:", "Пошук за іменем", "");
            if (string.IsNullOrWhiteSpace(searchTerm)) return;

            try
            {
                var filtered = _context.Employees
                    .Include(emp => emp.Position)
                    .Where(emp => emp.FirstName.Contains(searchTerm.Trim()))
                    .Select(emp => new
                    {
                        emp.Id,
                        Имя = emp.FirstName,
                        Фамилия = emp.LastName,
                        Зарплата = emp.Salary,
                        Должность = emp.Position != null ? emp.Position.Title : "",
                        Дата_Найма = emp.HireDate
                    }).ToList();

                dgvEmployees.DataSource = filtered;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchByLastNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string searchTerm = Microsoft.VisualBasic.Interaction.InputBox("Введіть прізвище або його частину для пошуку:", "Пошук за прізвищем", "");
            if (string.IsNullOrWhiteSpace(searchTerm)) return;

            try
            {
                var filtered = _context.Employees
                    .Include(emp => emp.Position)
                    .Where(emp => emp.LastName.Contains(searchTerm.Trim()))
                    .Select(emp => new
                    {
                        emp.Id,
                        Имя = emp.FirstName,
                        Фамилия = emp.LastName,
                        Зарплата = emp.Salary,
                        Должность = emp.Position != null ? emp.Position.Title : "",
                        Дата_Найма = emp.HireDate
                    }).ToList();

                dgvEmployees.DataSource = filtered;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchByPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string searchTerm = Microsoft.VisualBasic.Interaction.InputBox("Введіть назву посади для пошуку:", "Пошук за посадою", "");
            if (string.IsNullOrWhiteSpace(searchTerm)) return;

            try
            {
                var filtered = _context.Employees
                    .Include(emp => emp.Position)
                    .Where(emp => emp.Position.Title.Contains(searchTerm.Trim()))
                    .Select(emp => new
                    {
                        emp.Id,
                        Имя = emp.FirstName,
                        Фамилия = emp.LastName,
                        Зарплата = emp.Salary,
                        Должность = emp.Position != null ? emp.Position.Title : "",
                        Дата_Найма = emp.HireDate
                    }).ToList();

                dgvEmployees.DataSource = filtered;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context?.Dispose();
        }
    }
}