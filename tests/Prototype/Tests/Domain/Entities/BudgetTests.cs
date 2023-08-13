using Deiarts.Prototype.Domain;

namespace Deiarts.Prototype.Tests.Domain.Entities;

public class BudgetTests
{
    [Fact]
    public void ShouldReturnErrorWhenTitleIsEmpty()
    {
        // Arrange

        // Act
        var budget = new Budget("", "Description", DateTimeOffset.UtcNow);

        // Assert
        budget.IsValid.Should().BeFalse();
        budget.Notifications.Should().Contain(notification => notification.Key == nameof(budget.Title));
        budget.Notifications.Should().Contain(notification => notification.Message == "Title is required");
    }
    
    [Fact]
    public void ShouldReturnErrorWhenDescriptionIsEmpty()
    {
        // Arrange

        // Act
        var budget = new Budget("Title", "", DateTimeOffset.UtcNow);

        // Assert
        budget.IsValid.Should().BeFalse();
        budget.Notifications.Should().Contain(notification => notification.Key == nameof(budget.Description));
        budget.Notifications.Should().Contain(notification => notification.Message == "Description is required");
    }
    
    [Fact]
    public void ShouldReturnErrorWhenValidityIsLessThanNow()
    {
        // Arrange

        // Act
        var budget = new Budget("Title", "Description", DateTimeOffset.MinValue);

        // Assert
        budget.IsValid.Should().BeFalse();
        budget.Notifications.Should().Contain(notification => notification.Key == nameof(budget.Validity));
        budget.Notifications.Should().Contain(notification => notification.Message == "Validity must be greater than now");
    }
    
    [Fact]
    public void ShouldReturnExceptionWhenAddItemMustBelongToThisBudget()
    {
        // Arrange
        var budget = new Budget("Title", "Description", DateTimeOffset.UtcNow.AddDays(5));
        var item = new BudgetItem(Guid.NewGuid(), Guid.NewGuid(), 1);

        // Act
        var addExecution = () => budget.AddItem(item);

        // Assert
        addExecution
            .Should()
            .Throw<DomainException>()
            .WithMessage("Item must belong to this budget");
    }
    
    [Fact]
    public void ShouldReturnSuccessWhenAddItem()
    {
        // Arrange
        var budget = new Budget("Title", "Description", DateTimeOffset.UtcNow.AddDays(5));
        var item = new BudgetItem(budget.Id, Guid.NewGuid(), 1);

        // Act
        budget.AddItem(item);

        // Assert
        budget.IsValid.Should().BeTrue();
        budget.Items.Should().Contain(item);
    }
    
    [Fact]
    public void ShouldCreateEntityWithSuccess()
    {
        // Arrange

        // Act
        var budget = new Budget("Title", "Description", DateTimeOffset.UtcNow.AddDays(5));

        // Assert
        budget.IsValid.Should().BeTrue();
    }
}