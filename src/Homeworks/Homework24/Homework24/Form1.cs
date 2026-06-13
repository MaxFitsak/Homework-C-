namespace Homework24
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            try
            {
                InitializeComponent();

                RefreshData();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshData()
        {
            using (var db = new CompanyContext())
            {
                dataGridView1.DataSource = db.Employees.ToList();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var db = new CompanyContext())
            {
                var emp = new Employee
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Position = txtPosition.Text,
                    Salary = numericUpDown1.Value
                };
                db.Employees.Add(emp);
                db.SaveChanges();
            }
            RefreshData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is Employee selectedEmp)
            {
                using (var db = new CompanyContext())
                {
                    var emp = db.Employees.Find(selectedEmp.Id);
                    if (emp != null)
                    {
                        emp.FirstName = txtFirstName.Text;
                        emp.LastName = txtLastName.Text;
                        emp.Position = txtPosition.Text;
                        emp.Salary = numericUpDown1.Value;

                        db.SaveChanges();
                    }
                }
                RefreshData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is Employee selectedEmp)
            {
                using (var db = new CompanyContext())
                {
                    var emp = db.Employees.Find(selectedEmp.Id);
                    if (emp != null)
                    {
                        db.Employees.Remove(emp);
                        db.SaveChanges();
                    }
                }
                RefreshData();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim().ToLower();

            using (var db = new CompanyContext())
            {
                var result = db.Employees
                    .Where(e => e.FirstName.ToLower().Contains(query) ||
                                e.LastName.ToLower().Contains(query) ||
                                e.Position.ToLower().Contains(query))
                    .ToList();

                dataGridView1.DataSource = result;
            }
        }
    }
}

