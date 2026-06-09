using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Lesson30
{
    public partial class Form1 : Form
    {
        private Thread searchThread;
        private int foundCount = 0;

        public Form1()
        {
            InitializeComponent();

            Fill();

            SetupListView();
        }

        private void Fill()
        {
            string[] astrLogicalDrives = System.IO.Directory.GetLogicalDrives();

            comboBoxDisks.Items.Clear();
            foreach (string disk in astrLogicalDrives)
            {
                comboBoxDisks.Items.Add(disk);
            }
        }

        private void SetupListView()
        {
            listView1.View = View.Details;

            listView1.Columns.Add("Name", 150);
            listView1.Columns.Add("Folder", 250);
            listView1.Columns.Add("Size", 80);
            listView1.Columns.Add("Modification date", 130);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxDisks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (comboBoxDisks.SelectedItem == null)
            {
                MessageBox.Show("Виберіть диск");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxFile.Text))
            {
                MessageBox.Show("Введіть файл");
                return;
            }

            listView1.Items.Clear();
            foundCount = 0;

            string Path = comboBoxDisks.SelectedItem.ToString();
            string mask = textBoxFile.Text;
            bool searchCatalog = checkCatalogs.Checked;
            string wordToFind = textBoxMask.Text;

            DirectoryInfo di = new DirectoryInfo(Path);
            if (!di.Exists)
            {
                MessageBox.Show("Некоректний шлях!");
                return;
            }


            mask = mask.Replace(".", @"\.");
            mask = mask.Replace("?", ".");
            mask = mask.Replace("*", ".*");
            mask = "^" + mask + "$";
            Regex regMask = new Regex(mask, RegexOptions.IgnoreCase);


            searchThread = new Thread(() => SearchFiles(di, regMask, searchCatalog, wordToFind));
            searchThread.IsBackground = true;
            searchThread.Start();
        }

        private void SearchFiles(DirectoryInfo Path, Regex Mask, bool Catalog, string wordToFind)
        {
            StreamReader sr = null;
            // Список знайдених збігів
            MatchCollection mc = null;

            FileInfo[] fi = null;
            try
            {
                fi = Path.GetFiles();
            }
            catch
            {
                return;
            }

            // Перебираємо список файлів
            foreach (FileInfo f in fi)
            {
                // Якщо файл відповідає масці
                if (Mask.IsMatch(f.Name))
                {
                    // Збільшуємо лічильник
                    ++foundCount;
                    if (Mask != null)
                    {
                        try
                        {
                            // Відкриваємо файл
                            sr = new StreamReader(Path.FullName + @"\" + f.Name,
                                Encoding.Default);
                            // Зчитуємо повністю
                            string Content = sr.ReadToEnd();
                            // Закриваємо файл
                            sr.Close();
                            // Шукаємо заданий текст
                            if (!string.IsNullOrWhiteSpace(wordToFind))
                            {
                                mc = Mask.Matches(wordToFind);
                                // Перебираємо список входжень
                                foreach (Match m in mc)
                                {
                                    Console.WriteLine("Текст знайдено в позиції {0}.", m.Index);
                                }
                            }

                            ListViewItem item = new ListViewItem(f.Name);
                            item.SubItems.Add(f.DirectoryName);
                            item.SubItems.Add(f.Length.ToString());
                            item.SubItems.Add(f.LastWriteTime.ToString("dd.MM.yyyy H:mm:ss"));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
        }
        private void textBoxFile_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
