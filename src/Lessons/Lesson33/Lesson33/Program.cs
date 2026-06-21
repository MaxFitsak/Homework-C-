namespace Lesson33
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Semaphore sem = new Semaphore(3, 3, "{EDECF0CB-01CC-416E-8120-5890AAAB8F4E}");

            bool acquired = sem.WaitOne(TimeSpan.Zero);

            if(!acquired)
            {
                MessageBox.Show("Запущено вже 3 програми");
                return;
            }

            try
            {
                Application.Run(new Form1());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sem.Release();
                sem.Close();
            }
        }
    }
}