namespace Task
{
    enum ItemCategory { Electronics, Furniture, Food };

    struct Item
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public ItemCategory Category { get; set; }

        public Item(string _name, int _quantity, double _price, ItemCategory _category)
        {
            Name = _name;
            Quantity = _quantity;
            Price = _price;
            Category = _category;
        }
    }

    class Warehouse
    {
        Item[] _items = new Item[0];

        public void AddItem(Item newItem)
        {
            if (newItem.Price < 0) throw new Exception("Ціеа не може буди відємною");

            Array.Resize(ref _items, _items.Length + 1);
            _items[_items.Length - 1] = newItem;
            Console.WriteLine("Добавлнено -> {0}", newItem.Name);
        }

        public void RemoveItem(string name)
        {
            int index = -1;
            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                Item[] newArray = new Item[_items.Length - 1];
                for (int i = 0, j = 0; i < _items.Length; i++)
                {
                    if (i == index) continue;
                    newArray[j++] = _items[i];
                }
                _items = newArray;
                Console.WriteLine("Товар {0} видалено", name);
            }
            else 
            {
                throw new Exception($"Товар {name} не знайдено");
            }
        }

        public void UpdateItem(string name, int newQty, double newPrice)
        {
            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    _items[i].Quantity = newQty;
                    _items[i].Price = newPrice;
                    Console.WriteLine($"Товар {name} обновлен.");
                    return;
                }
            }
            throw new Exception("Товар не знайдено");
        }

        public void Print()
        {
            Console.WriteLine("\nТовари на складі:");
            Console.ForegroundColor = ConsoleColor.Gray;
            
            if (_items.Length == 0) Console.WriteLine("Пусто");
            
            foreach (var item in _items)
            {
                Console.WriteLine($"{item.Name} | Кількість: {item.Quantity} | Ціна: {item.Price}");
            }
            Console.ResetColor();
        }
    }
}