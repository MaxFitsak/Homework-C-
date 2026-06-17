using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Lesson25.Models;  
using Lesson25.Dialogs; 

namespace Lesson25
{
    public partial class Form1 : Form
    {
        private LibraryContext _db;

        public Form1()
        {
            InitializeComponent();
            _db = new LibraryContext();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadAuthors();
            RefreshBooks();

            comboBoxAuthors.SelectedIndexChanged += (s, ev) => { if (checkBoxFilter.Checked) RefreshBooks(); };
            checkBoxFilter.CheckedChanged += (s, ev) => RefreshBooks();
        }

        private void LoadAuthors()
        {
            var currentSelection = comboBoxAuthors.SelectedValue;
            var authors = _db.Authors.ToList();

            comboBoxAuthors.DataSource = null;
            comboBoxAuthors.DataSource = authors;
            comboBoxAuthors.DisplayMember = "Name";
            comboBoxAuthors.ValueMember = "Id";

            if (currentSelection != null && authors.Any(a => a.Id == Convert.ToInt64(currentSelection)))
            {
                comboBoxAuthors.SelectedValue = currentSelection;
            }
        }

        private void RefreshBooks()
        {
            listBoxBooks.DataSource = null;
            var booksQuery = _db.Books.AsQueryable();

            if (checkBoxFilter.Checked && comboBoxAuthors.SelectedItem is Author selectedAuthor)
            {
                booksQuery = booksQuery.Where(b => b.AuthorId == selectedAuthor.Id);
            }

            var books = booksQuery.ToList();
            listBoxBooks.DataSource = books;
            listBoxBooks.DisplayMember = "Title";
            listBoxBooks.ValueMember = "Id";
        }

        private void menuAddAuthor_Click(object sender, EventArgs e)
        {
            string name = InputDialog.Show("Додавання автора", "Введіть ім'я автора:");
            if (!string.IsNullOrWhiteSpace(name))
            {
                try
                {
                    _db.Authors.Add(new Author { Name = name.Trim() });
                    _db.SaveChanges();
                    LoadAuthors();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при додаванні автора: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void menuEditAuthor_Click(object sender, EventArgs e)
        {
            if (comboBoxAuthors.SelectedItem is Author selectedAuthor)
            {
                string newName = InputDialog.Show("Редагування автора", "Введіть ім'я автора:", selectedAuthor.Name);
                if (!string.IsNullOrWhiteSpace(newName))
                {
                    try
                    {
                        selectedAuthor.Name = newName.Trim();
                        _db.SaveChanges();
                        LoadAuthors();
                        RefreshBooks();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка при редагуванні автора: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void menuDeleteAuthor_Click(object sender, EventArgs e)
        {
            if (comboBoxAuthors.SelectedItem is Author selectedAuthor)
            {
                var result = MessageBox.Show("Ви дійсно бажаєте видалити автора?", "Автори та книги", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _db.Authors.Remove(selectedAuthor);
                        _db.SaveChanges();
                        LoadAuthors();
                        RefreshBooks();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show($"Не вдалося видалити автора: {ex.Message}",
                                        "Помилка видалення", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        _db.Dispose();
                        _db = new LibraryContext();
                        LoadAuthors();
                        RefreshBooks();
                    }
                }
            }
        }

        private void menuAddBook_Click(object sender, EventArgs e)
        {
            if (comboBoxAuthors.SelectedItem is Author selectedAuthor)
            {
                string title = InputDialog.Show("Додавання книги", "Введіть назву книги:");
                if (!string.IsNullOrWhiteSpace(title))
                {
                    _db.Books.Add(new Book { Title = title.Trim(), AuthorId = selectedAuthor.Id });
                    _db.SaveChanges();
                    RefreshBooks();
                }
            }
        }

        private void menuEditBook_Click(object sender, EventArgs e)
        {
            if (listBoxBooks.SelectedItem is Book selectedBook)
            {
                string newTitle = InputDialog.Show("Редагування книги", "Введіть назву книги:", selectedBook.Title);
                if (!string.IsNullOrWhiteSpace(newTitle))
                {
                    selectedBook.Title = newTitle.Trim();
                    _db.SaveChanges();
                    RefreshBooks();
                }
            }
        }

        private void menuDeleteBook_Click(object sender, EventArgs e)
        {
            if (listBoxBooks.SelectedItem is Book selectedBook)
            {
                var result = MessageBox.Show("Ви дійсно бажаєте видалити книгу?", "Автори та книги", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _db.Books.Remove(selectedBook);
                    _db.SaveChanges();
                    RefreshBooks();
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            _db?.Dispose();
        }
    }
}