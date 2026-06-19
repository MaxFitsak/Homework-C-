namespace Homework26
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            SQLitePCL.Batteries.Init();

            InitializeComponent();

            using (var db = new GameDbContext())
            {
                db.Database.EnsureCreated();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new GameDbContext())
                {
                    var gamesList = db.Games.ToArray();

                    dgvGames.DataSource = gamesList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSeed_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new GameDbContext())
                {
                    if (!db.Games.Any())
                    {
                        db.Games.AddRange(
                            new Game { Title = "The Witcher 3", Studio = "CD Projekt RED", Genre = "RPG", ReleaseDate = new DateTime(2015, 5, 19), GameMode = "Singleplayer", CopiesSold = 50000000 },
                            new Game { Title = "S.T.A.L.K.E.R. 2", Studio = "GSC Game World", Genre = "FPS/Survival", ReleaseDate = new DateTime(2024, 11, 20), GameMode = "Singleplayer", CopiesSold = 1000000 },
                            new Game { Title = "Minecraft", Studio = "Mojang Studios", Genre = "Sandbox", ReleaseDate = new DateTime(2011, 11, 18), GameMode = "Multiplayer", CopiesSold = 300000000 }
                        );

                        db.SaveChanges();
                        MessageBox.Show("Тестовані ігри добавлені в базу", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnLoad_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("База данних вже має данні", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

