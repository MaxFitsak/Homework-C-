using System;
using System.Collections.Generic;
using CarrierOfInformation;
using Devices;
using Interfaces;
using Logging;
using PriceList;
using Serialization;

namespace Client;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        PriceListManager manager = new PriceListManager();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Переглянути всі носії");
            Console.WriteLine("2. Записати звіт про носії у ФАЙЛ");
            Console.WriteLine("3. Додати новий носій інформації");
            Console.WriteLine("4. Видалити носій за моделлю");
            Console.WriteLine("5. Пошук носія за виробником");
            Console.WriteLine("6. Змінити кількість носіїв за моделлю");
            Console.WriteLine("7. Зберегти дані у файл (JSON / XML)");
            Console.WriteLine("8. Завантажити дані з файлу (XML / JSON)");
            Console.WriteLine("0. Вихід із програми");
            Console.Write("Оберіть дію: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Друк у консоль");
                    manager.PrintList(new ConsoleLog());
                    PressAnyKey();
                    break;

                case "2":
                    Console.Clear();
                    Console.Write("Введіть ім'я файлу для логу: ");
                    string logFile = Console.ReadLine();
                    manager.PrintList(new FileLog(logFile));
                    Console.WriteLine($"Успішно! Звіт записано у файл: {logFile}");
                    PressAnyKey();
                    break;

                case "3":
                    Console.Clear();
                    AddNewDeviceMenu(manager);
                    PressAnyKey();
                    break;

                case "4":
                    Console.Clear();
                    Console.Write("Введіть назву моделі для видалення: ");
                    string modelToRemove = Console.ReadLine();
                    if (manager.RemoveDeviceByModel(modelToRemove))
                        Console.WriteLine("Пристрій успішно видалено зі списку.");
                    else
                        Console.WriteLine("Пристрій з такою моделлю не знайдено.");
                    PressAnyKey();
                    break;

                case "5":
                    Console.Clear();
                    Console.Write("Введіть назву виробника для пошуку: ");
                    string manufacturer = Console.ReadLine();
                    var results = manager.SearchByManufacturer(manufacturer);

                    Console.WriteLine($"Результати пошуку для '{manufacturer}':");
                    if (results.Count == 0) Console.WriteLine("Нічого не знайдено.");
                    foreach (var item in results)
                    {
                        Console.WriteLine(item.Report());
                    }
                    PressAnyKey();
                    break;

                case "6":
                    Console.Clear();
                    Console.Write("Введіть назву моделі: ");
                    string modelToUpdate = Console.ReadLine();
                    Console.Write("Введіть нову кількість: ");
                    if (int.TryParse(Console.ReadLine(), out int newCount))
                    {
                        if (manager.UpdateCountByModel(modelToUpdate, newCount))
                            Console.WriteLine("Кількість успішно оновлено.");
                        else
                            Console.WriteLine("Пристрій з такою моделлю не знайдено.");
                    }
                    else
                    {
                        Console.WriteLine("Некоректне число.");
                    }
                    PressAnyKey();
                    break;

                case "7":
                    Console.Clear();
                    SaveMenu(manager);
                    PressAnyKey();
                    break;

                case "8":
                    Console.Clear();
                    LoadMenu(manager);
                    PressAnyKey();
                    break;

                case "0":
                    Console.WriteLine("Бувай!");
                    return;

                default:
                    Console.WriteLine("Неправильний вибір! Спробуйте ще раз.");
                    PressAnyKey();
                    break;
            }
        }
    }

    static void AddNewDeviceMenu(PriceListManager manager)
    {
        Console.WriteLine("Оберіть тип пристрою:");
        Console.WriteLine("1. Flash-пам'ять");
        Console.WriteLine("2. DVD-диск");
        Console.WriteLine("3. Знімний HDD");
        Console.Write("Вибір: ");
        string type = Console.ReadLine();

        if (type != "1" && type != "2" && type != "3")
        {
            Console.WriteLine("Некоректний тип.");
            return;
        }

        Console.Write("Виробник: "); string man = Console.ReadLine();
        Console.Write("Модель: "); string mod = Console.ReadLine();
        Console.Write("Найменування: "); string nam = Console.ReadLine();
        Console.Write("Місткість (GB/MB): "); int.TryParse(Console.ReadLine(), out int cap);
        Console.Write("Кількість: "); int.TryParse(Console.ReadLine(), out int cnt);

        if (type == "1")
        {
            Console.Write("Швидкість USB (наприклад, USB 3.0): "); string speed = Console.ReadLine() ?? "";
            manager.AddDevice(new FlashMemory(man, mod, nam, cap, cnt, speed));
        }
        else if (type == "2")
        {
            Console.Write("Швидкість запису (наприклад, 16x): "); string speed = Console.ReadLine() ?? "";
            manager.AddDevice(new DvdDisk(man, mod, nam, cap, cnt, speed));
        }
        else if (type == "3")
        {
            Console.Write("Швидкість шпинделя (RPM, наприклад 7200): "); int.TryParse(Console.ReadLine(), out int rpm);
            manager.AddDevice(new Hdd(man, mod, nam, cap, cnt, rpm));
        }

        Console.WriteLine("Пристрій успішно додано!");
    }

    static void SaveMenu(PriceListManager manager)
    {
        Console.WriteLine("Оберіть формат збереження:");
        Console.WriteLine("1. JSON");
        Console.WriteLine("2. XML");
        Console.Write("Вибір: ");
        string subChoice = Console.ReadLine();

        ISerialize serializer;
        string ext;

        if (subChoice == "1") { serializer = new JSONSerialize(); ext = "json"; }
        else if (subChoice == "2") { serializer = new XMLSerialize(); ext = "xml"; }
        else { Console.WriteLine("Скасовано."); return; }

        string fileName = $"database.{ext}";
        manager.SaveToFile(serializer, fileName);
        Console.WriteLine($"Дані успішно передано до класу {serializer.GetType().Name} та збережено у файл {fileName}");
    }

    static void LoadMenu(PriceListManager manager)
    {
        Console.WriteLine("Оберіть формат для завантаження:");
        Console.WriteLine("1. XML");
        Console.WriteLine("2. JSON ");
        Console.Write("Вибір: ");
        string subChoice = Console.ReadLine();

        if (subChoice == "1")
        {
            manager.LoadFromFile(new XMLSerialize(), "database.xml");
            Console.WriteLine("Дані успішно десеріалізовано з файлу database.xml");
        }
        else if (subChoice == "2")
        {
            manager.LoadFromFile(new JSONSerialize(), "database.json");
            Console.WriteLine("Дані зчитано з файлу database.json");
        }
        else
        {
            Console.WriteLine("Скасовано.");
        }
    }

    static void PressAnyKey()
    {
        Console.WriteLine("Натисніть будь-яку клавішу для повернення в меню");
        Console.ReadKey();
    }
}