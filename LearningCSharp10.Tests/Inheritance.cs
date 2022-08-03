namespace LearningCSharp10.Tests;

public class Inheritance
{
    [Test]
    public void StaticMethodIsInvokedAccordingWithType()
    {
        var house = new House();

        GetTypeName(house).Should().Be("House");
        GetTypeName(house as Asset).Should().Be("Asset");
    }

    private static string GetTypeName(Asset asset) => "Asset";
    private static string GetTypeName(House house) => "House";

    private class Asset
    {
    }

    private class House : Asset
    {
    }
}