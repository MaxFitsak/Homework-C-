namespace F1opl
{
    class Client
    {
        static void Main()
        {
            var test = new City();
            test.PrintFullClass();
            test.AddArea();

            var testik = new City();
            testik.PrintFullClass();
            testik.AddArea();

            testik.Name = "Kiev";

            var testWork = new Employeer();
            testWork.PrintFullClass();
            testWork.Edit();
            testWork.Name = "Sergiy Akvos";
        }
    }
}
