namespace Deiarts.Prototype.Domain.Entities;

public class Budget : Entity
{
    private readonly List<BudgetProduct> _budgetProducts = [];
    private readonly List<Product> _products = [];

    public Budget(string name, string description)
    {
        Name = name;
        Description = description;
        
        Throw.When.Null(name, "Name is required");
        Throw.When.Null(description, "Description is required");
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    
    public IEnumerable<Product> Products => _products;
    public IEnumerable<BudgetProduct> BudgetProducts => _budgetProducts;
    
    public void AddMaterial(Product product, int amount)
    {
        var item = new BudgetProduct(Id, product.Id, amount);
        _budgetProducts.Add(item);
        _products.Add(product);
    }
    
    public void RemoveMaterial(Product product)
    {
        var item = _budgetProducts.Find(x => x.ProductId == product.Id);
        if (item is null) return;
        _budgetProducts.Remove(item);
        _products.Remove(product);
    }
}