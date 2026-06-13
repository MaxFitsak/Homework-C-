namespace Moedls;

public class ProductType
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

public class Supllier
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public double CostPrice { get; set; }
    public string DeliveryDate { get; set; }
    public int ProductTypeId { get; set; }
    public int SupplierId { get; set; }

    public virtual ProductType ProductType { get; set; }
    public virtual Supllier Supllier { get; set; }
}