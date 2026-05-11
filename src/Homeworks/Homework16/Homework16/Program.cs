using System.Text;

namespace homework16;

public class EnglishFrenchDictionary
{
    private Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

    public void Add()
    {
        List<string> French = new List<string>();

        Console.WriteLine("Введіть слово на Ангійскій мові: ");
        string English = Console.ReadLine();

        while (true)
        {
            Console.WriteLine("Введіть переклад цього слова на Францускій: ");
            French.Add(Console.ReadLine());

            Console.WriteLine("Ще треба переклад добавити до слова {0}? (Y - N)", English);
            if(Console.ReadLine() != "Y")
            {
                break;
            }

        }
        dictionary.Add(English, French);
    }

    public void DelKey()
    {
        Console.WriteLine("Введіть слово на ангійскій щоб його видлати");
        string name = Console.ReadLine();
        if (dictionary.ContainsKey(name))
        {
            dictionary.Remove(name);
        }
        else
        {
            Console.WriteLine("Не вдалось найти");
        }
    }

    public void DelValue()
    {
        Console.WriteLine("Введіть слово на ангійскій щоб видалити переклад");
        string name = Console.ReadLine();

        Console.WriteLine("Введіть слово на францускій який треба видалити");
        string french = Console.ReadLine();

        if (dictionary.ContainsKey(name))
        {
            dictionary[name].Remove(french);
        }
        else
        {
            Console.WriteLine("Не вдалось найти");
        }
    }

    public void ReplaceKey()
    {
        Console.WriteLine("Введіть слово на ангійскій щоб його замінити");
        string oldEnglish = Console.ReadLine();

        if (!dictionary.ContainsKey(oldEnglish))
        {
            Console.WriteLine("Слово не знайдено.");
            return;
        }

        Console.WriteLine("Ввведіть нове слово");
        string newEnglish = Console.ReadLine();

        if (dictionary.ContainsKey(newEnglish))
        {
            Console.WriteLine("Слово вже існує.");
            return;
        }

        List<string> translations = dictionary[oldEnglish];

        dictionary.Remove(oldEnglish);

        dictionary.Add(newEnglish, translations);

        Console.WriteLine("Слово замінено ");

    }

    public void ReplaceValue()
    {
        Console.WriteLine("Введіть слово на ангійскій щоб замінити слово на францускій");
        string english = Console.ReadLine();

        if (!dictionary.ContainsKey(english))
        {
            Console.WriteLine("Слово не знайдено.");
            return;
        }

        Console.WriteLine("Введіть слово на францускій яке треаб замінити");
        string oldFrench = Console.ReadLine();

        var list = dictionary[english];
        int index = list.IndexOf(oldFrench);

        Console.WriteLine("Введіть нове слово");
        string newFrench = Console.ReadLine();

        if (index != -1)
        {
            list[index] = newFrench;
            Console.WriteLine("Слово замінено");
        }
        else
            Console.WriteLine("Переклад не знайдено.");
    }

    public void Search()
    {
        Console.WriteLine("Введіть слово для пошуку слова: ");
        string search = Console.ReadLine();
        bool yesOrNot = false;
        foreach (var item in dictionary)
        {
            if(item.Key == search)
            {
                Console.WriteLine(item);
                yesOrNot = true;
            }
        }

        if (!yesOrNot)
        {
            Console.WriteLine("Не вдалось найти слово");
        }
    }
}

public class Progarm
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        EnglishFrenchDictionary dictionary = new EnglishFrenchDictionary();

        dictionary.Add();

        dictionary.Search();

        dictionary.DelKey();

        dictionary.DelValue();

        dictionary.ReplaceValue();

        dictionary.ReplaceKey();
    }
}