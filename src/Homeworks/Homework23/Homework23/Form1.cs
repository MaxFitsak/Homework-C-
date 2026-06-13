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
        private warehouse _context;

        public Form1()
        {
            InitializeComponent();


            LoadFullProductsInfo();


        }

        private void LoadFullProductsInfo()
        {
            try
            {
                using (warehouse context = new warehouse())
                {
                    context.Database.EnsureCreated();

                    var data = context.Products
                        .Include(p => p.ProductType)
                        .Include(p => p.Supllier)
                        .Select(p => new
                        {
                            ID = p.Id,
                            Name = p.Name,
                            Type = p.ProductType.Name,
                            Sipplaer = p.Supllier.Name,
                            Price = p.CostPrice
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

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1) return;

            string selectedQuery = listBox.SelectedItem.ToString();

            using (warehouse context = new warehouse())
            {
                context.Database.EnsureCreated();

                switch (selectedQuery)
                {
                    case "Вся інформація про товар":
                        dataGridView.DataSource = context.Products
                            .Select(p => new { p.Id, p.Name, Тип = p.ProductType.Name, Постачальник = p.Supllier.Name, p.Quantity, p.CostPrice, p.DeliveryDate })
                            .ToList();
                        break;

                    case "Всі типи товарів":
                        dataGridView.DataSource = context.ProductTypes.Select(t => new { t.Id, Назва = t.Name }).ToList();
                        break;

                    case "Всі типи постачальників":
                        dataGridView.DataSource = context.Suplliers.Select(s => new { s.Id, Назва = s.Name }).ToList();
                        break;

                    case "Товар з максимальною кількістю":
                        var maxQty = context.Products.Max(p => (int?)p.Quantity) ?? 0;
                        dataGridView.DataSource = context.Products
                            .Where(p => p.Quantity == maxQty)
                            .Select(p => new { p.Id, p.Name, p.Quantity, p.CostPrice })
                            .ToList();
                        break;

                    case "Товару з мінімальною кількістю":
                        var minQty = context.Products.Min(p => (int?)p.Quantity) ?? 0;
                        dataGridView.DataSource = context.Products
                            .Where(p => p.Quantity == minQty)
                            .Select(p => new { p.Id, p.Name, p.Quantity, p.CostPrice })
                            .ToList();
                        break;

                    case "Товар з мінімальною собівартістю":
                        var minPrice = context.Products.Min(p => (double?)p.CostPrice) ?? 0;
                        dataGridView.DataSource = context.Products
                            .Where(p => p.CostPrice == minPrice)
                            .Select(p => new { p.Id, p.Name, p.Quantity, p.CostPrice })
                            .ToList();
                        break;

                    case "Товар з максимальною собівартістю":
                        var maxPrice = context.Products.Max(p => (double?)p.CostPrice) ?? 0;
                        dataGridView.DataSource = context.Products
                            .Where(p => p.CostPrice == maxPrice)
                            .Select(p => new { p.Id, p.Name, p.Quantity, p.CostPrice })
                            .ToList();
                        break;

                    case "Найстаріщий товар на складі":
                        var oldestDate = context.Products.Min(p => p.DeliveryDate);
                        dataGridView.DataSource = context.Products
                            .Where(p => p.DeliveryDate == oldestDate)
                            .Select(p => new { p.Id, p.Name, p.Quantity, p.CostPrice, Дата = p.DeliveryDate })
                            .ToList();
                        break;

                    case "Средня кількість товарів за кожним типом товару":
                        dataGridView.DataSource = context.Products
                            .GroupBy(p => p.ProductType.Name)
                            .Select(g => new { ТипТовару = g.Key, СередняКількість = g.Average(p => p.Quantity) })
                            .ToList();
                        break;

                    case "Товар заданої категорії":
                        dataGridView.DataSource = context.Products
                            .Where(p => p.ProductType.Name == txtName.Text)
                            .Select(p => new { p.Id, p.Name, Категорія = p.ProductType.Name, p.Quantity })
                            .ToList();
                        break;

                    case "Товар заданого постачальника":
                        dataGridView.DataSource = context.Products
                            .Where(p => p.Supllier.Name == txtName.Text)
                            .Select(p => new {
                                p.Id,
                                p.Name,
                                Категорія = p.ProductType.Name,
                                p.Quantity
                            })
                            .ToList();
                        break;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;

            int selectedId = (int)dataGridView.CurrentRow.Cells["Id"].Value;

            using (warehouse context = new warehouse())
            {
                var product = context.Products.Find(selectedId);
                if (product != null)
                {
                    product.Name = txtName.Text;
                    product.Quantity = int.Parse(txtQuantity.Text);
                    product.CostPrice = double.Parse(txtPrice.Text);
                    product.DeliveryDate = dateTimePicker.Value.ToString("yyyy-MM-dd");

                    context.SaveChanges();
                    MessageBox.Show("Дані оновлено!");
                    listBox_SelectedIndexChanged(null, null);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;

            int selectedId = (int)dataGridView.CurrentRow.Cells["Id"].Value;

            var confirmResult = MessageBox.Show("Ви впевнені, що хочете видалити цей товар?", "Підтвердження", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                using (warehouse context = new warehouse())
                {
                    var product = context.Products.Find(selectedId);
                    if (product != null)
                    {
                        context.Products.Remove(product);
                        context.SaveChanges();

                        MessageBox.Show("Товар видалено.");
                        listBox_SelectedIndexChanged(null, null);
                    }
                }
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string quantityText = txtQuantity.Text.Trim();
            string priceText = txtPrice.Text.Trim().Replace(',', '.');

            if (!int.TryParse(quantityText, out int quantity))
            {
                MessageBox.Show("Помилка у полі Кількість!", "Помилка формату", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(priceText, NumberStyles.Any, CultureInfo.InvariantCulture, out double price))
            {
                MessageBox.Show("Помилка у полі Ціна!", "Помилка формату", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (warehouse context = new warehouse())
                {
                    context.Database.EnsureCreated();

                    if (!context.ProductTypes.Any()) context.ProductTypes.Add(new ProductType { Name = "Загальне" });
                    if (!context.Suplliers.Any()) context.Suplliers.Add(new Supllier { Name = "Основний постачальник" });
                    context.SaveChanges();

                    var defaultType = context.ProductTypes.First();
                    var defaultSupplier = context.Suplliers.First();

                    Product newProduct = new Product
                    {
                        Name = name,
                        Quantity = quantity,
                        CostPrice = price,
                        DeliveryDate = dateTimePicker.Value.ToString("yyyy-MM-dd"),
                        ProductType = defaultType,
                        Supllier = defaultSupplier
                    };

                    context.Products.Add(newProduct);
                    context.SaveChanges();

                    MessageBox.Show("Товар успішно додано в базу!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    listBox_SelectedIndexChanged(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                                
            }
        }
    }
}