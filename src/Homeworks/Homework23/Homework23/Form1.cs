using DataBaseContext;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moedls;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace Homework23
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            LoadFullProductsInfo();
            LoadComboboxData();
        }

        private void LoadComboboxData()
        {
            try
            {
                using (warehouse context = new warehouse())
                {
                    context.Database.EnsureCreated();

                    var types = context.ProductTypes.Select(t => t.Name).Distinct().ToList();
                    cmbProductType.Items.Clear();
                    cmbProductType.Items.AddRange(types.ToArray());

                    var suppliers = context.Suplliers.Select(s => s.Name).Distinct().ToList();
                    cmbSupplier.Items.Clear();
                    cmbSupplier.Items.AddRange(suppliers.ToArray());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження списків: {ex.Message}");
            }
        }

        private void LoadFullProductsInfo()
        {
            try
            {
                using (warehouse context = new warehouse())
                {
                    context.Database.EnsureCreated();

                    var data = context.Products
                        .Select(p => new
                        {
                            ID = p.Id,
                            Name = p.Name,
                            Type = p.ProductType.Name,
                            Supplier = p.Supllier.Name,
                            Price = p.CostPrice,
                            Quantity = p.Quantity,
                            Date = p.DeliveryDate
                        })
                        .ToList();

                    dataGridView.DataSource = data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menuAllProducts_Click(object sender, EventArgs e)
        {
            LoadFullProductsInfo();
        }

        private void menuAllTypes_Click(object sender, EventArgs e)
        {
            using (warehouse context = new warehouse())
            {
                LoadFullProductsInfo();
            }
        }

        private void menuAllSuppliers_Click(object sender, EventArgs e)
        {
            using (warehouse context = new warehouse())
            {
                dataGridView.DataSource = context.Suplliers.Select(s => new { s.Id, Назва = s.Name }).ToList();
            }
        }

        private void menuMaxQty_Click(object sender, EventArgs e)
        {
            using (warehouse context = new warehouse())
            {
                var maxQty = context.Products.Max(p => (int?)p.Quantity) ?? 0;
                dataGridView.DataSource = context.Products
                    .Where(p => p.Quantity == maxQty)
                    .Select(p => new { p.Id, p.Name, p.Quantity, p.CostPrice })
                    .ToList();
            }
        }

        private void menuMinQty_Click(object sender, EventArgs e)
        {
            using (warehouse context = new warehouse())
            {
                var minQty = context.Products.Min(p => (int?)p.Quantity) ?? 0;
                dataGridView.DataSource = context.Products
                    .Where(p => p.Quantity == minQty)
                    .Select(p => new { p.Id, p.Name, p.Quantity, p.CostPrice })
                    .ToList();
            }
        }

        private void menuMinPrice_Click(object sender, EventArgs e)
        {
            using (warehouse context = new warehouse())
            {
                var minPrice = context.Products.Min(p => (double?)p.CostPrice) ?? 0;
                dataGridView.DataSource = context.Products
                    .Where(p => p.CostPrice == minPrice)
                    .Select(p => new { p.Id, p.Name, p.Quantity, p.CostPrice })
                    .ToList();
            }
        }

        private void menuMaxPrice_Click(object sender, EventArgs e)
        {
            using (warehouse context = new warehouse())
            {
                var maxPrice = context.Products.Max(p => (double?)p.CostPrice) ?? 0;
                dataGridView.DataSource = context.Products
                    .Where(p => p.CostPrice == maxPrice)
                    .Select(p => new { p.Id, p.Name, p.Quantity, p.CostPrice })
                    .ToList();
            }
        }

        private void menuOldestProduct_Click(object sender, EventArgs e)
        {
            using (warehouse context = new warehouse())
            {
                var oldestDate = context.Products.Min(p => p.DeliveryDate);
                dataGridView.DataSource = context.Products
                    .Where(p => p.DeliveryDate == oldestDate)
                    .Select(p => new { p.Id, p.Name, p.Quantity, p.CostPrice, Дата = p.DeliveryDate })
                    .ToList();
            }
        }

        private void menuAvgByType_Click(object sender, EventArgs e)
        {
            using (warehouse context = new warehouse())
            {
                dataGridView.DataSource = context.Products
                    .GroupBy(p => p.ProductType.Name)
                    .Select(g => new { ТипТовару = g.Key, СередняКількість = g.Average(p => p.Quantity) })
                    .ToList();
            }
        }

        private void menuSelectedType_Click(object sender, EventArgs e)
        {
            string selectedType = cmbProductType.Text.Trim();
            if (string.IsNullOrEmpty(selectedType))
            {
                MessageBox.Show("Спочатку виберіть або введіть тип товару у випадаючому списку!");
                return;
            }

            using (warehouse context = new warehouse())
            {
                dataGridView.DataSource = context.Products
                    .Where(p => p.ProductType.Name == selectedType)
                    .Select(p => new { p.Id, p.Name, Категорія = p.ProductType.Name, p.Quantity })
                    .ToList();
            }
        }

        private void menuSelectedSupplier_Click(object sender, EventArgs e)
        {
            string selectedSupplier = cmbSupplier.Text.Trim();
            if (string.IsNullOrEmpty(selectedSupplier))
            {
                MessageBox.Show("Спочатку виберіть або введіть постачальника у випадаючому списку!");
                return;
            }

            using (warehouse context = new warehouse())
            {
                dataGridView.DataSource = context.Products
                    .Where(p => p.Supllier.Name == selectedSupplier)
                    .Select(p => new { p.Id, p.Name, Постачальник = p.Supllier.Name, p.Quantity })
                    .ToList();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string quantityText = txtQuantity.Text.Trim();
            string priceText = txtPrice.Text.Trim().Replace(',', '.');
            string productType = cmbProductType.Text.Trim();
            string supplierName = cmbSupplier.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(productType) || string.IsNullOrEmpty(supplierName))
            {
                MessageBox.Show("Будь ласка, заповніть усі поля!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(quantityText, out int quantity) || !double.TryParse(priceText, NumberStyles.Any, CultureInfo.InvariantCulture, out double price))
            {
                MessageBox.Show("Перевірте правильність введення кількості та ціни!", "Помилка формату", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (warehouse context = new warehouse())
                {
                    var typeEntity = context.ProductTypes.FirstOrDefault(t => t.Name == productType) ?? new ProductType { Name = productType };
                    var supplierEntity = context.Suplliers.FirstOrDefault(s => s.Name == supplierName) ?? new Supllier { Name = supplierName };

                    Product newProduct = new Product
                    {
                        Name = name,
                        Quantity = quantity,
                        CostPrice = price,
                        DeliveryDate = dateTimePicker.Value.ToString("yyyy-MM-dd"),
                        ProductType = typeEntity,
                        Supllier = supplierEntity
                    };

                    context.Products.Add(newProduct);
                    context.SaveChanges();

                    MessageBox.Show("Товар успішно додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFullProductsInfo();
                    LoadComboboxData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            if (!int.TryParse(dataGridView.CurrentRow.Cells["ID"].Value.ToString(), out int selectedId)) return;

            try
            {
                using (warehouse context = new warehouse())
                {
                    var product = context.Products.Find(selectedId);
                    if (product != null)
                    {
                        product.Name = txtName.Text.Trim();

                        if (int.TryParse(txtQuantity.Text, out int quantity)) product.Quantity = quantity;

                        string priceText = txtPrice.Text.Trim().Replace(',', '.');
                        if (double.TryParse(priceText, NumberStyles.Any, CultureInfo.InvariantCulture, out double price)) product.CostPrice = price;

                        product.DeliveryDate = dateTimePicker.Value.ToString("yyyy-MM-dd");

                        string selectedType = cmbProductType.Text.Trim();
                        product.ProductType = context.ProductTypes.FirstOrDefault(t => t.Name == selectedType) ?? new ProductType { Name = selectedType };

                        string selectedSupplier = cmbSupplier.Text.Trim();
                        product.Supllier = context.Suplliers.FirstOrDefault(s => s.Name == selectedSupplier) ?? new Supllier { Name = selectedSupplier };

                        context.SaveChanges();
                        MessageBox.Show("Дані оновлено!");
                        LoadFullProductsInfo();
                        LoadComboboxData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            if (!int.TryParse(dataGridView.CurrentRow.Cells["ID"].Value.ToString(), out int selectedId)) return;

            if (MessageBox.Show("Ви впевнені, що хочете видалити цей товар?", "Підтвердження", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (warehouse context = new warehouse())
                    {
                        var product = context.Products.Find(selectedId);
                        if (product != null)
                        {
                            context.Products.Remove(product);
                            context.SaveChanges();
                            MessageBox.Show("Товар видалено.");
                            LoadFullProductsInfo();
                            LoadComboboxData();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.CurrentRow != null)
            {
                txtName.Text = dataGridView.CurrentRow.Cells["Name"].Value?.ToString();
                txtQuantity.Text = dataGridView.CurrentRow.Cells["Quantity"].Value?.ToString();
                txtPrice.Text = dataGridView.CurrentRow.Cells["Price"].Value?.ToString();
                cmbProductType.Text = dataGridView.CurrentRow.Cells["Type"].Value?.ToString();
                cmbSupplier.Text = dataGridView.CurrentRow.Cells["Supplier"].Value?.ToString();

                if (dataGridView.CurrentRow.Cells["Date"].Value != null &&
                    DateTime.TryParse(dataGridView.CurrentRow.Cells["Date"].Value.ToString(), out DateTime date))
                {
                    dateTimePicker.Value = date;
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}