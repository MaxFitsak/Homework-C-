namespace Task
{
    class Program
{
    static void Main()
    {
        Warehouse myWarehouse = new Warehouse();

        myWarehouse.AddItem(new Item("Телефон", 10, 800, ItemCategory.Electronics));
        myWarehouse.AddItem(new Item("стіл", 5, 200, ItemCategory.Furniture));
        
        myWarehouse.Print();

        myWarehouse.UpdateItem("Телефон", 7, 750);
        myWarehouse.RemoveItem("стіл");

        myWarehouse.Print();
    }
}
}