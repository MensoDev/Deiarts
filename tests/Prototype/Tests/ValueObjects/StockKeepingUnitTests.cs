namespace Deiarts.Prototype.Tests.ValueObjects;

public class StockKeepingUnitTests
{
    [Fact]
    public void ShouldCreateStockKeepingUnit()
    {
        var sku = new StockKeepingUnit("Nike", "Air Max", "Leather", "White");
        sku.IsValid.Should().BeTrue();
    }
    
    [Fact]
    public void ShouldNotCreateStockKeepingUnitWhenBrandIsNull()
    {
        var sku = new StockKeepingUnit(string.Empty, "Air Max", "Leather", "White");
        
        sku.IsValid.Should().BeFalse();
        sku.Notifications.Should().Contain(notification => notification.Key == nameof(StockKeepingUnit.Brand));
        sku.Notifications.Should().Contain(notification => notification.Message == "Brand is required");
    }
    
    [Fact]
    public void ShouldNotCreateStockKeepingUnitWhenModelIsNull()
    {
        var sku = new StockKeepingUnit("Nike", string.Empty, "Leather", "White");
        
        sku.IsValid.Should().BeFalse();
        sku.Notifications.Should().Contain(notification => notification.Key == nameof(StockKeepingUnit.Model));
        sku.Notifications.Should().Contain(notification => notification.Message == "Model is required");
    }
    
    [Fact]
    public void ShouldNotCreateStockKeepingUnitWhenMaterialIsNull()
    {
        var sku = new StockKeepingUnit("Nike", "Air Max", string.Empty, "White");
        
        sku.IsValid.Should().BeFalse();
        sku.Notifications.Should().Contain(notification => notification.Key == nameof(StockKeepingUnit.Material));
        sku.Notifications.Should().Contain(notification => notification.Message == "Material is required");
    }
    
    [Fact]
    public void ShouldNotCreateStockKeepingUnitWhenColorIsNull()
    {
        var sku = new StockKeepingUnit("Nike", "Air Max", "Leather", string.Empty);
        
        sku.IsValid.Should().BeFalse();
        sku.Notifications.Should().Contain(notification => notification.Key == nameof(StockKeepingUnit.Color));
        sku.Notifications.Should().Contain(notification => notification.Message == "Color is required");
    }
    
    [Fact]
    public void ShouldNotCreateStockKeepingUnitWhenBrandIsWhiteSpace()
    {
        var sku = new StockKeepingUnit(" ", "Air Max", "Leather", "White");
        
        sku.IsValid.Should().BeFalse();
        sku.Notifications.Should().Contain(notification => notification.Key == nameof(StockKeepingUnit.Brand));
        sku.Notifications.Should().Contain(notification => notification.Message == "Brand is required");
    }
    
    [Fact]
    public void ShouldNotCreateStockKeepingUnitWhenModelIsWhiteSpace()
    {
        var sku = new StockKeepingUnit("Nike", " ", "Leather", "White");
        
        sku.IsValid.Should().BeFalse();
        sku.Notifications.Should().Contain(notification => notification.Key == nameof(StockKeepingUnit.Model));
        sku.Notifications.Should().Contain(notification => notification.Message == "Model is required");
    }
    
    [Fact]
    public void ShouldNotCreateStockKeepingUnitWhenMaterialIsWhiteSpace()
    {
        var sku = new StockKeepingUnit("Nike", "Air Max", " ", "White");
        
        sku.IsValid.Should().BeFalse();
        sku.Notifications.Should().Contain(notification => notification.Key == nameof(StockKeepingUnit.Material));
        sku.Notifications.Should().Contain(notification => notification.Message == "Material is required");
    }
    
    [Fact]
    public void ShouldNotCreateStockKeepingUnitWhenColorIsWhiteSpace()
    {
        var sku = new StockKeepingUnit("Nike", "Air Max", "Leather", " ");
        
        sku.IsValid.Should().BeFalse();
        sku.Notifications.Should().Contain(notification => notification.Key == nameof(StockKeepingUnit.Color));
        sku.Notifications.Should().Contain(notification => notification.Message == "Color is required");
    }
}