using Deiarts.Domain.Enums;
using Deiarts.Domain.RawMaterials;

namespace Deiarts.Tests.Domain.RawMaterials;

public class RawMaterialTests
{
    [Fact]
    public void ShouldCreateValidRawMaterialWhenInformationIsProvided()
    {
        var rawMaterial = new RawMaterial("Test", "Test Description", UnitOfMeasureType.Centimeter, 0.10M);
        
        rawMaterial.Name.Should().Be("Test");
        rawMaterial.Description.Should().Be("Test Description");
        rawMaterial.UnitOfMeasure.Should().Be(UnitOfMeasureType.Centimeter);
        rawMaterial.CostPerUnit.Should().Be(0.10M);
    }
}