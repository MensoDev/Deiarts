using Deiarts.Domain.RawMaterials;

namespace Deiarts.Tests.Domain.RawMaterials;

public class RawMaterialTests
{
    [Fact]
    public void ShouldCreateValidRawMaterialWhenNameAndDescriptioIsProvided()
    {
        var rawMaterial = new RawMaterial("Test", "Test Description");
        
        rawMaterial.Name.Should().Be("Test");
        rawMaterial.Description.Should().Be("Test Description");
    }
    
    [Fact]
    public void ShouldCreateValidRawMaterialWhenNameIsProvided()
    {
        var rawMaterial = new RawMaterial("Test", string.Empty);
        
        rawMaterial.Name.Should().Be("Test");
        rawMaterial.Description.Should().BeEmpty();
    }
}