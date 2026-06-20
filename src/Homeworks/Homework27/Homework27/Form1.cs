using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SQLite;
using Dapper;

namespace Homework27
{
    public partial class Form1 : Form
    {
        private readonly string connectionString = "Data Source=MailingList.db;Version=3;";
        private SQLiteConnection activeConnection = null;
        private class BuyerCreationResult
        {
            public Buyer BuyerData { get; set; }
            public int SelectedProductId { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
            try
            {
                Database.CreateTables();
                LoadAllDataOnStart();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка ініціалізації бази даних: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAllDataOnStart()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = @"
                        SELECT 
                            b.Id AS [ID],
                            b.FullName AS [ПІБ Покупця],
                            b.BirthDate AS [Дата народження],
                            b.Gender AS [Стать],
                            b.Email AS [Email],
                            c.Name AS [Місто],
                            co.Name AS [Країна]
                        FROM Buyers b
                        LEFT JOIN Cities c ON b.CityId = c.Id
                        LEFT JOIN Countries co ON c.CountryId = co.Id";

                    dataGridView1.DataSource = connection.Query(sql).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка стартового завантаження даних: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (activeConnection != null && activeConnection.State == ConnectionState.Open)
                {
                    MessageBox.Show("З'єднання з базою даних вже активне!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                activeConnection = new SQLiteConnection(connectionString);
                activeConnection.Open();

                MessageBox.Show("Підключення до бази даних «Список розсилки» успішно встановлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAllDataOnStart();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show($"Помилка підключення до бази даних: {ex.Message}", "Помилка підключення", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Непередбачена помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (activeConnection == null || activeConnection.State == ConnectionState.Closed)
                {
                    MessageBox.Show("Немає активного підключення для закриття.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                activeConnection.Close();
                activeConnection.Dispose();
                activeConnection = null;

                dataGridView1.DataSource = null;
                MessageBox.Show("Відключено від бази даних «Список розсилки».", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при закритті підключення: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string ShowInputWindow(string title, string promptText)
        {
            using (Form form = new Form())
            {
                Label label = new Label { Text = promptText, Left = 20, Top = 20, Width = 350 };
                TextBox textBox = new TextBox { Left = 20, Top = 45, Width = 340 };
                Button btnOk = new Button { Text = "OK", Left = 190, Top = 80, Width = 80, DialogResult = DialogResult.OK };
                Button btnCancel = new Button { Text = "Скасувати", Left = 280, Top = 80, Width = 80, DialogResult = DialogResult.Cancel };

                form.Text = title;
                form.Size = new Size(400, 160);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterParent;
                form.MaximizeBox = false;

                form.Controls.AddRange(new Control[] { label, textBox, btnOk, btnCancel });
                form.AcceptButton = btnOk;
                form.CancelButton = btnCancel;

                return form.ShowDialog() == DialogResult.OK ? textBox.Text : null;
            }
        }
        private BuyerCreationResult ShowBuyerWindow(Buyer existingBuyer = null)
        {
            using (Form form = new Form())
            {
                form.Text = existingBuyer == null ? "Додавання покупця" : "Редагування покупця";
                form.Size = new Size(350, 340);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterParent;
                form.MaximizeBox = false;

                Label lblName = new Label { Text = "ПІБ:", Left = 20, Top = 20, Width = 80 };
                TextBox txtName = new TextBox { Left = 110, Top = 20, Width = 180, Text = existingBuyer?.FullName ?? "" };

                Label lblEmail = new Label { Text = "Email:", Left = 20, Top = 55, Width = 80 };
                TextBox txtEmail = new TextBox { Left = 110, Top = 55, Width = 180, Text = existingBuyer?.Email ?? "" };

                Label lblGender = new Label { Text = "Стать:", Left = 20, Top = 90, Width = 80 };
                ComboBox cbGender = new ComboBox { Left = 110, Top = 90, Width = 180, DropDownStyle = ComboBoxStyle.DropDownList };
                cbGender.Items.AddRange(new string[] { "Чоловіча", "Жіноча" });
                cbGender.SelectedItem = existingBuyer?.Gender ?? "Чоловіча";

                Label lblCity = new Label { Text = "Місто:", Left = 20, Top = 125, Width = 80 };
                ComboBox cbCity = new ComboBox { Left = 110, Top = 125, Width = 180, DropDownStyle = ComboBoxStyle.DropDownList };

                Label lblProduct = new Label { Text = "Цікавий Товар:", Left = 20, Top = 160, Width = 85 };
                ComboBox cbProduct = new ComboBox { Left = 110, Top = 160, Width = 180, DropDownStyle = ComboBoxStyle.DropDownList };

                try
                {
                    using (var connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();

                        cbCity.DataSource = connection.Query("SELECT Id, Name FROM Cities").ToList();
                        cbCity.DisplayMember = "Name";
                        cbCity.ValueMember = "Id";

                        cbProduct.DataSource = connection.Query("SELECT Id, Name FROM PromoProducts").ToList();
                        cbProduct.DisplayMember = "Name";
                        cbProduct.ValueMember = "Id";
                    }
                }
                catch (Exception ex) { MessageBox.Show($"Помилка завантаження даних для списків: {ex.Message}"); }

                if (existingBuyer != null && cbCity.Items.Count > 0)
                {
                    cbCity.SelectedValue = existingBuyer.CityId;
                    lblProduct.Visible = false;
                    cbProduct.Visible = false;
                }

                Button btnOk = new Button { Text = "Зберегти", Left = 110, Top = 230, Width = 80, DialogResult = DialogResult.OK };
                Button btnCancel = new Button { Text = "Скасувати", Left = 200, Top = 230, Width = 80, DialogResult = DialogResult.Cancel };

                form.Controls.AddRange(new Control[] { lblName, txtName, lblEmail, txtEmail, lblGender, cbGender, lblCity, cbCity, lblProduct, cbProduct, btnOk, btnCancel });
                form.AcceptButton = btnOk;
                form.CancelButton = btnCancel;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    int selectedCityId = cbCity.SelectedValue != null ? Convert.ToInt32(cbCity.SelectedValue) : 1;
                    int selectedProductId = cbProduct.SelectedValue != null ? Convert.ToInt32(cbProduct.SelectedValue) : 1;

                    return new BuyerCreationResult
                    {
                        BuyerData = new Buyer
                        {
                            Id = existingBuyer?.Id ?? 0,
                            FullName = txtName.Text,
                            Email = txtEmail.Text,
                            Gender = cbGender.SelectedItem.ToString(),
                            BirthDate = existingBuyer?.BirthDate ?? DateTime.Now.AddYears(-20),
                            CityId = selectedCityId
                        },
                        SelectedProductId = selectedProductId
                    };
                }
                return null;
            }
        }

        private PromoProduct ShowPromoProductWindow()
        {
            using (Form form = new Form())
            {
                form.Text = "Додавання акційного товару";
                form.Size = new Size(350, 260);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterParent;
                form.MaximizeBox = false;

                Label lblName = new Label { Text = "Назва:", Left = 20, Top = 20, Width = 80 };
                TextBox txtName = new TextBox { Left = 110, Top = 20, Width = 180 };

                Label lblCat = new Label { Text = "Розділ:", Left = 20, Top = 55, Width = 80 };
                ComboBox cbCat = new ComboBox { Left = 110, Top = 55, Width = 180, DropDownStyle = ComboBoxStyle.DropDownList };

                Label lblCount = new Label { Text = "Країна:", Left = 20, Top = 90, Width = 80 };
                ComboBox cbCount = new ComboBox { Left = 110, Top = 90, Width = 180, DropDownStyle = ComboBoxStyle.DropDownList };

                try
                {
                    using (var connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();
                        cbCat.DataSource = connection.Query("SELECT Id, Name FROM Categories").ToList();
                        cbCat.DisplayMember = "Name"; cbCat.ValueMember = "Id";

                        cbCount.DataSource = connection.Query("SELECT Id, Name FROM Countries").ToList();
                        cbCount.DisplayMember = "Name"; cbCount.ValueMember = "Id";
                    }
                }
                catch (Exception ex) { MessageBox.Show($"Помилка завантаження списків товарів: {ex.Message}"); }

                Button btnOk = new Button { Text = "OK", Left = 110, Top = 150, Width = 80, DialogResult = DialogResult.OK };
                Button btnCancel = new Button { Text = "Скасувати", Left = 200, Top = 150, Width = 80, DialogResult = DialogResult.Cancel };

                form.Controls.AddRange(new Control[] { lblName, txtName, lblCat, cbCat, lblCount, cbCount, btnOk, btnCancel });
                form.AcceptButton = btnOk;
                form.CancelButton = btnCancel;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    return new PromoProduct
                    {
                        Name = txtName.Text,
                        CategoryId = cbCat.SelectedValue != null ? Convert.ToInt32(cbCat.SelectedValue) : 1,
                        CountryId = cbCount.SelectedValue != null ? Convert.ToInt32(cbCount.SelectedValue) : 1,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(14)
                    };
                }
                return null;
            }
        }

        private Tuple<string, int> ShowCityInputWithCountrySelect()
        {
            using (Form form = new Form())
            {
                form.Text = "Нове місто";
                form.Size = new Size(350, 200);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterParent;
                form.MaximizeBox = false;

                Label lblName = new Label { Text = "Назва міста:", Left = 20, Top = 20, Width = 90 };
                TextBox txtName = new TextBox { Left = 120, Top = 20, Width = 180 };

                Label lblCountry = new Label { Text = "Країна міста:", Left = 20, Top = 55, Width = 90 };
                ComboBox cbCountry = new ComboBox { Left = 120, Top = 55, Width = 180, DropDownStyle = ComboBoxStyle.DropDownList };

                try
                {
                    using (var connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();
                        cbCountry.DataSource = connection.Query("SELECT Id, Name FROM Countries").ToList();
                        cbCountry.DisplayMember = "Name";
                        cbCountry.ValueMember = "Id";
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

                Button btnOk = new Button { Text = "OK", Left = 120, Top = 100, Width = 80, DialogResult = DialogResult.OK };

                form.Controls.AddRange(new Control[] { lblName, txtName, lblCountry, cbCountry, btnOk });
                form.AcceptButton = btnOk;

                if (form.ShowDialog() == DialogResult.OK && cbCountry.SelectedValue != null && !string.IsNullOrWhiteSpace(txtName.Text))
                {
                    return new Tuple<string, int>(txtName.Text, Convert.ToInt32(cbCountry.SelectedValue));
                }
                return null;
            }
        }

        private void OptionsMenu_DropDownItemClicked(object sender, EventArgs e)
        {
            string selectedOption = "";
            if (e is ToolStripItemClickedEventArgs clickedArgs) selectedOption = clickedArgs.ClickedItem.Text;
            else if (sender is ToolStripItem item) selectedOption = item.Text;
            else return;

            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    if (selectedOption.Equals("Відображення всіх покупців", StringComparison.OrdinalIgnoreCase))
                    {
                        string sql = "SELECT b.Id, b.FullName AS [ПІБ], b.Email, c.Name AS [Місто] FROM Buyers b LEFT JOIN Cities c ON b.CityId = c.Id";
                        dataGridView1.DataSource = connection.Query(sql).ToList();
                    }
                    else if (selectedOption.Equals("Відображення email усіх покупців", StringComparison.OrdinalIgnoreCase))
                    {
                        dataGridView1.DataSource = connection.Query("SELECT FullName AS [Покупець], Email FROM Buyers").ToList();
                    }
                    else if (selectedOption.Equals("Відображення списку розділів", StringComparison.OrdinalIgnoreCase))
                    {
                        dataGridView1.DataSource = connection.Query("SELECT Id, Name AS [Назва Розділу] FROM Categories").ToList();
                    }
                    else if (selectedOption.Equals("Відображення списку акційних товарів", StringComparison.OrdinalIgnoreCase))
                    {
                        dataGridView1.DataSource = connection.Query("SELECT Id, Name AS [Товар], StartDate, EndDate FROM PromoProducts").ToList();
                    }
                    else if (selectedOption.Equals("Відображення всех міст", StringComparison.OrdinalIgnoreCase) || selectedOption.Equals("Відображення всіх міст", StringComparison.OrdinalIgnoreCase))
                    {
                        dataGridView1.DataSource = connection.Query("SELECT Id, Name AS [Місто] FROM Cities").ToList();
                    }
                    else if (selectedOption.Equals("Відображення всіх країн", StringComparison.OrdinalIgnoreCase))
                    {
                        dataGridView1.DataSource = connection.Query("SELECT Id, Name AS [Країна] FROM Countries").ToList();
                    }
                    else if (selectedOption.IndexOf("покупців із конкретного міста", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        string city = ShowInputWindow("Пошук", "Введіть назву міста:");
                        if (!string.IsNullOrEmpty(city))
                        {
                            string sql = "SELECT b.Id, b.FullName AS [ПІБ], b.Email, c.Name AS [Місто] FROM Buyers b JOIN Cities c ON b.CityId = c.Id WHERE LOWER(c.Name) = LOWER(@Name)";
                            dataGridView1.DataSource = connection.Query(sql, new { Name = city }).ToList();
                        }
                    }
                    else if (selectedOption.IndexOf("покупців із конкретної країни", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        string country = ShowInputWindow("Пошук", "Введіть назву країни:");
                        if (!string.IsNullOrEmpty(country))
                        {
                            string sql = "SELECT b.Id, b.FullName AS [ПІБ], b.Email, co.Name AS [Країна] FROM Buyers b JOIN Cities c ON b.CityId = c.Id JOIN Countries co ON c.CountryId = co.Id WHERE LOWER(co.Name) = LOWER(@Name)";
                            dataGridView1.DataSource = connection.Query(sql, new { Name = country }).ToList();
                        }
                    }
                    else if (selectedOption.IndexOf("всіх акцій для конкретної країни", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        string country = ShowInputWindow("Пошук", "Введіть назву країни:");
                        if (!string.IsNullOrEmpty(country))
                        {
                            string sql = "SELECT p.Id, p.Name AS [Акційний Товар], c.Name AS [Країна], p.StartDate, p.EndDate FROM PromoProducts p JOIN Countries c ON p.CountryId = c.Id WHERE LOWER(c.Name) = LOWER(@Name)";
                            dataGridView1.DataSource = connection.Query(sql, new { Name = country }).ToList();
                        }
                    }
                    else if (selectedOption.IndexOf("міст конкретної країни", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        string country = ShowInputWindow("Пошук", "Введіть назву країни:");
                        if (!string.IsNullOrEmpty(country))
                        {
                            string sql = "SELECT c.Id, c.Name AS [Місто], co.Name AS [Країна] FROM Cities c JOIN Countries co ON c.CountryId = co.Id WHERE LOWER(co.Name) = LOWER(@Name)";
                            dataGridView1.DataSource = connection.Query(sql, new { Name = country }).ToList();
                        }
                    }
                    else if (selectedOption.IndexOf("розділів конкретного покупця", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        string buyer = ShowInputWindow("Пошук", "Введіть ПІБ покупця:");
                        if (!string.IsNullOrEmpty(buyer))
                        {
                            string sql = @"
                                SELECT 
                                    b.FullName AS [Покупець],
                                    cat.Name AS [Цікавий Розділ],
                                    p.Name AS [Доступний Акційний Товар],
                                    p.StartDate AS [Початок Акції],
                                    p.EndDate AS [Кінець Акції]
                                FROM Buyers b
                                JOIN BuyerCategories bc ON b.Id = bc.BuyerId
                                JOIN Categories cat ON bc.CategoryId = cat.Id
                                LEFT JOIN PromoProducts p ON cat.Id = p.CategoryId AND b.CityId IN (
                                    SELECT Id FROM Cities WHERE CountryId = p.CountryId
                                )
                                WHERE LOWER(b.FullName) LIKE LOWER(@Name)";

                            dataGridView1.DataSource = connection.Query(sql, new { Name = "%" + buyer + "%" }).ToList();
                        }
                    }
                    else if (selectedOption.IndexOf("акційних товарів конкретного розділу", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        string cat = ShowInputWindow("Пошук", "Введіть назву розділу:");
                        if (!string.IsNullOrEmpty(cat))
                        {
                            string sql = "SELECT p.Id, p.Name AS [Товар], c.Name AS [Розділ], p.StartDate, p.EndDate FROM PromoProducts p JOIN Categories c ON p.CategoryId = c.Id WHERE LOWER(c.Name) = LOWER(@Name)";
                            dataGridView1.DataSource = connection.Query(sql, new { Name = cat }).ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка фільтрації даних: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshTable(SQLiteConnection connection, string tableName)
        {
            try
            {
                if (tableName.Equals("Buyers", StringComparison.OrdinalIgnoreCase))
                {
                    string sql = @"
                        SELECT b.Id AS [ID], b.FullName AS [ПІБ], b.BirthDate AS [Дата народження], b.Gender AS [Стать], b.Email, c.Name AS [Місто], co.Name AS [Країна] 
                        FROM Buyers b 
                        LEFT JOIN Cities c ON b.CityId = c.Id 
                        LEFT JOIN Countries co ON c.CountryId = co.Id";
                    dataGridView1.DataSource = connection.Query(sql).ToList();
                }
                else
                {
                    dataGridView1.DataSource = connection.Query($"SELECT * FROM {tableName}").ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не вдалося оновити таблицю: {ex.Message}", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string type = ShowInputWindow("Що вставляємо?", "Введіть тип (Покупець, Країна, Місто, Розділ, Товар):");
            if (string.IsNullOrEmpty(type)) return;

            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    if (type.Equals("Покупець", StringComparison.OrdinalIgnoreCase))
                    {
                        var result = ShowBuyerWindow();
                        if (result != null)
                        {
                            connection.Execute("INSERT INTO Buyers (FullName, BirthDate, Gender, Email, CityId) VALUES (@FullName, @BirthDate, @Gender, @Email, @CityId)", result.BuyerData);
                            long newBuyerId = connection.LastInsertRowId;

                            int catId = connection.ExecuteScalar<int>("SELECT CategoryId FROM PromoProducts WHERE Id = @Id", new { Id = result.SelectedProductId });

                            connection.Execute("INSERT INTO BuyerCategories (BuyerId, CategoryId) VALUES (@BuyerId, @CategoryId)", new { BuyerId = newBuyerId, CategoryId = catId });

                            MessageBox.Show("Покупця успішно створено та прив'язано до товару!");
                            RefreshTable(connection, "Buyers");
                        }
                    }
                    else if (type.Equals("Країна", StringComparison.OrdinalIgnoreCase))
                    {
                        string name = ShowInputWindow("Нова країна", "Назва країни:");
                        if (!string.IsNullOrWhiteSpace(name))
                        {
                            connection.Execute("INSERT INTO Countries (Name) VALUES (@Name)", new { Name = name });
                            MessageBox.Show("Країну успішно додано!");
                            RefreshTable(connection, "Countries");
                        }
                    }
                    else if (type.Equals("Місто", StringComparison.OrdinalIgnoreCase))
                    {
                        var cityData = ShowCityInputWithCountrySelect();
                        if (cityData != null)
                        {
                            connection.Execute("INSERT INTO Cities (Name, CountryId) VALUES (@Name, @CountryId)", new { Name = cityData.Item1, CountryId = cityData.Item2 });
                            MessageBox.Show("Місто успішно додано!");
                            RefreshTable(connection, "Cities");
                        }
                    }
                    else if (type.Equals("Розділ", StringComparison.OrdinalIgnoreCase))
                    {
                        string name = ShowInputWindow("Новий розділ", "Назва розділу:");
                        if (!string.IsNullOrWhiteSpace(name))
                        {
                            connection.Execute("INSERT INTO Categories (Name) VALUES (@Name)", new { Name = name });
                            MessageBox.Show("Розділ успішно додано!");
                            RefreshTable(connection, "Categories");
                        }
                    }
                    else if (type.Equals("Товар", StringComparison.OrdinalIgnoreCase))
                    {
                        var p = ShowPromoProductWindow();
                        if (p != null)
                        {
                            connection.Execute("INSERT INTO PromoProducts (Name, CategoryId, CountryId, StartDate, EndDate) VALUES (@Name, @CategoryId, @CountryId, @StartDate, @EndDate)", p);
                            MessageBox.Show("Товар успішно додано!");
                            RefreshTable(connection, "PromoProducts");
                        }
                    }
                }
            }
            catch (SQLiteException ex) when (ex.Message.Contains("UNIQUE"))
            {
                MessageBox.Show("Помилка CONSTRAINT UNIQUE: такий запис або Email вже існує в базі даних!", "Помилка дублікату", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при вставці запису: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string idStr = ShowInputWindow("Оновлення", "Введіть ID покупця для редагування:");
            if (!int.TryParse(idStr, out int id)) return;

            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    var buyer = connection.QuerySingleOrDefault<Buyer>("SELECT * FROM Buyers WHERE Id = @Id", new { Id = id });
                    if (buyer == null)
                    {
                        MessageBox.Show("Покупця з таким ID не знайдено!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }

                    var result = ShowBuyerWindow(buyer);
                    if (result != null)
                    {
                        connection.Execute("UPDATE Buyers SET FullName=@FullName, Email=@Email, Gender=@Gender, CityId=@CityId WHERE Id=@Id", result.BuyerData);
                        MessageBox.Show("Дані успішно оновлено!");
                        RefreshTable(connection, "Buyers");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при оновленні запису: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string type = ShowInputWindow("Видалення", "Що видаляємо? (Покупець, Країна, Місто, Розділ, Товар):");
            string idStr = ShowInputWindow("Видалення", "Введіть ID запису:");
            if (!int.TryParse(idStr, out int id) || string.IsNullOrEmpty(type)) return;

            try
            {
                string table = "";
                if (type.Equals("Покупець", StringComparison.OrdinalIgnoreCase)) table = "Buyers";
                else if (type.Equals("Країна", StringComparison.OrdinalIgnoreCase)) table = "Countries";
                else if (type.Equals("Місто", StringComparison.OrdinalIgnoreCase)) table = "Cities";
                else if (type.Equals("Розділ", StringComparison.OrdinalIgnoreCase)) table = "Categories";
                else if (type.Equals("Товар", StringComparison.OrdinalIgnoreCase)) table = "PromoProducts";

                if (!string.IsNullOrEmpty(table))
                {
                    using (var connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();
                        connection.Execute($"DELETE FROM {table} WHERE Id = @Id", new { Id = id });
                        MessageBox.Show("Запис успішно видалено з системи!");
                        RefreshTable(connection, table);
                    }
                }
                else
                {
                    MessageBox.Show("Некоректний тип сутності для видалення!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SQLiteException ex) when (ex.Message.Contains("FOREIGN KEY"))
            {
                MessageBox.Show("Неможливо видалити цей запис, оскільки він зв'язаний з іншими таблицями (спрацював FOREIGN KEY)!", "Помилка цілісності", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка видалення: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void показатиВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadAllDataOnStart();
        }
    }
}